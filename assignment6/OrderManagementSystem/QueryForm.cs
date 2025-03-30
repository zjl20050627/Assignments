using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using assignment5_2;
using static OrderManagementSystem.MainForm;

namespace OrderManagementSystem
{
    public partial class QueryForm: Form
    {
        public QueryType QueryType { get; private set; }
        public string Keyword { get; private set; }
        public decimal MinAmount { get; private set; }
        public decimal MaxAmount { get; private set; }
        public QueryForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbOrderId_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyword.Enabled = rbOrderId.Checked || rbProductName.Checked || rbCustomerName.Checked;
            txtMinAmount.Enabled = rbAmountRange.Checked;
            txtMaxAmount.Enabled = rbAmountRange.Checked;
        }

        private void rbProductName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (rbOrderId.Checked)
            {
                QueryType = QueryType.OrderId;
                Keyword = txtKeyword.Text;
            }
            else if (rbProductName.Checked)
            {
                QueryType = QueryType.ProductName;
                Keyword = txtKeyword.Text;
            }
            else if (rbCustomerName.Checked)
            {
                QueryType = QueryType.CustomerName;
                Keyword = txtKeyword.Text;
            }
            else if (rbAmountRange.Checked)
            {
                QueryType = QueryType.AmountRange;

                decimal min, max;
                if (!decimal.TryParse(txtMinAmount.Text, out min))
                {
                    MessageBox.Show("请输入有效的最小金额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!decimal.TryParse(txtMaxAmount.Text, out max))
                {
                    MessageBox.Show("请输入有效的最大金额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 赋值给属性
                this.MinAmount = min;
                this.MaxAmount = max;

                if (MinAmount > MaxAmount)
                {
                    MessageBox.Show("最小金额不能大于最大金额", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
