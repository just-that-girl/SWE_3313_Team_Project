using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HeavenlySlice
{
    public partial class ReceiptUI : Form
    {
        private Label PhoneLabel;
        private Label TotalLabel;
        private Label PaymentMethodLabel;
        private Label DeliveryLabel;
        private Label TimestampLabel;
        private ListView OrderListView;
        private ColumnHeader Items;
        private ColumnHeader Price;
        private BindingSource bindingSource1;
        private System.ComponentModel.IContainer components;
        private PictureBox SignatureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button PrintButton;
        private Label label1;
        private Label CustomerNameLabel;

        public ReceiptUI(string customerName, string phone, List<Tuple<string, double>> items, double total, bool paidWithCard, bool isDelivery)
        {
            InitializeComponent();

            CustomerNameLabel.Text = $"Customer: {customerName}";
            PhoneLabel.Text = $"Phone Number: {phone}";
            TotalLabel.Text = $"Amount Due: ${total:F2}";
            PaymentMethodLabel.Text = $"Payment Method: {(paidWithCard ? "Credit Card" : "Cash")}";
            DeliveryLabel.Text = $"Order Type: {(isDelivery ? "Delivery" : "Pickup")}";
            TimestampLabel.Text = $"Time: {DateTime.Now:f}";

            OrderListView.View = View.Details;
            OrderListView.Columns.Add("Item", 200);
            OrderListView.Columns.Add("Price", 100);

            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Item1);
                listItem.SubItems.Add($"${item.Item2:F2}");
                OrderListView.Items.Add(listItem);
            }

            SignatureBox.Visible = paidWithCard;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt printed!", "Print", MessageBoxButtons.OK);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Medium Pizza");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptUI));
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.PaymentMethodLabel = new System.Windows.Forms.Label();
            this.DeliveryLabel = new System.Windows.Forms.Label();
            this.TimestampLabel = new System.Windows.Forms.Label();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.Items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SignatureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PrintButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SignatureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Location = new System.Drawing.Point(12, 9);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(129, 16);
            this.CustomerNameLabel.TabIndex = 0;
            this.CustomerNameLabel.Text = "Customer: Jane Doe";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(12, 34);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(181, 16);
            this.PhoneLabel.TabIndex = 1;
            this.PhoneLabel.Text = "Phone Number: 123-456-7890";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(12, 65);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(117, 16);
            this.TotalLabel.TabIndex = 2;
            this.TotalLabel.Text = "Amount Due: $9.99";
            this.TotalLabel.Click += new System.EventHandler(this.TotalLabel_Click);
            // 
            // PaymentMethodLabel
            // 
            this.PaymentMethodLabel.AutoSize = true;
            this.PaymentMethodLabel.Location = new System.Drawing.Point(12, 96);
            this.PaymentMethodLabel.Name = "PaymentMethodLabel";
            this.PaymentMethodLabel.Size = new System.Drawing.Size(181, 16);
            this.PaymentMethodLabel.TabIndex = 3;
            this.PaymentMethodLabel.Text = "Payment Method: Credit Card";
            this.PaymentMethodLabel.Click += new System.EventHandler(this.PaymentMethodLabel_Click);
            // 
            // DeliveryLabel
            // 
            this.DeliveryLabel.AutoSize = true;
            this.DeliveryLabel.Location = new System.Drawing.Point(12, 130);
            this.DeliveryLabel.Name = "DeliveryLabel";
            this.DeliveryLabel.Size = new System.Drawing.Size(132, 16);
            this.DeliveryLabel.TabIndex = 4;
            this.DeliveryLabel.Text = "Order Type: Delivery";
            // 
            // TimestampLabel
            // 
            this.TimestampLabel.AutoSize = true;
            this.TimestampLabel.Location = new System.Drawing.Point(12, 162);
            this.TimestampLabel.Name = "TimestampLabel";
            this.TimestampLabel.Size = new System.Drawing.Size(92, 16);
            this.TimestampLabel.TabIndex = 5;
            this.TimestampLabel.Text = "Time: 12:00:00";
            // 
            // OrderListView
            // 
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Items,
            this.Price});
            this.OrderListView.HideSelection = false;
            this.OrderListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.OrderListView.Location = new System.Drawing.Point(12, 196);
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.Size = new System.Drawing.Size(426, 165);
            this.OrderListView.TabIndex = 6;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
            this.OrderListView.SelectedIndexChanged += new System.EventHandler(this.OrderListView_SelectedIndexChanged);
            // 
            // Items
            // 
            this.Items.Text = "Items";
            this.Items.Width = 108;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // SignatureBox
            // 
            this.SignatureBox.Image = ((System.Drawing.Image)(resources.GetObject("SignatureBox.Image")));
            this.SignatureBox.Location = new System.Drawing.Point(12, 386);
            this.SignatureBox.Name = "SignatureBox";
            this.SignatureBox.Size = new System.Drawing.Size(426, 154);
            this.SignatureBox.TabIndex = 7;
            this.SignatureBox.TabStop = false;
            this.SignatureBox.Visible = false;
            this.SignatureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(12, 703);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(114, 33);
            this.PrintButton.TabIndex = 8;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "9.99";
            // 
            // ReceiptUI
            // 
            this.ClientSize = new System.Drawing.Size(450, 748);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.SignatureBox);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.TimestampLabel);
            this.Controls.Add(this.DeliveryLabel);
            this.Controls.Add(this.PaymentMethodLabel);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.CustomerNameLabel);
            this.Name = "ReceiptUI";
            this.Load += new System.EventHandler(this.ReceiptUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SignatureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptUI_Load(object sender, EventArgs e)
        {

        }

        private void PaymentMethodLabel_Click(object sender, EventArgs e)
        {

        }

        private void TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void OrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
