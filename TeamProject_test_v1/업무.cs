using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeamProject_test_v1
{
    public partial class ���� : Form
    {
        public ����()
        {
            InitializeComponent();
            settingBigCategoryCombobox(); //��з� �޺��ڽ� ������ ����
            loadDataGridView(); //���� ���� ����
        }

        private void ����_Load(object sender, EventArgs e)
        {
            ����Ȯ��();
        }

        private void ����Ȯ��()
        {
            if (����ڸŴ���.GetInstance().Get_����() == "�μ���" || ����ڸŴ���.GetInstance().Get_����() == "����")
            {
                taskmaster_add_del_button.Enabled = true;
                taskmaster_modify_button.Enabled = true;
            }
        }

        private Boolean timecheck()
        {
            Boolean flag = false;
            if (start_time_picker.Value >= end_time_picker.Value)
            {
                flag = true;
            }
            return flag;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            string id = Properties.Settings.Default.myID;
            if (timecheck() == true)
            {
                MessageBox.Show("�������۽ð��� ����ð��� �ùٸ��� �Ƚ��ϴ�.");
            }
            //���� ���̺� ���� �Լ�
            //�����ð� �ߺ� �˻�//
            else
            {
                Boolean flag = false;
                string query1 = $"SELECT count(*) FROM ���� WHERE ���������_id = '{id}' AND (('{start_time_picker.Text}' BETWEEN ����_time AND ����_time) OR ('{end_time_picker.Text}' BETWEEN ����_time AND ����_time) OR (����_time BETWEEN '{start_time_picker.Text}' AND '{end_time_picker.Text}') OR (����_time BETWEEN '{start_time_picker.Text}' AND '{end_time_picker.Text}'))";
                if (index_textbox.Text != "")
                {
                    query1 += $" AND ����_id != {index_textbox.Text}";
                }
                query1 += ";";
                DBManager.GetDBManager().OpenConnection();
                MySqlDataReader reader1 = DBManager.GetDBManager().SetQuery(query1).ExecuteReader();
                while (reader1.Read()) //���� ���� �ִٸ� ������ ��
                {
                    if (reader1.GetInt32(0) > 0)
                    { //�ߺ��� ���� �ִٸ� flag�� true�� ����
                        flag = true;
                    }
                }
                DBManager.GetDBManager().CloseConnection();
                //�����ð� �ߺ� �˻�//
                if (flag == false) //�ð� �ߺ� ���� ���
                {
                    int small_category_index = 0;
                    //�Է��� ������ ���̺� ����
                    string query2 = $"SELECT �Һз�_id FROM ��з�,�ߺз�,�Һз� WHERE ��з�.��з�_id = �ߺз�.��з�_id AND �ߺз�.�ߺз�_id = �Һз�.�ߺз�_id AND ��з�_name = '{big_category_combobox.Text}' AND �ߺз�_name = '{mid_category_combobox.Text}' AND �Һз�_name = '{small_category_combobox.Text}'";
                    DBManager.GetDBManager().OpenConnection();
                    MySqlDataReader reader2 = DBManager.GetDBManager().SetQuery(query2).ExecuteReader();
                    while (reader2.Read())
                    {
                        small_category_index = Convert.ToInt32(reader2["�Һз�_id"]); //������ �Һз��� index���� ������
                    }
                    DBManager.GetDBManager().CloseConnection();
                    string query3;
                    if (regist_uesr_textbox.Text != "")
                    {
                        query3 = $"UPDATE ���� SET �Һз�_id = '{small_category_index}', ����_time = '{start_time_picker.Text}', ����_time = '{end_time_picker.Text}', ����_content = '{task_content_textbox.Text}' WHERE ����_id = '{index_textbox.Text}'";
                    }
                    else
                    {
                        query3 = $"INSERT INTO ����(����_content,����_time,����_time,�Һз�_id,���������_id) VALUES ('{task_content_textbox.Text}','{start_time_picker.Text}','{end_time_picker.Text}',{small_category_index},'{id}');";
                    }
                    DBManager.GetDBManager().SetQuery(query3).ExecuteNonQuery();
                    loadDataGridView(); //���� ���� ����
                    MessageBox.Show("����Ǿ����ϴ�.");
                    text_clear();
                }
                else
                {
                    MessageBox.Show("�� ������ �����ð��� �ߺ��Ǿ� ������ �Ұ����մϴ�.");
                }
            }
        }
        private void delete_button_Click(object sender, EventArgs e)
        {
            //���� ���� ���� �Լ�
            if (index_textbox.Text != "")
            {
                string query = $"DELETE FROM ���� WHERE ����_id = '{index_textbox.Text}';";
                DBManager.GetDBManager().SetQuery(query).ExecuteNonQuery();
                MessageBox.Show("�����Ǿ����ϴ�");
            }
            else
            {
                MessageBox.Show("����Ǿ� ���� ���� ���̶� ������ �Ұ����մϴ�.");
            }
            text_clear();
            loadDataGridView(); //���� ���� ����

        }
        private void text_clear()
        {
            //�ؽ�Ʈ �ڽ� �ʱ�ȭ
            big_category_combobox.SelectedIndex = -1;
            mid_category_combobox.SelectedIndex = -1;
            small_category_combobox.SelectedIndex = -1;
            index_textbox.Text = "";
            regist_uesr_textbox.Text = "";
            start_time_picker.Value = DateTime.Now;
            end_time_picker.Value = DateTime.Now;
            task_content_textbox.Text = "";
        }
        private void reset_button_Click(object sender, EventArgs e)
        {
            //��� �ؽ�Ʈ�� ��ĭ���� �ٲ�
            text_clear();
            MessageBox.Show("�ʵ尪�� �ʱ�ȭ �Ǿ����ϴ�.");
        }
        private void taskmaster_add_del_button_Click(object sender, EventArgs e)
        {
            //���������� �߰�, ������ �� �ִ� Form ���� �� ����
            ����������_�߰�_���� configForm = new ����������_�߰�_����();
            configForm.ShowDialog();
        }
        private void taskmaster_modify_button_Click(object sender, EventArgs e)
        {
            //���������� ������ �� �ִ� Form ���� �� ����

            ����������_���� taskmasterForm = new ����������_����();
            taskmasterForm.Form2Closed += Form2_Form2Closed; //���� �������� ī�װ� �ٲ���� �ٷ� Ȯ���ϱ� ���� �̺�Ʈ
            taskmasterForm.Show();
        }
        private void Form2_Form2Closed(object sender, EventArgs e)
        {
            settingBigCategoryCombobox(); // �����͸� ����
            loadDataGridView(); //���� ���� ����
        }
        public void settingBigCategoryCombobox()
        {
            //��з� �޺��ڽ� ���� �Լ�
            BigCategory.getInstance().setBigCategory(big_category_combobox);
        }
        private void big_category_combobox_Click(object sender, EventArgs e)
        {
            //��з� �޺��ڽ� Ŭ����
            settingBigCategoryCombobox();
        }
        private void big_category_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��з� �ڽ� ���ý� �ش� ���� �ش��ϴ� �ߺз� ������ �ߺз� �ڽ��� �߰�
            BigCategory.getInstance().setMidCategory(big_category_combobox.Text, mid_category_combobox);
            mid_category_combobox.Text = "";
            small_category_combobox.Text = "";
        }

        private void mid_category_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //�ߺз� �ڽ� ���ý� �ش� ���� �ش��ϴ� �Һз� ������ �Һз� �ڽ��� �߰�
            BigCategory.getInstance().setSmallCategory(big_category_combobox.Text, mid_category_combobox.Text, small_category_combobox);
            small_category_combobox.Text = "";
        }
        private void loadDataGridView()
        {
            //DataGridView�� ������ ��� ������ ������
            TaskDataGridView.getinstance().setDataGridView("SELECT ����_id AS '�ε�����ȣ', ��з�_name AS '��з���', �ߺз�_name AS '�ߺз���', �Һз�_name AS '�Һз���', ����_time AS '���۽ð�', ����_time AS '����ð�', �̸�, ����_content AS '��������', ���������_id  FROM ����, �Һз�, �ߺз�, ��з�,��� WHERE ����.���������_id = ���.�����ȣ AND ����.�Һз�_id = �Һз�.�Һз�_id AND �Һз�.�ߺз�_id = �ߺз�.�ߺз�_id AND �ߺз�.��з�_id = ��з�.��з�_id", dataGridView1);
        }
        private void filter_button_Click(object sender, EventArgs e)
        {
            //���Ϳ� �´� ���Ǹ� DataGridView�� ��ȯ�ϴ� �Լ�
            string query = $"SELECT ����_id AS '�ε�����ȣ', ��з�_name AS '��з���', �ߺз�_name AS '�ߺз���', �Һз�_name AS '�Һз���', ����_time AS '���۽ð�', ����_time AS '����ð�', �̸�, ����_content AS '��������', ���������_id FROM ����, �Һз�, �ߺз�, ��з�,��� WHERE ����.���������_id = ���.�����ȣ AND ����.�Һз�_id = �Һз�.�Һз�_id AND �Һз�.�ߺз�_id = �ߺз�.�ߺз�_id AND �ߺз�.��з�_id = ��з�.��з�_id";

            if (start_date_filter_textbox.Text != "")
            {
                query += $" AND ����_time LIKE'%{start_date_filter_textbox.Text}%'";
            }
            if (end_date_filter_textbox.Text != "")
            {
                query += $" AND ����_time LIKE'%{end_date_filter_textbox.Text}%'";
            }
            if (task_keword_filter_textbox.Text != "")
            {
                query += $" AND �Һз�_name LIKE'%{task_keword_filter_textbox.Text}%'";
            }
            if (register_filter_textbox.Text != "")
            {
                query += $" AND �̸� LIKE'%{register_filter_textbox.Text}%'";
            }
            query += ";";
            TaskDataGridView.getinstance().setDataGridView(query, dataGridView1);
        }
        private void filter_cancel_button_Click(object sender, EventArgs e)
        {
            //���� ����
            loadDataGridView();
            start_date_filter_textbox.Text = "";
            end_date_filter_textbox.Text = "";
            task_keword_filter_textbox.Text = "";
            register_filter_textbox.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView �� Ŭ���� ������ �ϴ��� ���â�� �����
            text_clear();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Cells[8].Value.ToString() == ����ڸŴ���.GetInstance().Get_�����ȣ()) { delete_button.Enabled = true; }
                else { delete_button.Enabled = false; }

                string startdateString = selectedRow.Cells[4].Value.ToString();
                if (DateTime.TryParse(startdateString, out DateTime parsedDate))
                {
                    start_time_picker.Value = parsedDate;
                }
                string enddateString = selectedRow.Cells[5].Value.ToString();
                if (DateTime.TryParse(enddateString, out DateTime parsedDate2))
                {
                    end_time_picker.Value = parsedDate2;
                }
                big_category_combobox.Text = selectedRow.Cells[1].Value.ToString();
                mid_category_combobox.Text = selectedRow.Cells[2].Value.ToString();
                small_category_combobox.Text = selectedRow.Cells[3].Value.ToString();
                index_textbox.Text = selectedRow.Cells[0].Value.ToString();

                regist_uesr_textbox.Text = selectedRow.Cells[6].Value.ToString();
              //  if (String.IsNullOrEmpty(regist_uesr_textbox.Text)) regist_uesr_textbox.Text = ����ڸŴ���.GetInstance().Get_����̸�();

                task_content_textbox.Text = selectedRow.Cells[7].Value.ToString();
            }
        }


    }
}