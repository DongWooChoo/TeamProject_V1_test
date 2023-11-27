namespace TeamProject_test_v1
{
    partial class 업무마스터_수정
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
            modify_button = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            after_small_textbox = new TextBox();
            label4 = new Label();
            after_mid_textbox = new TextBox();
            label5 = new Label();
            after_big_textbox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            before_big_combo = new ComboBox();
            before_mid_combo = new ComboBox();
            before_small_combo = new ComboBox();
            SuspendLayout();
            // 
            // modify_button
            // 
            modify_button.Location = new Point(470, 180);
            modify_button.Name = "modify_button";
            modify_button.Size = new Size(94, 36);
            modify_button.TabIndex = 15;
            modify_button.Text = "수정하기";
            modify_button.UseVisualStyleBackColor = true;
            modify_button.Click += modify_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(771, 48);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 12;
            label3.Text = "소분류";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(470, 48);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 10;
            label2.Text = "중분류";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(171, 47);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 8;
            label1.Text = "대분류";
            // 
            // after_small_textbox
            // 
            after_small_textbox.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            after_small_textbox.Location = new Point(858, 118);
            after_small_textbox.Name = "after_small_textbox";
            after_small_textbox.Size = new Size(170, 32);
            after_small_textbox.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(771, 121);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 20;
            label4.Text = "소분류";
            // 
            // after_mid_textbox
            // 
            after_mid_textbox.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            after_mid_textbox.Location = new Point(560, 120);
            after_mid_textbox.Name = "after_mid_textbox";
            after_mid_textbox.Size = new Size(170, 32);
            after_mid_textbox.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(470, 121);
            label5.Name = "label5";
            label5.Size = new Size(69, 25);
            label5.TabIndex = 18;
            label5.Text = "중분류";
            // 
            // after_big_textbox
            // 
            after_big_textbox.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            after_big_textbox.Location = new Point(260, 118);
            after_big_textbox.Name = "after_big_textbox";
            after_big_textbox.Size = new Size(170, 32);
            after_big_textbox.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(171, 120);
            label6.Name = "label6";
            label6.Size = new Size(69, 25);
            label6.TabIndex = 16;
            label6.Text = "대분류";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("맑은 고딕", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(40, 43);
            label7.Name = "label7";
            label7.Size = new Size(89, 32);
            label7.TabIndex = 22;
            label7.Text = "수정 전";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("맑은 고딕", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(40, 113);
            label8.Name = "label8";
            label8.Size = new Size(89, 32);
            label8.TabIndex = 23;
            label8.Text = "수정 후";
            // 
            // before_big_combo
            // 
            before_big_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            before_big_combo.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            before_big_combo.FormattingEnabled = true;
            before_big_combo.Location = new Point(260, 43);
            before_big_combo.Name = "before_big_combo";
            before_big_combo.Size = new Size(170, 33);
            before_big_combo.TabIndex = 24;
            before_big_combo.SelectedIndexChanged += big_category_combobox_SelectedIndexChanged;
            before_big_combo.Click += big_category_combobox_Click;
            // 
            // before_mid_combo
            // 
            before_mid_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            before_mid_combo.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            before_mid_combo.FormattingEnabled = true;
            before_mid_combo.Location = new Point(560, 42);
            before_mid_combo.Name = "before_mid_combo";
            before_mid_combo.Size = new Size(170, 33);
            before_mid_combo.TabIndex = 25;
            before_mid_combo.SelectedIndexChanged += mid_category_combobox_SelectedIndexChanged;
            // 
            // before_small_combo
            // 
            before_small_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            before_small_combo.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            before_small_combo.FormattingEnabled = true;
            before_small_combo.Location = new Point(858, 44);
            before_small_combo.Name = "before_small_combo";
            before_small_combo.Size = new Size(170, 33);
            before_small_combo.TabIndex = 26;
            // 
            // 업무마스터_수정
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 253);
            Controls.Add(before_small_combo);
            Controls.Add(before_mid_combo);
            Controls.Add(before_big_combo);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(after_small_textbox);
            Controls.Add(label4);
            Controls.Add(after_mid_textbox);
            Controls.Add(label5);
            Controls.Add(after_big_textbox);
            Controls.Add(label6);
            Controls.Add(modify_button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "업무마스터_수정";
            Text = "업무마스터_수정";
            FormClosing += 업무마스터_수정_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button modify_button;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox after_small_textbox;
        private Label label4;
        private TextBox after_mid_textbox;
        private Label label5;
        private TextBox after_big_textbox;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox before_big_combo;
        private ComboBox before_mid_combo;
        private ComboBox before_small_combo;
    }
}