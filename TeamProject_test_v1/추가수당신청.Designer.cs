﻿namespace TeamProject_test_v1
{
    partial class 추가수당신청
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
            Payment_button = new Button();
            Cancle_button = new Button();
            night_textBox = new TextBox();
            total_Money_textBox = new TextBox();
            total_groupBox = new GroupBox();
            detail_text_label = new Label();
            additional_allowance_label = new Label();
            night_label = new Label();
            dayoff_label = new Label();
            extension_label = new Label();
            holiday_textBox = new TextBox();
            overtime_textBox = new TextBox();
            end_label = new Label();
            start_label = new Label();
            end_textBox = new TextBox();
            start_textBox = new TextBox();
            select_button = new Button();
            출근시간_comboBox = new ComboBox();
            total_groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // Payment_button
            // 
            Payment_button.BackColor = Color.SkyBlue;
            Payment_button.FlatStyle = FlatStyle.Popup;
            Payment_button.ForeColor = Color.White;
            Payment_button.Location = new Point(194, 353);
            Payment_button.Margin = new Padding(4);
            Payment_button.Name = "Payment_button";
            Payment_button.Size = new Size(153, 40);
            Payment_button.TabIndex = 2;
            Payment_button.Text = "결재";
            Payment_button.UseVisualStyleBackColor = false;
            Payment_button.Click += button1_Click;
            // 
            // Cancle_button
            // 
            Cancle_button.BackColor = Color.SkyBlue;
            Cancle_button.FlatStyle = FlatStyle.Popup;
            Cancle_button.ForeColor = Color.White;
            Cancle_button.Location = new Point(360, 353);
            Cancle_button.Margin = new Padding(4);
            Cancle_button.Name = "Cancle_button";
            Cancle_button.Size = new Size(153, 40);
            Cancle_button.TabIndex = 3;
            Cancle_button.Text = "취소";
            Cancle_button.UseVisualStyleBackColor = false;
            Cancle_button.Click += Cancle_button_Click;
            // 
            // night_textBox
            // 
            night_textBox.BorderStyle = BorderStyle.FixedSingle;
            night_textBox.Location = new Point(28, 107);
            night_textBox.Margin = new Padding(4);
            night_textBox.Name = "night_textBox";
            night_textBox.ReadOnly = true;
            night_textBox.Size = new Size(143, 27);
            night_textBox.TabIndex = 4;
            night_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // total_Money_textBox
            // 
            total_Money_textBox.BorderStyle = BorderStyle.FixedSingle;
            total_Money_textBox.Location = new Point(123, 31);
            total_Money_textBox.Margin = new Padding(4);
            total_Money_textBox.Name = "total_Money_textBox";
            total_Money_textBox.ReadOnly = true;
            total_Money_textBox.Size = new Size(341, 27);
            total_Money_textBox.TabIndex = 7;
            // 
            // total_groupBox
            // 
            total_groupBox.Controls.Add(detail_text_label);
            total_groupBox.Controls.Add(total_Money_textBox);
            total_groupBox.Controls.Add(additional_allowance_label);
            total_groupBox.Location = new Point(28, 145);
            total_groupBox.Margin = new Padding(4);
            total_groupBox.Name = "total_groupBox";
            total_groupBox.Padding = new Padding(4);
            total_groupBox.Size = new Size(485, 200);
            total_groupBox.TabIndex = 9;
            total_groupBox.TabStop = false;
            total_groupBox.Text = "상세 정보";
            // 
            // detail_text_label
            // 
            detail_text_label.AutoSize = true;
            detail_text_label.Font = new Font("맑은 고딕", 8F, FontStyle.Regular, GraphicsUnit.Point);
            detail_text_label.Location = new Point(12, 91);
            detail_text_label.Margin = new Padding(4, 0, 4, 0);
            detail_text_label.Name = "detail_text_label";
            detail_text_label.Size = new Size(456, 95);
            detail_text_label.TabIndex = 10;
            detail_text_label.Text = "● 월급계산\r\n  - 휴일 근로 있을 때,\r\n    휴일 근로 * (시급*1.5) + 연장 근로 * (시급/2) + 야간근로 * (시급/2)\r\n  - 휴일 근로 없을 때,\r\n      일반 근로 * 시급 + 연장 근로 * (시급/2) + 야간근로 * (시급*1.5)";
            // 
            // additional_allowance_label
            // 
            additional_allowance_label.AutoSize = true;
            additional_allowance_label.Location = new Point(27, 33);
            additional_allowance_label.Margin = new Padding(4, 0, 4, 0);
            additional_allowance_label.Name = "additional_allowance_label";
            additional_allowance_label.Size = new Size(89, 20);
            additional_allowance_label.TabIndex = 8;
            additional_allowance_label.Text = "총 수가수당";
            // 
            // night_label
            // 
            night_label.AutoSize = true;
            night_label.Location = new Point(44, 83);
            night_label.Margin = new Padding(4, 0, 4, 0);
            night_label.Name = "night_label";
            night_label.Size = new Size(109, 20);
            night_label.TabIndex = 10;
            night_label.Text = "야간 근로 시간";
            // 
            // dayoff_label
            // 
            dayoff_label.AutoSize = true;
            dayoff_label.Location = new Point(213, 83);
            dayoff_label.Margin = new Padding(4, 0, 4, 0);
            dayoff_label.Name = "dayoff_label";
            dayoff_label.Size = new Size(109, 20);
            dayoff_label.TabIndex = 11;
            dayoff_label.Text = "휴일 근로 시간";
            // 
            // extension_label
            // 
            extension_label.AutoSize = true;
            extension_label.Location = new Point(383, 83);
            extension_label.Margin = new Padding(4, 0, 4, 0);
            extension_label.Name = "extension_label";
            extension_label.Size = new Size(109, 20);
            extension_label.TabIndex = 12;
            extension_label.Text = "연장 근로 시간";
            // 
            // holiday_textBox
            // 
            holiday_textBox.BorderStyle = BorderStyle.FixedSingle;
            holiday_textBox.Location = new Point(198, 107);
            holiday_textBox.Margin = new Padding(4);
            holiday_textBox.Name = "holiday_textBox";
            holiday_textBox.ReadOnly = true;
            holiday_textBox.Size = new Size(143, 27);
            holiday_textBox.TabIndex = 13;
            holiday_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // overtime_textBox
            // 
            overtime_textBox.BorderStyle = BorderStyle.FixedSingle;
            overtime_textBox.Location = new Point(369, 107);
            overtime_textBox.Margin = new Padding(4);
            overtime_textBox.Name = "overtime_textBox";
            overtime_textBox.ReadOnly = true;
            overtime_textBox.Size = new Size(143, 27);
            overtime_textBox.TabIndex = 14;
            overtime_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // end_label
            // 
            end_label.AutoSize = true;
            end_label.Location = new Point(360, 20);
            end_label.Margin = new Padding(4, 0, 4, 0);
            end_label.Name = "end_label";
            end_label.Size = new Size(74, 20);
            end_label.TabIndex = 17;
            end_label.Text = "퇴근 시간";
            // 
            // start_label
            // 
            start_label.AutoSize = true;
            start_label.Location = new Point(105, 19);
            start_label.Margin = new Padding(4, 0, 4, 0);
            start_label.Name = "start_label";
            start_label.Size = new Size(74, 20);
            start_label.TabIndex = 16;
            start_label.Text = "출근 시간";
            // 
            // end_textBox
            // 
            end_textBox.BorderStyle = BorderStyle.FixedSingle;
            end_textBox.Location = new Point(279, 48);
            end_textBox.Margin = new Padding(4);
            end_textBox.Name = "end_textBox";
            end_textBox.PlaceholderText = "20XX-XX-XX XX:XX:00";
            end_textBox.Size = new Size(233, 27);
            end_textBox.TabIndex = 19;
            end_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // start_textBox
            // 
            start_textBox.BorderStyle = BorderStyle.FixedSingle;
            start_textBox.Location = new Point(28, 48);
            start_textBox.Margin = new Padding(4);
            start_textBox.Name = "start_textBox";
            start_textBox.Size = new Size(233, 27);
            start_textBox.TabIndex = 20;
            start_textBox.Text = "20XX-XX-XX XX:XX:00";
            start_textBox.TextAlign = HorizontalAlignment.Center;
            // 
            // select_button
            // 
            select_button.BackColor = Color.SkyBlue;
            select_button.FlatStyle = FlatStyle.Popup;
            select_button.ForeColor = Color.White;
            select_button.Location = new Point(28, 353);
            select_button.Margin = new Padding(4);
            select_button.Name = "select_button";
            select_button.Size = new Size(153, 40);
            select_button.TabIndex = 21;
            select_button.Text = "조회";
            select_button.UseVisualStyleBackColor = false;
            select_button.Click += select_button_Click;
            // 
            // 출근시간_comboBox
            // 
            출근시간_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            출근시간_comboBox.FormattingEnabled = true;
            출근시간_comboBox.Location = new Point(28, 0);
            출근시간_comboBox.Name = "출근시간_comboBox";
            출근시간_comboBox.Size = new Size(233, 28);
            출근시간_comboBox.Sorted = true;
            출근시간_comboBox.TabIndex = 22;
            출근시간_comboBox.SelectedIndexChanged += 출근시간_comboBox_SelectedIndexChanged;
            // 
            // 추가수당신청
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 415);
            Controls.Add(출근시간_comboBox);
            Controls.Add(select_button);
            Controls.Add(start_textBox);
            Controls.Add(end_textBox);
            Controls.Add(end_label);
            Controls.Add(Cancle_button);
            Controls.Add(start_label);
            Controls.Add(overtime_textBox);
            Controls.Add(holiday_textBox);
            Controls.Add(extension_label);
            Controls.Add(dayoff_label);
            Controls.Add(night_label);
            Controls.Add(total_groupBox);
            Controls.Add(night_textBox);
            Controls.Add(Payment_button);
            Margin = new Padding(4);
            Name = "추가수당신청";
            Text = "추가수당신청";
            Load += 추가수당신청_Load;
            total_groupBox.ResumeLayout(false);
            total_groupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Payment_button;
        private Button Cancle_button;
        private TextBox night_textBox;
        private TextBox total_Money_textBox;
        private GroupBox total_groupBox;
        private Label detail_text_label;
        private Label additional_allowance_label;
        private Label night_label;
        private Label dayoff_label;
        private Label extension_label;
        private TextBox holiday_textBox;
        private TextBox overtime_textBox;
        private Label end_label;
        private Label start_label;
        private TextBox end_textBox;
        private TextBox start_textBox;
        private Button select_button;
        private ComboBox 출근시간_comboBox;
    }
}