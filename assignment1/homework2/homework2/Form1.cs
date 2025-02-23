using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
           // 获取输入的数字
            if (double.TryParse(txtNumber1.Text, out double num1) &&
                double.TryParse(txtNumber2.Text, out double num2))
            {
                // 获取运算符
                string op = cmbOperator.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(op))
                {
                    MessageBox.Show("请选择一个运算符！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double result = 0;
                bool isValidOperation = true;

                // 根据运算符执行计算
                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            MessageBox.Show("错误：除数不能为零！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isValidOperation = false;
                        }
                        break;
                    default:
                        MessageBox.Show("错误：无效的运算符！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValidOperation = false;
                        break;
                }

                if (isValidOperation)
                {
                    // 显示结果
                    lblResult.Text = $"结果: {result}";
                }
            }
            else
            {
                MessageBox.Show("请输入有效的数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
