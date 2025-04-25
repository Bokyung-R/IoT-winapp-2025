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
                MessageBox.Show($"�б� ���� : {ex.Message}", "�����б�", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = LblDay.Text;
                File.WriteAllText(filePath, TxtDiary.Text);

                MessageBox.Show("�ϱⰡ ����Ǿ����ϴ�.", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"���� ���� : {ex.Message}", "��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
