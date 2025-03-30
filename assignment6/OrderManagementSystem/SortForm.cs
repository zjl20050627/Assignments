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
    public partial class SortForm: Form
    {
        public SortType SortType { get; private set; }
        public SortForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbOrderId.Checked)
                SortType = SortType.OrderId;
            else if (rbTotalAmount.Checked)
                SortType = SortType.TotalAmount;
            else if (rbOrderDate.Checked)
                SortType = SortType.OrderDate;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
