using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject_test_v1
{
    public partial class 추가수당신청 : Form
    {
        string num = string.Empty;

        public 추가수당신청()
        {
            InitializeComponent();
        }

        private void 추가수당신청_Load(object sender, EventArgs e)
        {
            this.num = Properties.Settings.Default.myID; // 임시로 사용 실제로는 밑에 코드에서 로드 필요할듯
            출근시간가져오기();
        }

        private void 출근시간가져오기()
        {
            string query = $"SELECT 출근시간 FROM s5584720.출근부 where 사원번호 = '{num}' and 결재여부 = 0 AND 퇴근시간 IS NOT NULL";
            DBManager.GetDBManager().OpenConnection();
            MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader();
            while (reader.Read())
            {
                출근시간_comboBox.Items.Add(Convert.ToDateTime(reader["출근시간"]).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            DBManager.GetDBManager().CloseConnection();
        }

        private Boolean check_holiday(string word)
        {
            if (Additional_Allowance.getInstance().holidayWork(num, word) == "0")
            {
                return false;
            }
            else { return true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = 출근시간_comboBox.Text.Split(' '); // 출근 시간의 날짜 추출
            string[] ends = end_textBox.Text.Split(' '); // 퇴근 시간의 날짜 추출
            int total = 0;

            string query = "UPDATE s5584720.출근부 SET 일반근로시간 = '@nomalWork', 연장근로시간 = '@overtimeWork', 야간근로시간 = '@nigthWork', 휴일근로시간 = '@holidayWork', 총근로시간 = '@totalWork', 결재여부 = 0 WHERE 사원번호 = '@num' AND 출근시간 LIKE '@start%';";

            query = query.Replace("@num", num);
            query = query.Replace("@start", words[0]);

            if (check_holiday(words[0])) // 휴일근무 -> 근무 총 시간은 휴일근무
            {
                query = query.Replace("@nomalWork", "0");
                query = query.Replace("@totalWork", Additional_Allowance.getInstance().holidayWork(num, words[0]));
                query = query.Replace("@holidayWork", Additional_Allowance.getInstance().holidayWork(num, words[0]));
                query = query.Replace("@overtimeWork", Additional_Allowance.getInstance().overtimeWork(num, words[0], ends[0], Additional_Allowance.getInstance().holidayWork(num, words[0])));
            }
            else // 휴일근무 X -> 근무 총 시간은 일반근무 + 야간근무
            {
                query = query.Replace("@nomalWork", Additional_Allowance.getInstance().normalWork(num, words[0]));
                query = query.Replace("@holidayWork", "0");
                total = Convert.ToInt32(Additional_Allowance.getInstance().normalWork(num, words[0])) + Convert.ToInt32(Additional_Allowance.getInstance().nightWork(num, words[0]));
                query = query.Replace("@totalWork", total.ToString());
                query = query.Replace("@overtimeWork", Additional_Allowance.getInstance().overtimeWork(num, words[0], ends[0], total.ToString()));

            }

            query = query.Replace("@nigthWork", Additional_Allowance.getInstance().nightWork(num, words[0]));

            DBManager.GetDBManager().SetQuery(query).ExecuteNonQuery();

            this.Close();
        }

        private void Cancle_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void send_EndTime(string start)
        {
            string query = "UPDATE s5584720.출근부 SET 퇴근시간 = '@end' WHERE 사원번호 = '@num' AND 출근시간 LIKE '@start%';";
            query = query.Replace("@start", start);
            query = query.Replace("@num", num);
            query = query.Replace("@end", end_textBox.Text);

            DBManager.GetDBManager().SetQuery(query).ExecuteNonQuery();
        }

        private void show_work()
        {
            if (출근시간_comboBox.Text == null)
            {
                MessageBox.Show("출근 시간을 선택해 주세요");
            }
            else
            {
                string[] words = 출근시간_comboBox.Text.Split(' '); // 출근 시간의 날짜 추출
                string[] ends = end_textBox.Text.Split(' '); // 퇴근 시간의 날짜 추출
                string totalMoney = string.Empty;
                int cnt = 추가수당.getInstance().hourlyRate(num);
                send_EndTime(words[0]);

                if (check_holiday(words[0])) // 휴일근무 -> 근무 총 시간은 휴일근무
                {
                    holiday_textBox.Text = Additional_Allowance.getInstance().holidayWork(num, words[0]) + "분";
                    totalMoney = Additional_Allowance.getInstance().holidayWork(num, words[0]);
                }
                else // 휴일근무 X -> 근무 총 시간은 일반근무 + 야간근무
                {
                    holiday_textBox.Text = "0분";
                    int total = Convert.ToInt32(Additional_Allowance.getInstance().normalWork(num, words[0])) + Convert.ToInt32(Additional_Allowance.getInstance().nightWork(num, words[0]));
                    totalMoney = total.ToString();
                }

                night_textBox.Text = Additional_Allowance.getInstance().nightWork(num, words[0]) + "분";
                overtime_textBox.Text = Additional_Allowance.getInstance().overtimeWork(num, words[0], ends[0], totalMoney) + "분";
                total_Money_textBox.Text = (Convert.ToInt32(totalMoney) * cnt).ToString() + "원";
            }
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            show_work();
        }

        private void 출근시간_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (출근시간_comboBox.SelectedIndex == -1) return;
            string query = $"SELECT 퇴근시간 FROM 출근부 WHERE 사원번호 = '{num}' AND 출근시간 = '{출근시간_comboBox.SelectedItem.ToString()}'";
            DBManager.GetDBManager().OpenConnection();
            MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader();
            if (reader.Read())
            {
                end_textBox.Text = Convert.ToDateTime(reader["퇴근시간"]).ToString("yyyy-MM-dd HH:mm:ss"); // 여기 오류 이유 모름!
            }
            DBManager.GetDBManager().CloseConnection();
        }
    }
}
