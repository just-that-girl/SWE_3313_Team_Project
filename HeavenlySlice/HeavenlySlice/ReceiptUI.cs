using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeavenlySlice
{
    /// <summary>
    /// ReceiptUI form displays the completed order summary, totals, and restaurant details.
    /// </summary>
    public partial class ReceiptUI : Form
    {
        private Label phoneLabel;
        private Label paymentMethodLabel;
        private Label deliveryLabel;
        private ListView receiptList;
        private Label totalLabel;
        private Label restaurantDetailsLabel;
        private ColumnHeader Item;
        private ColumnHeader Price;
        private Label customerNameLabel;

        /// <summary>
        /// Initializes a new instance of the ReceiptUI form.
        /// </summary>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="phone">Phone number of the customer.</param>
        /// <param name="items">List of ordered items with names and prices.</param>
        /// <param name="total">Total price of the order.</param>
        /// <param name="paidWithCard">True if paid with card, false if cash.</param>
        /// <param name="delivery">True if delivery, false if pickup.</param>
        public ReceiptUI(string customerName, string phone, List<Tuple<string, double>> items, double total, bool paidWithCard, bool delivery)
        {
            InitializeComponent();

            // Customer info
            customerNameLabel.Text = $"Customer: {customerName}";
            phoneLabel.Text = $"Phone: {phone}";

            // Payment and delivery info
            paymentMethodLabel.Text = $"Payment: {(paidWithCard ? "Credit Card" : "Cash")}";
            deliveryLabel.Text = $"Order Type: {(delivery ? "Delivery" : "Pickup")}";

            // Populate items list
            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Item1);
                listItem.SubItems.Add($"${item.Item2:F2}");
                receiptList.Items.Add(listItem);
            }

            // Totals
            totalLabel.Text = $"Total: ${total:F2}";

            // Restaurant details
            restaurantDetailsLabel.Text =
                "Heavenly Slice\n" +
                "\n" +
                "1100 South Marietta Pkwy SE, \n" +
                "Marietta, GA 30060\n" +
                "000-000-0000\n" +
                "HeavenlySlice.com\n" +
                "Hours: Mon-Thur 9am-11pm, Fri-Sat 11am-12am";
        }

        private void InitializeComponent()
        {
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.paymentMethodLabel = new System.Windows.Forms.Label();
            this.deliveryLabel = new System.Windows.Forms.Label();
            this.receiptList = new System.Windows.Forms.ListView();
            this.totalLabel = new System.Windows.Forms.Label();
            this.restaurantDetailsLabel = new System.Windows.Forms.Label();
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(13, 13);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(104, 16);
            this.customerNameLabel.TabIndex = 0;
            this.customerNameLabel.Text = "Customer Name";
            this.customerNameLabel.Click += new System.EventHandler(this.customerNameLabel_Click);
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(146, 13);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(77, 16);
            this.phoneLabel.TabIndex = 1;
            this.phoneLabel.Text = "1234567890";
            // 
            // paymentMethodLabel
            // 
            this.paymentMethodLabel.AutoSize = true;
            this.paymentMethodLabel.Location = new System.Drawing.Point(13, 43);
            this.paymentMethodLabel.Name = "paymentMethodLabel";
            this.paymentMethodLabel.Size = new System.Drawing.Size(77, 16);
            this.paymentMethodLabel.TabIndex = 2;
            this.paymentMethodLabel.Text = "Cash / Card";
            // 
            // deliveryLabel
            // 
            this.deliveryLabel.AutoSize = true;
            this.deliveryLabel.Location = new System.Drawing.Point(146, 43);
            this.deliveryLabel.Name = "deliveryLabel";
            this.deliveryLabel.Size = new System.Drawing.Size(57, 16);
            this.deliveryLabel.TabIndex = 3;
            this.deliveryLabel.Text = "Delivery";
            this.deliveryLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // receiptList
            // 
            this.receiptList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item,
            this.Price});
            this.receiptList.FullRowSelect = true;
            this.receiptList.GridLines = true;
            this.receiptList.HideSelection = false;
            this.receiptList.Location = new System.Drawing.Point(12, 74);
            this.receiptList.Name = "receiptList";
            this.receiptList.Size = new System.Drawing.Size(304, 168);
            this.receiptList.TabIndex = 4;
            this.receiptList.UseCompatibleStateImageBehavior = false;
            this.receiptList.View = System.Windows.Forms.View.Details;
            this.receiptList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(16, 261);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(31, 16);
            this.totalLabel.TabIndex = 5;
            this.totalLabel.Text = "0.00";
            // 
            // restaurantDetailsLabel
            // 
            this.restaurantDetailsLabel.AutoSize = true;
            this.restaurantDetailsLabel.Location = new System.Drawing.Point(16, 292);
            this.restaurantDetailsLabel.Name = "restaurantDetailsLabel";
            this.restaurantDetailsLabel.Size = new System.Drawing.Size(49, 16);
            this.restaurantDetailsLabel.TabIndex = 6;
            this.restaurantDetailsLabel.Text = "Details";
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 200;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 100;
            // 
            // ReceiptUI
            // 
            this.ClientSize = new System.Drawing.Size(527, 500);
            this.Controls.Add(this.restaurantDetailsLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.receiptList);
            this.Controls.Add(this.deliveryLabel);
            this.Controls.Add(this.paymentMethodLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Name = "ReceiptUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void customerNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}