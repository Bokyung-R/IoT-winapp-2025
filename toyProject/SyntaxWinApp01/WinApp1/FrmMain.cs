using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            CboInOut.SelectedIndex = 0;
            LoadHistory();
        }

        private void DtpDay_ValueChanged(object sender, EventArgs e)
        {
            LoadHistory();
        }
         
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtValue.Text) || string.IsNullOrWhiteSpace(TxtPrice.Text))
            {
                MessageBox.Show("�׸�� �ݾ��� ��� �Է����ּ���.", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!int.TryParse(TxtPrice.Text, out int price))
            {
                MessageBox.Show("�ݾ��� ���ڸ� �Է� �����մϴ�.", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // �� �κ� ���� �ٲٰ����
            string line = $"{CboInOut.SelectedItem} : {TxtValue.Text} {TxtPrice.Text}��";
            TxtHistory.Text += line + Environment.NewLine;

            string filePath = DtpDay.Value.ToString("yyyy_MM_dd");
            File.WriteAllText(filePath, TxtHistory.Text);

            TxtValue.Text = string.Empty;
            TxtPrice.Text = string.Empty;

            CalculateTotals();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            string filePath = DtpDay.Value.ToString("yyyy_MM_dd");

            File.WriteAllText(filePath, TxtHistory.Text);

            CalculateTotals();
        }
        private void LoadHistory()
        {
            string filePath = DtpDay.Value.ToString("yyyy_MM_dd");

            try
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    TxtHistory.Text = content;
                }
                else
                {
                    TxtHistory.Text = "";
                }

                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�б� ���� : {ex.Message}", "�����б�", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            int income = 0;
            int expenditure = 0;

            string[] rawLines = TxtHistory.Text.Split('\n');

            foreach (string rawLine in rawLines)
            {
                string line = rawLine.Trim();

                if (string.IsNullOrEmpty(line)) continue;

                if (line.StartsWith("����"))
                {
                    income += ExtractAmount(line);
                }
                else if (line.StartsWith("����"))
                {
                    expenditure += ExtractAmount(line);
                }
            }

            TxtIncome.Text = income.ToString();
            TxtExpenditure.Text = expenditure.ToString();
            TxtTotal.Text = (income - expenditure).ToString();
        }


        private int ExtractAmount(string line)
        {
            try
            {
                int startIndex = line.LastIndexOf(' ') + 1;
                string numberPart = line.Substring(startIndex).Replace("��", "");

                if (int.TryParse(numberPart, out int result))
                {
                    return result;
                }
            }
            catch
            {
                // ���н� 0���� ó��
            }
            return 0;
        }

    }
}
