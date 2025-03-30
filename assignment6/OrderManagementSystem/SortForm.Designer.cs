namespace OrderManagementSystem
{
    partial class SortForm
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
            this.rbOrderId = new System.Windows.Forms.RadioButton();
            this.rbTotalAmount = new System.Windows.Forms.RadioButton();
            this.rbOrderDate = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOrderDate);
            this.groupBox1.Controls.Add(this.rbTotalAmount);
            this.groupBox1.Controls.Add(this.rbOrderId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排序方式";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbOrderId
            // 
            this.rbOrderId.AutoSize = true;
            this.rbOrderId.Location = new System.Drawing.Point(18, 33);
            this.rbOrderId.Name = "rbOrderId";
            this.rbOrderId.Size = new System.Drawing.Size(88, 19);
            this.rbOrderId.TabIndex = 0;
            this.rbOrderId.TabStop = true;
            this.rbOrderId.Text = "按订单号";
            this.rbOrderId.UseVisualStyleBackColor = true;
            // 
            // rbTotalAmount
            // 
            this.rbTotalAmount.AutoSize = true;
            this.rbTotalAmount.Location = new System.Drawing.Point(18, 76);
            this.rbTotalAmount.Name = "rbTotalAmount";
            this.rbTotalAmount.Size = new System.Drawing.Size(88, 19);
            this.rbTotalAmount.TabIndex = 1;
            this.rbTotalAmount.TabStop = true;
            this.rbTotalAmount.Text = "按总金额";
            this.rbTotalAmount.UseVisualStyleBackColor = true;
            // 
            // rbOrderDate
            // 
            this.rbOrderDate.AutoSize = true;
            this.rbOrderDate.Location = new System.Drawing.Point(18, 114);
            this.rbOrderDate.Name = "rbOrderDate";
            this.rbOrderDate.Size = new System.Drawing.Size(103, 19);
            this.rbOrderDate.TabIndex = 2;
            this.rbOrderDate.TabStop = true;
            this.rbOrderDate.Text = "按订单日期";
            this.rbOrderDate.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 178);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(138, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 244);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SortForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "排序订单";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOrderDate;
        private System.Windows.Forms.RadioButton rbTotalAmount;
        private System.Windows.Forms.RadioButton rbOrderId;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}