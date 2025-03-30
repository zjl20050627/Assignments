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
    public partial class OrderEditForm: Form
    {
        private Order currentOrder;
        private OrderService orderService;
        private BindingSource detailBindingSource = new BindingSource();
        private List<Product> availableProducts = new List<Product>();

        public OrderEditForm(Order order, OrderService service)
        {
            InitializeComponent();
            currentOrder = order;
            orderService = service;
            InitializeData();
            SetupDataBinding();
        }
        private void InitializeData()
        {
            // 初始化一些示例产品
            availableProducts.Add(new Product("P001", "笔记本电脑", 5999m));
            availableProducts.Add(new Product("P002", "鼠标", 99m));
            availableProducts.Add(new Product("P003", "键盘", 199m));
            availableProducts.Add(new Product("P004", "显示器", 1299m));
            availableProducts.Add(new Product("P005", "耳机", 299m));

            cboProduct.DataSource = availableProducts;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "ProductId";

            if (currentOrder == null)
            {
                // 新建订单
                currentOrder = new Order(
                    GenerateOrderId(),
                    new Customer("", "", ""),
                    DateTime.Now);
                Text = "新建订单";
            }
            else
            {
                // 编辑现有订单
                txtOrderId.ReadOnly = true;
                Text = "编辑订单";
            }
        }
        private void SetupDataBinding()
        {
            // 订单基本信息绑定
            txtOrderId.DataBindings.Add("Text", currentOrder, "OrderId");
            txtCustomerId.DataBindings.Add("Text", currentOrder.Customer, "CustomerId");
            txtCustomerName.DataBindings.Add("Text", currentOrder.Customer, "Name");
            txtContactInfo.DataBindings.Add("Text", currentOrder.Customer, "ContactInfo");
            dtpOrderDate.DataBindings.Add("Value", currentOrder, "OrderDate", true, DataSourceUpdateMode.OnPropertyChanged);

            // 订单明细绑定
            detailBindingSource.DataSource = currentOrder.Details;
            dgvDetails.DataSource = detailBindingSource;
            dgvDetails.AutoGenerateColumns = false;

            // 配置明细列
            dgvDetails.Columns.Clear();
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                //DataPropertyName = "Product.Name",
                DataPropertyName = "ProductName",

                HeaderText = "商品名称",
                Name = "colProductName",
                Width = 150
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                //DataPropertyName = "Product.Price",
                DataPropertyName = "ProductPrice",

                HeaderText = "单价",
                Name = "colPrice",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Name = "colQuantity",
                Width = 80
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "小计",
                Name = "colSubtotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            // 绑定总金额
            lblTotalAmount.DataBindings.Add("Text", currentOrder, "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0m, "C2");
        }
        private string GenerateOrderId()
        {
            return "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem == null)
            {
                MessageBox.Show("请选择商品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("请输入有效的数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var product = (Product)cboProduct.SelectedItem;
                var detail = new OrderDetails(product, quantity);
                currentOrder.AddDetail(detail);
                detailBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加明细失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的明细", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var detail = (OrderDetails)dgvDetails.SelectedRows[0].DataBoundItem;
                currentOrder.RemoveDetail(detail.Product);
                detailBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除明细失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* private void btnSave_Click(object sender, EventArgs e)
         {
             if (string.IsNullOrWhiteSpace(txtOrderId.Text))
             {
                 MessageBox.Show("请输入订单号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }

             if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
             {
                 MessageBox.Show("请输入客户名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }

             if (currentOrder.Details.Count == 0)
             {
                 MessageBox.Show("请添加至少一个订单明细", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }

             try
             {
                 if (orderService.GetAllOrders().Any(o => o.OrderId == currentOrder.OrderId && currentOrder != o))
                 {
                     // 检查是否已存在相同订单号的其他订单
                     MessageBox.Show("订单号已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 if (currentOrder.OrderId == "")
                 {
                     // 新建订单
                     orderService.AddOrder(currentOrder);
                 }
                 else
                 {
                     // 更新订单
                     orderService.UpdateOrder(currentOrder);
                 }

                 DialogResult = DialogResult.OK;
                 Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"保存订单失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 检查必填字段
                if (string.IsNullOrEmpty(txtOrderId.Text))
                {
                    MessageBox.Show("订单号不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 判断是新增还是修改
                bool isNewOrder = !orderService.GetAllOrders().Any(o => o.OrderId == currentOrder.OrderId);

                if (isNewOrder)
                {
                    orderService.AddOrder(currentOrder);
                    MessageBox.Show("订单新增成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    orderService.UpdateOrder(currentOrder);
                    MessageBox.Show("订单修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存订单失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
