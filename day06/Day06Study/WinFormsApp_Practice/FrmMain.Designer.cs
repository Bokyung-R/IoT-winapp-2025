namespace WinFormsApp_Practice
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CalDiary = new MonthCalendar();
            BtnCheck = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            LblDay = new Label();
            BtnSave = new Button();
            TxtDiary = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // CalDiary
            // 
            CalDiary.Location = new Point(12, 28);
            CalDiary.Name = "CalDiary";
            CalDiary.TabIndex = 0;
            // 
            // BtnCheck
            // 
            BtnCheck.Location = new Point(137, 202);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(100, 30);
            BtnCheck.TabIndex = 2;
            BtnCheck.Text = "날짜선택";
            BtnCheck.UseVisualStyleBackColor = true;
            BtnCheck.Click += BtnCheck_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CalDiary);
            groupBox1.Controls.Add(BtnCheck);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(243, 281);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "날짜 선택";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblDay);
            groupBox2.Controls.Add(BtnSave);
            groupBox2.Controls.Add(TxtDiary);
            groupBox2.Location = new Point(261, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(311, 287);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "일기";
            // 
            // LblDay
            // 
            LblDay.AutoSize = true;
            LblDay.Location = new Point(6, 29);
            LblDay.Name = "LblDay";
            LblDay.Size = new Size(85, 15);
            LblDay.TabIndex = 2;
            LblDay.Text = "YYYY_MM_DD";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(205, 251);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(100, 30);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "저장";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // TxtDiary
            // 
            TxtDiary.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            TxtDiary.Location = new Point(6, 47);
            TxtDiary.Multiline = true;
            TxtDiary.Name = "TxtDiary";
            TxtDiary.ScrollBars = ScrollBars.Vertical;
            TxtDiary.Size = new Size(299, 185);
            TxtDiary.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmMain";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar CalDiary;
        private Button BtnCheck;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button BtnSave;
        private TextBox TxtDiary;
        private Label LblDay;
    }
}
