namespace TeamProject_test_v1
{
    partial class 급여대장
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            money_dataGridView = new DataGridView();
            search_button = new Button();
            year_combobox = new ComboBox();
            month_combobox = new ComboBox();
            total_member_dataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            buttonRe = new Button();
            ((System.ComponentModel.ISupportInitialize)money_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)total_member_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // money_dataGridView
            // 
            money_dataGridView.AllowUserToAddRows = false;
            money_dataGridView.AllowUserToDeleteRows = false;
            money_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            money_dataGridView.Location = new Point(12, 92);
            money_dataGridView.Name = "money_dataGridView";
            money_dataGridView.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            money_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            money_dataGridView.RowHeadersVisible = false;
            money_dataGridView.RowHeadersWidth = 51;
            money_dataGridView.RowTemplate.Height = 29;
            money_dataGridView.Size = new Size(1256, 541);
            money_dataGridView.TabIndex = 0;
            // 
            // search_button
            // 
            search_button.BackColor = Color.FromArgb(128, 128, 255);
            search_button.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            search_button.ForeColor = Color.White;
            search_button.Location = new Point(1148, 50);
            search_button.Name = "search_button";
            search_button.Size = new Size(120, 34);
            search_button.TabIndex = 10;
            search_button.Text = "조회";
            search_button.UseVisualStyleBackColor = false;
            search_button.Click += search_button_Click;
            // 
            // year_combobox
            // 
            year_combobox.FormattingEnabled = true;
            year_combobox.Location = new Point(12, 58);
            year_combobox.Name = "year_combobox";
            year_combobox.RightToLeft = RightToLeft.No;
            year_combobox.Size = new Size(151, 28);
            year_combobox.TabIndex = 9;
            // 
            // month_combobox
            // 
            month_combobox.FormattingEnabled = true;
            month_combobox.Location = new Point(212, 58);
            month_combobox.Name = "month_combobox";
            month_combobox.Size = new Size(151, 28);
            month_combobox.TabIndex = 8;
            // 
            // total_member_dataGridView
            // 
            total_member_dataGridView.AllowUserToAddRows = false;
            total_member_dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            total_member_dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            total_member_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            total_member_dataGridView.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            total_member_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            total_member_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            total_member_dataGridView.ColumnHeadersVisible = false;
            total_member_dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("맑은 고딕", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            total_member_dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            total_member_dataGridView.Location = new Point(12, 639);
            total_member_dataGridView.Name = "total_member_dataGridView";
            total_member_dataGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            total_member_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            total_member_dataGridView.RowHeadersVisible = false;
            total_member_dataGridView.RowHeadersWidth = 51;
            total_member_dataGridView.RowTemplate.Height = 29;
            total_member_dataGridView.Size = new Size(1256, 69);
            total_member_dataGridView.TabIndex = 11;
            // 
            // Column1
            // 
            Column1.HeaderText = "항목";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "값";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "값";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "값";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(169, 61);
            label1.Name = "label1";
            label1.Size = new Size(27, 23);
            label1.TabIndex = 12;
            label1.Text = "년";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(369, 61);
            label2.Name = "label2";
            label2.Size = new Size(27, 23);
            label2.TabIndex = 13;
            label2.Text = "월";
            // 
            // buttonRe
            // 
            buttonRe.BackColor = Color.FromArgb(128, 128, 255);
            buttonRe.Font = new Font("맑은 고딕", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRe.ForeColor = Color.White;
            buttonRe.Location = new Point(1022, 50);
            buttonRe.Name = "buttonRe";
            buttonRe.Size = new Size(120, 34);
            buttonRe.TabIndex = 14;
            buttonRe.Text = "초기화";
            buttonRe.UseVisualStyleBackColor = false;
            buttonRe.Click += buttonRe_Click;
            // 
            // 급여대장
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1280, 720);
            Controls.Add(buttonRe);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(total_member_dataGridView);
            Controls.Add(search_button);
            Controls.Add(year_combobox);
            Controls.Add(month_combobox);
            Controls.Add(money_dataGridView);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "급여대장";
            Text = "부서추가";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)money_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)total_member_dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView money_dataGridView;
        private Button search_button;
        private ComboBox year_combobox;
        private ComboBox month_combobox;
        private DataGridView total_member_dataGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label1;
        private Label label2;
        private Button buttonRe;
    }
}