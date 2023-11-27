using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using Google.Protobuf.WellKnownTypes;

namespace TeamProject_test_v1
{
    internal class Additional_Allowance
    {
        private static Additional_Allowance aa = new Additional_Allowance();

        private Additional_Allowance()
        {
        }

        public static Additional_Allowance getInstance() { return aa; }

        public string sendQuery(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                DBManager.GetDBManager().OpenConnection();
                using (MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                        }

                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader[i];
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                DBManager.GetDBManager().CloseConnection();
            }

            return dt.Rows[0][0].ToString();
        }

        private string startTime()
        {
            string query = $"SELECT 출근시간 FROM s5584720.출근부 WHERE 사원번호 = '{Properties.Settings.Default.myID}' AND 퇴근시간 IS NULL;";
            string[] words = sendQuery(query).Split(' ');
            return words[0];
        }

        public void autoAccepte(string end, string total)
        {
            string num = Properties.Settings.Default.myID;
            string start = startTime();
            string nigth = nightWork(num, start);
            string holly = holidayWork(num, start);
            string over = overtimeWork(num, start, end, total);

            if (nigth == "0" && holly == "0" && over == "0")
            {
                string query = $"UPDATE s5584720.출근부 SET 일반근로시간 = '@nomalWork', 연장근로시간 = '0', 야간근로시간 = '0', 휴일근로시간 = '0', 총근로시간 = '@nomalWork', 결재여부 = 1 WHERE 사원번호 = '{Properties.Settings.Default.myID}' AND 출근시간 LIKE '@start%'; ";
            }
        }

        public string normalWork(string num, string start) // 통상 근무시간 계산
        {
            string query = "SELECT TIMESTAMPDIFF(MINUTE, 출근시간, 퇴근시간) AS 일반근무시간 FROM s5584720.출근부 WHERE 사원번호 = '@num' AND 출근시간 LIKE '@end%';"; // 퇴근시간 - 출근시간
            query = query.Replace("@num", num);
            query = query.Replace("@end", start);

            string result = sendQuery(query);

            int count = Convert.ToInt32(result) - 60; // 1시간 점심시간 제외

            if (count > 480) // 야간 근무를 했을경우
            {
                query = "SELECT TIMESTAMPDIFF(MINUTE, 출근시간, '@end 18:00:00') AS 일반근무시간 FROM s5584720.출근부 WHERE 사원번호 = '@num' AND 출근시간 LIKE '@end%';";
                query = query.Replace("@num", num);
                query = query.Replace("@end", start);

                result = sendQuery(query);
                count = Convert.ToInt32(result) - 60; // 1시간 점심시간 제외
            }

            return count.ToString();
        }

        public string nightWork(string num, string start) //저녁 6시~ 새벽 6시 통상 임금의 50% 가산
        {
            string query = "SELECT TIMESTAMPDIFF(MINUTE, '@start 19:00:00', 퇴근시간) AS 일반근무시간 FROM s5584720.출근부 WHERE 사원번호 = '@num' AND 출근시간 LIKE '@start%';";
            query = query.Replace("@num", num);
            query = query.Replace("@start", start);

            string result = sendQuery(query);

            if (Convert.ToInt32(result) <= 0)
            {
                return "0";
            }

            return result;
        }

        public string holidayWork(string num, string start) //8시간까지는 통상임금의 50% 가산 그 이상은 통상임금의 100% 가산
        {
            string date = start.Replace("-", "");
            if (PublicAPI.getInstance().GetAPI(date) == true || checkWeekend(Convert.ToDateTime(start)) == 1)
            {
                string query = "SELECT TIMESTAMPDIFF(MINUTE, 출근시간, 퇴근시간) AS 일반근무시간 FROM s5584720.출근부 WHERE 사원번호 = '@num' AND 출근시간 LIKE '@start%';";
                query = query.Replace("@num", num);
                query = query.Replace("@start", start);

                string result = sendQuery(query);

                if (Convert.ToInt32(result) >= 300) // 5시간 이상 근로시 1시간 휴식시간 (점심 or 저녁시간) 제공 필수
                {
                    int count = Convert.ToInt32(result) - 60; // 1시간 점심시간 제외
                    return count.ToString();
                }

                return result;
            }

            return "0";
        }

