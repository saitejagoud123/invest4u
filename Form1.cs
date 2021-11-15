using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kieraninvest4u1
{
    public partial class Form1 : Form
    {
        private const double b1_OneYearInterestRate = 0.005000;
        private const double b1_ThreeYearInterestRate = 0.006250;
        private const double b1_FiveYearInterestRate = 0.007125;
        private const double b1_TenYearInterestRate = 0.011250;

        private const double a1_OneYearInterestRate = 0.006000;
        private const double a1_ThreeYearInterestRate = 0.007250;
        private const double a1_FiveYearInterestRate = 0.008125;
        private const double a1_TenYearInterestRate = 0.012500;

        private const double baseMoney = 100000;
        private static Random random = new Random();

        private Investor investor = null;
        private int termSelected = 1;

        private const string fileName = "InvestmentBook.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var amount = Convert.ToDouble(this.InvestmentTxtbox.Text);
            if (amount > 0)
            {
                if (amount <= baseMoney)
                {
                    var b1_OneYear = CalculateCompoundInterest(amount, 1, b1_OneYearInterestRate);
                    var b1_ThreeYear = CalculateCompoundInterest(amount, 3, b1_ThreeYearInterestRate);
                    var b1_FiveYear = CalculateCompoundInterest(amount, 5, b1_FiveYearInterestRate);
                    var b1_TenYear = CalculateCompoundInterest(amount, 10, b1_TenYearInterestRate);

                    ListViewItem item;
                    item = new ListViewItem(new string[] { amount.ToString(), b1_OneYearInterestRate.ToString(), (b1_OneYear - amount).ToString("n2"), b1_OneYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), b1_ThreeYearInterestRate.ToString(), (b1_ThreeYear - amount).ToString("n2"), b1_ThreeYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), b1_FiveYearInterestRate.ToString(), (b1_FiveYear - amount).ToString("n2"), b1_FiveYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), b1_TenYearInterestRate.ToString(), (b1_TenYear - amount).ToString("n2"), b1_TenYear.ToString() });
                    listView1.Items.Add(item);
                }
                else
                {
                    var a1_OneYear = CalculateCompoundInterest(amount, 1, a1_OneYearInterestRate);
                    var a1_ThreeYear = CalculateCompoundInterest(amount, 3, a1_ThreeYearInterestRate);
                    var a1_FiveYear = CalculateCompoundInterest(amount, 5, a1_FiveYearInterestRate);
                    var a1_TenYear = CalculateCompoundInterest(amount, 10, a1_TenYearInterestRate);

                    ListViewItem item;

                    item = new ListViewItem(new string[] { amount.ToString(), a1_OneYearInterestRate.ToString(), (a1_OneYear - amount).ToString("n2"), a1_OneYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), a1_ThreeYearInterestRate.ToString(), (a1_ThreeYear - amount).ToString("n2"), a1_ThreeYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), a1_FiveYearInterestRate.ToString(), (a1_FiveYear - amount).ToString("n2"), a1_FiveYear.ToString() });
                    listView1.Items.Add(item);

                    item = new ListViewItem(new string[] { amount.ToString(), a1_TenYearInterestRate.ToString(), (a1_TenYear - amount).ToString("n2"), a1_TenYear.ToString() });
                    listView1.Items.Add(item);
                }
            }
        }

        private double CalculateCompoundInterest(double principal, int tenure, double interestRate)
        {
            //Using the formula A = P(1 + r/n)nt
            var part = 1 + (interestRate / 12);
            var total = principal * Math.Pow(part, (12 * tenure));

            return Math.Round(total, 2);
        }



        private void InvestmentTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvestmentGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private double GetInterestRate(int tenure, double amount)
        {
            double interestRate = 0;
            if (amount <= baseMoney)
            {
                switch (tenure)
                {
                    case 1:
                        interestRate = b1_OneYearInterestRate;
                        break;
                    case 3:
                        interestRate = b1_ThreeYearInterestRate;
                        break;
                    case 5:
                        interestRate = b1_FiveYearInterestRate;
                        break;
                    case 10:
                        interestRate = b1_TenYearInterestRate;
                        break;
                }
            }
            else
            {
                switch (tenure)
                {
                    case 1:
                        interestRate = a1_OneYearInterestRate;
                        break;
                    case 3:
                        interestRate = a1_ThreeYearInterestRate;
                        break;
                    case 5:
                        interestRate = a1_FiveYearInterestRate;
                        break;
                    case 10:
                        interestRate = a1_TenYearInterestRate;
                        break;
                }
            }

            return interestRate;
        }




        private void ProceedButton_Click(object sender, EventArgs e)
        {
            //var name = ClientTxtBox.Text;
            //var phoneNo = phoneTxtBox.Text;
            //var emailId = EmailTxtBox.Text;
            //var tenureYears = termSelected;
            //var transactionId = RandomString(8);
            //var amount = Convert.ToDouble(this.InvestmentTxtbox.Text);
            //var interestRate = GetInterestRate(tenureYears, amount);
            //var totalEarned = CalculateCompoundInterest(amount, tenureYears, interestRate);
            //var interestEarned = Math.Round((totalEarned - amount), 2);


            //MessageBox.Show(
            //    $"Name : {name} {Environment.NewLine}" +
            //    $"PhoneNo : {phoneNo} {Environment.NewLine}" +
            //    $"Email Id : {emailId} {Environment.NewLine}" +
            //    $"Transaction Id : {transactionId} {Environment.NewLine}" +
            //    $"Invested Amount : {amount} {Environment.NewLine}" +
            //    $"Interest Rate : {interestRate} {Environment.NewLine}" +
            //    $"Tenure in Years : {tenureYears} {Environment.NewLine}" +
            //    $"Interest Earned : {interestEarned} {Environment.NewLine}" +
            //    $"Total Earned : {totalEarned} {Environment.NewLine}"
            //    );

        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void InvestorDetailsGroupBox_Enter(object sender, EventArgs e)
        {

        }
        private void termRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                termSelected = 1;
            }
            else if (radioButton2.Checked)
            {
                termSelected = 3;
            }
            else if (radioButton3.Checked)
            {
                termSelected = 5;
            }
            else if (radioButton4.Checked)
            {
                termSelected = 10;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to save transaction?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var name = ClientTxtBox.Text;
                var phoneNo = phoneTxtBox.Text;
                var emailId = EmailTxtBox.Text;
                var tenureYears = termSelected;
                var transactionId = RandomString(8);
                var amount = Convert.ToDouble(this.InvestmentTxtbox.Text);
                var interestRate = GetInterestRate(tenureYears, amount);
                var totalEarned = CalculateCompoundInterest(amount, tenureYears, interestRate);
                var interestEarned = Math.Round((totalEarned - amount), 2);

                investor = new Investor()
                {
                    Amount = amount,
                    EmailId = emailId,
                    InterestAmount = interestEarned,
                    InterestRate = interestRate,
                    Name = name,
                    PhoneNo = phoneNo,
                    Tenure = tenureYears,
                    Total = totalEarned,
                    TransactionDate = DateTime.Now,
                    TransactionId = transactionId
                };

                using (var streamWriter = File.AppendText(fileName))
                {
                    streamWriter.WriteLine(investor.Name);
                    streamWriter.WriteLine(investor.PhoneNo);
                    streamWriter.WriteLine(investor.EmailId);
                    streamWriter.WriteLine(investor.TransactionId);
                    streamWriter.WriteLine(investor.TransactionDate);
                    streamWriter.WriteLine(investor.Amount);
                    streamWriter.WriteLine(investor.Tenure);
                    streamWriter.WriteLine(investor.InterestRate);
                    streamWriter.WriteLine(investor.InterestAmount);
                    streamWriter.WriteLine(investor.Total);

                    //  var clientObj = JsonConvert.SerializeObject(investor);
                    //  streamWriter.WriteLine(clientObj);
                    streamWriter.Close();
                }
            }
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            double averageInvestment = 0;
            double totalInvestment = 0;
            double totalInterest = 0;
            int averageTerm = 0;

            int investmentCount = 0;
            int location = 1;
            using (var streamReader = File.OpenText(fileName))
            {
                while (!streamReader.EndOfStream)
                {
                    if (location % 6 == 0)
                    {
                        totalInvestment += Convert.ToDouble(streamReader.ReadLine());
                    }
                    else if (location % 7 == 0)
                    {
                        averageTerm += Convert.ToInt32(streamReader.ReadLine());
                    }
                    else if (location % 9 == 0)
                    {
                        totalInterest += Convert.ToDouble(streamReader.ReadLine());
                    }
                    else
                    {
                        streamReader.ReadLine();
                    }
                    if (location == 10)
                    {
                        investmentCount++;
                        location = 1;
                    }
                    else
                        location++;

                    // var clientObj = JsonConvert.DeserializeObject<Investor>(streamReader.ReadLine());
                    //  inves.Add(clientObj);
                }
                streamReader.Close();
            }
            if (investmentCount > 0) {
                averageInvestment = totalInvestment / investmentCount;
                averageTerm /= investmentCount;
            }

            MessageBox.Show(
                $"Total Investment : {totalInvestment} {Environment.NewLine}" +
                $"Total Interest : {totalInterest} {Environment.NewLine}" +
                $"Average Term : {averageTerm} {Environment.NewLine}" +
                $"Average Investment : {averageInvestment.ToString("n2")} {Environment.NewLine}" +
                $"Total Transaction Count : {investmentCount} {Environment.NewLine}");
        }
    }

    public class Investor
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public int Tenure { get; set; }
        public double InterestAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Total { get; set; }
    }
}

