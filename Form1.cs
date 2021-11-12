using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kieraninvest4u1
{
    public partial class Form1 : Form
    {
        private const decimal b1_OneYearInterestRate = 0.005000M;
        private const decimal b1_ThreeYearInterestRate = 0.006250M;
        private const decimal b1_FiveYearInterestRate = 0.007125M;
        private const decimal b1_TenYearInterestRate = 0.011250M;

        private const decimal a1_OneYearInterestRate = 0.006000M;
        private const decimal a1_ThreeYearInterestRate = 0.007250M;
        private const decimal a1_FiveYearInterestRate = 0.008125M;
        private const decimal a1_TenYearInterestRate = 0.012500M;
        
        private const decimal baseMoney = 100000;


        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            var amount = Convert.ToDecimal(this.InvestmentTxtbox.Text);
            if (amount > 0)
            {
                if (amount <= baseMoney)
                {


                }
                else
                {

                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void InvestmentTxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