        public DataTable sendQuery_overTime(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                DBManager.GetDBManager().OpenConnection();
                using (MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                        }

                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader[i];
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                DBManager.GetDBManager().CloseConnection();
            }

            return dt;
        }

        public string overtimeWork(string num, string start, string end, string total) // 주 40시간(법정근로시간)을 초과하는 근로시간 통상 임금의 50% // 일주일
        {
            string query = "SELECT 총근로시간 FROM s5584720.출근부 WHERE 사원번호 = '@num' AND 출근시간 BETWEEN '@between 00:00:00' AND '@end 23:59:59';"; // 당일을 제외한 그 주 총 일한 시간 계산
            query = query.Replace("@num", num);
            query = query.Replace("@end", Convert.ToDateTime(end).AddDays(-1).ToString());
            query = query.Replace("@between", subDate(Convert.ToDateTime(start)));

            DataTable dt = new DataTable();
            dt = sendQuery_overTime(query);

            int result = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result = result + Convert.ToInt32(dt.Rows[i][0].ToString());
            }

            result = result + Convert.ToInt32(total); // 당일 일한 시간 추가
            result = result - 2400; // 40시간 제외

            if (result > 0) // 40시간 넘었는지 확인
            {
                if (Convert.ToInt32(total) < result) // 40시간 넘었을 경우 당일 근로시간과 비교, 당일 근로시간보다 연장 근무시간이 크면 당일 근로시간 출력
                {
                    return total.ToString();
                }
                else // 당일 근로시간보다 연장 근무 시간이 작으면 연장 근무 시간 출력
                {
                    return result.ToString();
                }
            }
            else  // 40시간 안넘었으면 0 출력
            {
                return "0";
            }

        }

        private string subDate(DateTime date)
        {
            // 빼고 싶은 날짜 수를 지정합니다. 음수 값을 사용하여 뺄 수 있습니다.
            int daysToSubtract = checkWeek(date); // 예: 7일 전으로 이동

            // 현재 날짜에서 지정된 날짜 수를 뺍니다.
            DateTime newDate = date.AddDays(-daysToSubtract);

            return newDate.ToString();
        }

        private int checkWeek(DateTime dt) // 연장근무 위해 지금으로 부터 몇일 전 데이터 부터 불러와야되는지 계산
        {
            int week = 0;

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    week = 0;
                    break;
                case DayOfWeek.Tuesday:
                    week = 1;
                    break;
                case DayOfWeek.Thursday:
                    week = 2;
                    break;
                case DayOfWeek.Wednesday:
                    week = 3;
                    break;
                case DayOfWeek.Friday:
                    week = 4;
                    break;
                case DayOfWeek.Saturday:
                    week = 5;
                    break;
                case DayOfWeek.Sunday:
                    week = 6;
                    break;
            }

            return week;
        }

        private int checkWeekend(DateTime dt) // 평일/주말 판별
        {
            int weekend = 0;

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    weekend = 1;
                    break;
                case DayOfWeek.Sunday:
                    weekend = 1;
                    break;
                default:
                    weekend = 0;
                    break;
            }

            return weekend;
        }


        // 여기서부터는 관리자 화면 같은 코드

        public void check_salary(string num)
        {
            string query = "SELECT 직급번호 FROM s5584720.사원 where s5584720.사원.사원번호 = '@num';";
            query = query.Replace("@num", num);

            if (sendQuery(query) == "0") // 사장이면 확인
            {
                checkTenth();
            }
        }

        private DataTable collection_number()
        {
            string query = "SELECT distinct 사원번호 FROM s5584720.출근부;";
            return sendQuery_overTime(query);
        }

        private void checkTenth() // 날짜가 10일이면 정산
        {
            DataTable dt = new DataTable();
            dt = collection_number(); // 전 사원 사원 번호 확인

            DateTime currentDate = DateTime.Now;
            int dayOfMonth = currentDate.Day;

            if (dayOfMonth == 10) // 현재 날짜로 되어있기 때문에 시연할때 날짜 변경이나 수치 임의로 주입 필요
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    추가수당.getInstance().moneyTable(dt.Rows[i][0].ToString()); // 순차적으로 지급
                }
            }
        }

    }
}
