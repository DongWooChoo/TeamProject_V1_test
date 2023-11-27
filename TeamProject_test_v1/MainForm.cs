using MySql.Data.MySqlClient;

namespace TeamProject_test_v1
{
    public partial class MainForm : Form
    {
        EmployeeInfo employeeInfo;

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            SetTreeViewData();
            employeeInfo = new EmployeeInfo();

            RealTimeMailManager mailManager = RealTimeMailManager.GetTimer();
        }

        public MainForm(string username)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            SetTreeViewData();
            employeeInfo = new EmployeeInfo();
            employeeInfo = employeeInfo.setEmployeeInfo(username);
            ����ڸŴ���.GetInstance().Set_����ڸŴ���(employeeInfo.�̸�, employeeInfo.�����ȣ, employeeInfo.�μ���ȣ.ToString(), employeeInfo.����, employeeInfo.���޹�ȣ.ToString());
            //setEmployee(username);
            showEmployeeInfo();
            ��ٿ���üũ();
        }

        /// <summary>
        /// �α׾ƿ� ��ư ���� �α����� ���� ���� �� �ؽ�Ʈ ��ȯ��Ű�� �Լ�
        /// </summary>
        private void showEmployeeInfo()
        {
            labelName.Text = employeeInfo.ToString();
        }

        public void SetTreeViewData()
        {
            TreeNode workNode = new TreeNode("��������", 0, 0);
            workNode.Nodes.Add("WS", "�����˻�", 0, 0);

            TreeNode attNode = new TreeNode("����ٰ���", 0, 0);
            attNode.Nodes.Add("AL", "����ٱ��", 0, 0);
            attNode.Nodes.Add("AC", "�������Ȳ", 0, 0);

            TreeNode hrNode = new TreeNode("�λ����", 0, 0);
            hrNode.Nodes.Add("ES", "����˻�", 0, 0);
            hrNode.Nodes.Add("ER", "������", 0, 0);

            TreeNode dmNode = new TreeNode("�μ�����", 0, 0);
            dmNode.Nodes.Add("DR", "�μ����", 0, 0);

            TreeNode payNode = new TreeNode("�������", 0, 0);
            payNode.Nodes.Add("NP", "������ȸ", 0, 0);

            TreeNode accountNode = new TreeNode("�޿�����", 0, 0);
            accountNode.Nodes.Add("ST", "�޿�����", 0, 0);

            this.treeViewMenu.Nodes.Add(workNode);
            this.treeViewMenu.Nodes.Add(attNode);
            this.treeViewMenu.Nodes.Add(hrNode);
            this.treeViewMenu.Nodes.Add(dmNode);
            this.treeViewMenu.Nodes.Add(payNode);
            this.treeViewMenu.Nodes.Add(accountNode);
            this.treeViewMenu.ItemHeight = 30;
        }

        private void treeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeKey = e.Node.Name;
            if (!string.IsNullOrEmpty(nodeKey))
            {
                button����.Enabled = true;
                treeViewMenu.SelectedNode.NodeFont = new Font(treeViewMenu.Font, FontStyle.Bold);
                //MessageBox.Show("���õ� ��� Ű: " + nodeKey);
                if (nodeKey == "WS")
                {
                    //ChildForm1 childForm1 = new ChildForm1("name");
                    ���� workForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != workForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        workForm = ShowActiveForm(workForm, typeof(����)) as ����;
                    }
                    else
                    {
                        workForm = ShowActiveForm(workForm, typeof(����)) as ����;
                    }
                }

                if (nodeKey == "AL")
                {
                    ����ٱ�� alForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != alForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        alForm = ShowActiveForm(alForm, typeof(����ٱ��)) as ����ٱ��;
                    }
                    else
                    {
                        alForm = ShowActiveForm(alForm, typeof(����ٱ��)) as ����ٱ��;
                    }
                }

                if (nodeKey == "AC")
                {
                    �������Ȳ acForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != acForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        acForm = ShowActiveForm(acForm, typeof(�������Ȳ)) as �������Ȳ;
                    }
                    else
                    {
                        acForm = ShowActiveForm(acForm, typeof(�������Ȳ)) as �������Ȳ;
                    }
                }

                if (nodeKey == "ES")
                {
                    //ChildForm1 childForm1 = new ChildForm1("name");
                    EmployeeSearchForm employeeSearchForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != employeeSearchForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        employeeSearchForm = ShowActiveForm(employeeSearchForm, typeof(EmployeeSearchForm)) as EmployeeSearchForm;
                    }
                    else
                    {
                        employeeSearchForm = ShowActiveForm(employeeSearchForm, typeof(EmployeeSearchForm)) as EmployeeSearchForm;
                    }
                }

                if (nodeKey == "ER")
                {
                    if (employeeInfo.���� != "�μ���" && employeeInfo.���� != "����")
                    {
                        MessageBox.Show("������ �����ϴ�.");
                        treeViewMenu.SelectedNode.NodeFont = null;
                        treeViewMenu.SelectedNode = null;
                        return;
                    }
                    EmployeeAddForm employeeAddForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != employeeAddForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        employeeAddForm = ShowActiveForm(employeeAddForm, typeof(EmployeeAddForm)) as EmployeeAddForm;
                    }
                    else
                    {
                        employeeAddForm = ShowActiveForm(employeeAddForm, typeof(EmployeeAddForm)) as EmployeeAddForm;
                    }
                }

                if (nodeKey == "DR")
                {
                    �μ���� dmForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != dmForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        dmForm = ShowActiveForm(dmForm, typeof(�μ����)) as �μ����;
                    }
                    else
                    {
                        dmForm = ShowActiveForm(dmForm, typeof(�μ����)) as �μ����;
                    }
                }

                if (nodeKey == "NP")
                {
                    ����_���� npForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != npForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        npForm = ShowActiveForm(npForm, typeof(����_����)) as ����_����;
                    }
                    else
                    {
                        npForm = ShowActiveForm(npForm, typeof(����_����)) as ����_����;
                    }
                }

                if (nodeKey == "ST")
                {
                    if (employeeInfo.���� != "����")
                    {
                        MessageBox.Show("������ �����ϴ�.");
                        treeViewMenu.SelectedNode.NodeFont = null;
                        treeViewMenu.SelectedNode = null;
                        return;
                    }
                    �޿����� stForm = null;
                    if (this.ActiveMdiChild != null)
                    {
                        if (this.ActiveMdiChild != stForm)
                        {
                            this.ActiveMdiChild.Close();
                        }
                        stForm = ShowActiveForm(stForm, typeof(�޿�����)) as �޿�����;
                    }
                    else
                    {
                        stForm = ShowActiveForm(stForm, typeof(�޿�����)) as �޿�����;
                    }
                }
            }
        }

        private void treeViewMenu_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeViewMenu.SelectedNode != null)
                treeViewMenu.SelectedNode.NodeFont = new Font(treeViewMenu.Font, FontStyle.Regular);

        }

        private Form ShowActiveForm(Form form, Type type)
        {
            if (form == null)
            {
                Point parentPoint = this.Location;
                form = (Form)Activator.CreateInstance(type);
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(146, 50);
                form.Show();
            }
            else
            {
                if (form.IsDisposed)
                {
                    Point parentPoint = this.Location;
                    form = (Form)Activator.CreateInstance(type);
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = new Point(146, 50);
                    form.Show();
                }
                else
                {
                    form.Activate();
                }
            }
            return form;
        }

        //�α׾ƿ� ��ư�� �������� ������ x��ư�� �������� �Ǵ��ϴ� ���� (0 = ���� / 1 = �α׾ƿ�)
        private int check = 0;
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (!��ٿ���üũ())
            {
                var confirmResult = MessageBox.Show("��ٽð��� �Էµ��� �ʾҽ��ϴ�. \n����̶�� ��� ��ư�� Ŭ�����ּ���.\n�α׾ƿ� �Ͻðڽ��ϱ�?", "Ȯ��â", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    check = 1;
                    this.Close();
                }
                else return;
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                check = 1;
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (check == 0)
            {
                if (!��ٿ���üũ())
                {
                    var confirmResult1 = MessageBox.Show("��ٽð��� �Էµ��� �ʾҽ��ϴ�. \n����̶�� ��� ��ư�� Ŭ�����ּ���.\n���� �Ͻðڽ��ϱ�?", "Ȯ��â", MessageBoxButtons.YesNo);
                    if (confirmResult1 == DialogResult.Yes)
                    {
                        check = 1;
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    } 
                }

                var confirmResult2 = MessageBox.Show("�����Ͻðڽ��ϱ�?", "Ȯ��â", MessageBoxButtons.YesNo);
                if (confirmResult2 == DialogResult.Yes)
                {
                    check = 1;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void button����_Click(object sender, EventArgs e)
        {
            if (treeViewMenu.SelectedNode != null) { treeViewMenu.SelectedNode.NodeFont = null; }
            treeViewMenu.SelectedNode = null;

            ���� pmForm = null;
            if (this.ActiveMdiChild != null)
            {
                if (this.ActiveMdiChild != pmForm)
                {
                    this.ActiveMdiChild.Close();
                }
                pmForm = ShowActiveForm(pmForm, typeof(����)) as ����;
            }
            else
            {
                pmForm = ShowActiveForm(pmForm, typeof(����)) as ����;
            }
            button����.Enabled = false;
        }

        private void button�޿�_Click(object sender, EventArgs e)
        {
            if (treeViewMenu.SelectedNode != null) { treeViewMenu.SelectedNode.NodeFont = null; }
            treeViewMenu.SelectedNode = null;

            salary �޿�Form = new salary();
            �޿�Form.ShowDialog();
        }

        private bool ��ٿ���üũ()
        {
            string query = $"SELECT ��ٽð� FROM ��ٺ� WHERE �����ȣ = '{Properties.Settings.Default.myID}' AND ��ٽð� IS NULL";
            DBManager.GetDBManager().OpenConnection();
            MySqlDataReader reader = DBManager.GetDBManager().SetQuery(query).ExecuteReader();
            if (!reader.Read())
            {
                button���.Enabled = false;
                DBManager.GetDBManager().CloseConnection();
                return true;
            }
            else
            {
                DBManager.GetDBManager().CloseConnection();
                return false;
            }
        }

        private void button���_Click(object sender, EventArgs e)
        {
            var confirmResult2 = MessageBox.Show("����Ͻðڽ��ϱ�?", "Ȯ��â", MessageBoxButtons.YesNo);
            if (confirmResult2 == DialogResult.Yes)
            {
                string query = $"UPDATE s5584720.��ٺ� SET ��ٽð� = now() WHERE �����ȣ = '{Properties.Settings.Default.myID}' AND ��ٽð� IS NULL ";
                int result = DBManager.GetDBManager().SetQuery(query).ExecuteNonQuery();
                if (result == -1)
                {
                    MessageBox.Show("���� ����");
                }
                ��ٿ���üũ();
            }
        }
    }
}