namespace OrderManagementSystem
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaxAmount = new System.Windows.Forms.TextBox();
            this.txtMinAmount = new System.Windows.Forms.TextBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.rbAmountRange = new System.Windows.Forms.RadioButton();
            this.rbCustomerName = new System.Windows.Forms.RadioButton();
            this.rbProductName = new System.Windows.Forms.RadioButton();
            this.rbOrderId = new System.Windows.Forms.RadioButton();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaxAmount);
            this.groupBox1.Controls.Add(this.txtMinAmount);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.rbAmountRange);
            this.groupBox1.Controls.Add(this.rbCustomerName);
            this.groupBox1.Controls.Add(this.rbProductName);
            this.groupBox1.Controls.Add(this.rbOrderId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMaxAmount
            // 
            this.txtMaxAmount.Location = new System.Drawing.Point(312, 141);
            this.txtMaxAmount.Name = "txtMaxAmount";
            this.txtMaxAmount.Size = new System.Drawing.Size(100, 25);
            this.txtMaxAmount.TabIndex = 8;
            // 
            // txtMinAmount
            // 
            this.txtMinAmount.Location = new System.Drawing.Point(163, 142);
            this.txtMinAmount.Name = "txtMinAmount";
            this.txtMinAmount.Size = new System.Drawing.Size(100, 25);
            this.txtMinAmount.TabIndex = 7;
            this.txtMinAmount.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(163, 25);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(100, 25);
            this.txtKeyword.TabIndex = 4;
            // 
            // rbAmountRange
            // 
            this.rbAmountRange.AutoSize = true;
            this.rbAmountRange.Location = new System.Drawing.Point(6, 142);
            this.rbAmountRange.Name = "rbAmountRange";
            this.rbAmountRange.Size = new System.Drawing.Size(103, 19);
            this.rbAmountRange.TabIndex = 3;
            this.rbAmountRange.TabStop = true;
            this.rbAmountRange.Text = "按金额范围";
            this.rbAmountRange.UseVisualStyleBackColor = true;
            // 
            // rbCustomerName
            // 
            this.rbCustomerName.AutoSize = true;
            this.rbCustomerName.Location = new System.Drawing.Point(7, 102);
            this.rbCustomerName.Name = "rbCustomerName";
            this.rbCustomerName.Size = new System.Drawing.Size(103, 19);
            this.rbCustomerName.TabIndex = 2;
            this.rbCustomerName.TabStop = true;
            this.rbCustomerName.Text = "按客户名称";
            this.rbCustomerName.UseVisualStyleBackColor = true;
            // 
            // rbProductName
            // 
            this.rbProductName.AutoSize = true;
            this.rbProductName.Location = new System.Drawing.Point(6, 65);
            this.rbProductName.Name = "rbProductName";
            this.rbProductName.Size = new System.Drawing.Size(103, 19);
            this.rbProductName.TabIndex = 1;
            this.rbProductName.TabStop = true;
            this.rbProductName.Text = "按商品名称";
            this.rbProductName.UseVisualStyleBackColor = true;
            this.rbProductName.CheckedChanged += new System.EventHandler(this.rbProductName_CheckedChanged);
            // 
            // rbOrderId
            // 
            this.rbOrderId.AutoSize = true;
            this.rbOrderId.Location = new System.Drawing.Point(7, 25);
            this.rbOrderId.Name = "rbOrderId";
            this.rbOrderId.Size = new System.Drawing.Size(88, 19);
            this.rbOrderId.TabIndex = 0;
            this.rbOrderId.TabStop = true;
            this.rbOrderId.Text = "按订单号";
            this.rbOrderId.UseVisualStyleBackColor = true;
            this.rbOrderId.CheckedChanged += new System.EventHandler(this.rbOrderId_CheckedChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(13, 206);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "QueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询订单";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAmountRange;
        private System.Windows.Forms.RadioButton rbCustomerName;
        private System.Windows.Forms.RadioButton rbProductName;
        private System.Windows.Forms.RadioButton rbOrderId;
        private System.Windows.Forms.TextBox txtMaxAmount;
        private System.Windows.Forms.TextBox txtMinAmount;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCancel;
    }
}