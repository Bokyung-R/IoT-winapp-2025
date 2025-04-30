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
                MessageBox.Show("항목과 금액을 모두 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!int.TryParse(TxtPrice.Text, out int price))
            {
                MessageBox.Show("금액은 숫자만 입력 가능합니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 이 부분 형식 바꾸고싶음
            string line = $"{CboInOut.SelectedItem} : {TxtValue.Text} {TxtPrice.Text}원";
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
                MessageBox.Show($"읽기 실패 : {ex.Message}", "파일읽기", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (line.StartsWith("수입"))
                {
                    income += ExtractAmount(line);
                }
                else if (line.StartsWith("지출"))
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
                string numberPart = line.Substring(startIndex).Replace("원", "");

                if (int.TryParse(numberPart, out int result))
                {
                    return result;
                }
            }
            catch
            {
                // 실패시 0으로 처리
            }
            return 0;
        }

    }
}
