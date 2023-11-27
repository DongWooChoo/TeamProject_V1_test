using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TeamProject_test_v1
{
    internal class RealTimeMailManager
    {
        private static RealTimeMailManager instance;
        private string userid = 사용자매니저.GetInstance().Get_사원번호(); //사원번호 받아오기

        private System.Timers.Timer timer; // Timer 객체 변수
        public static RealTimeMailManager GetTimer()
        {
            if (instance == null)
            {
                 instance = new RealTimeMailManager();
            }
            return instance;
        }

        private RealTimeMailManager()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 500; // 2초
            timer.Elapsed += checkMail;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //2초마다 실행
        private async void checkMail(object sender, ElapsedEventArgs e)
        {
            Dictionary<string, string> newmails = new Dictionary<string, string>();
            string query = $"SELECT concat(송신자.부서명,'_',송신자.직급,'_',송신자.이름) AS 송신자, 쪽지.쪽지_id AS 쪽지번호 FROM 쪽지 join 사원 AS 송신자 on 쪽지.송신자_사원번호=송신자.사원번호 where '{userid}'=쪽지.수신자_사원번호 AND 쪽지.쪽지_ShowCheck=0;";

            MailDBManager.GetDBManager().OpenConnection();
            using ( MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader())
            {
                while (reader.Read())
                {
                    newmails[$"{reader["송신자"].ToString()}"] = reader["쪽지번호"].ToString();
                }
            }

            foreach (KeyValuePair<string, string> newmail in newmails)
            {
                query = $"UPDATE 쪽지 SET 쪽지.쪽지_ShowCheck=1 WHERE 쪽지.쪽지_id='{newmail.Value}';";
                DBManager.GetDBManager().SetQuery(query).ExecuteNonQuery();
                ShowMessageBox(newmail.Key);
            }

            MailDBManager.GetDBManager().OpenConnection();
            query = $"SELECT COUNT(*) AS 받은개수 FROM 쪽지 WHERE 쪽지_Read=0 AND 수신자_사원번호='{userid}';";
            using (MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader())
            {
                while (reader.Read())
                {
                    //reader["받은개수"].ToString()
                }
            }
        }

        static async Task ShowMessageBox(string message)
        {
            await Task.Run(() =>
            {
                MessageBox.Show($"{message}님에게 쪽지가 도착했습니다.");
            });
        }
    }
}
