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

namespace OrderManagementSystem
{
    public partial class MainForm : Form
    {
        private OrderService orderService = new OrderService();
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource detailBindingSource = new BindingSource();
        public MainForm()
        {
            InitializeComponent();
            InitializeDataBinding();
            LoadOrders();
        }
        private void InitializeDataBinding()
        {
            // 订单列表绑定
            orderBindingSource.DataSource = typeof(List<Order>);
            dgvOrders.DataSource = orderBindingSource;
            dgvOrders.AutoGenerateColumns = false;

            // 订单明细绑定
            detailBindingSource.DataSource = orderBindingSource;
            detailBindingSource.DataMember = "Details";
            dgvOrderDetails.DataSource = detailBindingSource;
            dgvOrderDetails.AutoGenerateColumns = false;

            // 设置DataGridView列
            ConfigureOrderGridColumns();
            ConfigureDetailGridColumns();
        }
        private void ConfigureOrderGridColumns()
        {
            dgvOrders.Columns.Clear();
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "订单号",
                Name = "colOrderId",
                Width = 120
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                //DataPropertyName = "Customer.Name",
                DataPropertyName = "CustomerName",

                HeaderText = "客户名称",
                Name = "colCustomerName",
                Width = 150
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "订单日期",
                Name = "colOrderDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "总金额",
                Name = "colTotalAmount",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void ConfigureDetailGridColumns()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                //DataPropertyName = "Product.Name",
                DataPropertyName = "ProductName",
                HeaderText = "商品名称",
                Name = "colProductName",
                Width = 150
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                //DataPropertyName = "Product.Price",
                DataPropertyName = "ProductPrice",
                HeaderText = "单价",
                Name = "colPrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Name = "colQuantity",
                Width = 80
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "小计",
                Name = "colSubtotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }
        private void LoadOrders()
        {
            try
            {
                orderBindingSource.DataSource = orderService.GetAllOrders();
                lblStatus.Text = $"共 {orderBindingSource.Count} 条订单";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 设置窗口初始大小和布局
            this.WindowState = FormWindowState.Maximized;
        }
        /*private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // 调整控件大小以适应窗口变化
            int margin = 10;
            int buttonHeight = 40;
            int statusHeight = 30;

            panelButtons.Top = margin;
            panelButtons.Left = margin;
            panelButtons.Width = this.ClientSize.Width - 2 * margin;

            dgvOrders.Top = panelButtons.Bottom + margin;
            dgvOrders.Left = margin;
            dgvOrders.Width = this.ClientSize.Width - 2 * margin;
            dgvOrders.Height = (this.ClientSize.Height - panelButtons.Bottom - statusHeight - 4 * margin) / 2;

            lblDetails.Top = dgvOrders.Bottom + margin;
            lblDetails.Left = margin;

            dgvOrderDetails.Top = lblDetails.Bottom + margin / 2;
            dgvOrderDetails.Left = margin;
            dgvOrderDetails.Width = this.ClientSize.Width - 2 * margin;
            dgvOrderDetails.Height = this.ClientSize.Height - dgvOrderDetails.Top - statusHeight - 2 * margin;

            lblStatus.Top = this.ClientSize.Height - statusHeight - margin;
            lblStatus.Left = margin;
            lblStatus.Width = this.ClientSize.Width - 2 * margin;
        }
    }*/
    public enum QueryType
    {
        OrderId,
        ProductName,
        CustomerName,
        AmountRange
    }
        public enum SortType
        {
            OrderId,
            TotalAmount,
            OrderDate
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOrders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            var sortForm = new SortForm();
            if (sortForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (sortForm.SortType)
                    {
                        case SortType.OrderId:
                            orderService.SortOrders();
                            break;
                        case SortType.TotalAmount:
                            orderService.SortOrders((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
                            break;
                        case SortType.OrderDate:
                            orderService.SortOrders((x, y) => x.OrderDate.CompareTo(y.OrderDate));
                            break;
                    }

                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"排序失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var queryForm = new QueryForm();
            if (queryForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<Order> result = null;
                    switch (queryForm.QueryType)
                    {
                        case QueryType.OrderId:
                            result = orderService.QueryByOrderId(queryForm.Keyword);
                            break;
                        case QueryType.ProductName:
                            result = orderService.QueryByProductName(queryForm.Keyword);
                            break;
                        case QueryType.CustomerName:
                            result = orderService.QueryByCustomer(queryForm.Keyword);
                            break;
                        case QueryType.AmountRange:
                            result = orderService.QueryByAmountRange(queryForm.MinAmount, queryForm.MaxAmount);
                            break;
                    }

                    if (result != null)
                    {
                        orderBindingSource.DataSource = result;
                        lblStatus.Text = $"找到 {result.Count} 条订单";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"查询失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current == null)
            {
                MessageBox.Show("请先选择要删除的订单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确定要删除选中的订单吗?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var currentOrder = (Order)orderBindingSource.Current;
                    orderService.RemoveOrder(currentOrder.OrderId);
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除订单失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current == null)
            {
                MessageBox.Show("请先选择要修改的订单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentOrder = (Order)orderBindingSource.Current;
            var editForm = new OrderEditForm(currentOrder, orderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new OrderEditForm(null, orderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }
    }
}
