using System.Runtime.CompilerServices;

namespace WinFormsApp_Practice
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string filePath = $"{CalDiary.SelectionStart.Year.ToString()}_{CalDiary.SelectionStart.Month.ToString()}_{CalDiary.SelectionStart.Day.ToString()}";
            LblDay.Text = filePath;

            try
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TxtDiary.Text = content;
                }
                else
                {
                    TxtDiary.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"읽기 실패 : {ex.Message}", "파일읽기", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = LblDay.Text;
                File.WriteAllText(filePath, TxtDiary.Text);

                MessageBox.Show("일기가 저장되었습니다.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 실패 : {ex.Message}", "파일저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
