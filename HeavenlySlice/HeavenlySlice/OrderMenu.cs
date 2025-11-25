using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HeavenlySlice
{
    /// <summary>
    /// OrderMenu form handles pizza creation, cart display, customer lookup, and order submission.
    /// </summary>
    public partial class OrderMenu : Form
    {
        private List<Customer> customers = new List<Customer>();
        private List<Payment> payments = new List<Payment>();
        private double total = 0.00;

        public OrderMenu()
        {
            InitializeComponent();

            // Load customers and payments safely
            try
            {
                if (File.Exists(@".\database.json"))
                    customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(@".\database.json"));
            }
            catch { customers = new List<Customer>(); }

            try
            {
                if (File.Exists(@".\paymentdatabase.json"))
                    payments = JsonConvert.DeserializeObject<List<Payment>>(File.ReadAllText(@".\paymentdatabase.json"));
            }
            catch { payments = new List<Payment>(); }
        }

        /// <summary>
        /// Enables or disables pizza creator box based on checkbox.
        /// </summary>
        private void CYOAPizza_CheckedChanged(object sender, EventArgs e)
        {
            pizzaCreatorBox.Enabled = CYOAPizza.Checked;
        }

        /// <summary>
        /// Clears the pizza list and resets total.
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            total = 0;
            pizzaList.Items.Clear();
            totalDue.Text = "$0.00";
        }

        /// <summary>
        /// Adds a pizza to the cart with calculated price.
        /// </summary>
        private void addPizzaButton_Click(object sender, EventArgs e)
        {
            string title = "";
            double price = 0;

            // Sizes
            if (tinySize.Checked) { title = "Tiny "; price += 5.99; }
            else if (smallSize.Checked) { title = "Small "; price += 7.99; }
            else if (mediumSize.Checked) { title = "Medium "; price += 9.99; }
            else if (largeSize.Checked) { title = "Large "; price += 12.99; }

            // Preset pizzas
            if (meatLovers.Checked) { title += "Meat Lovers"; price += 5.94; }
            else if (veggieLovers.Checked) { title += "Veggie Lovers"; price += 5.94; }
            else if (cheeseLovers.Checked) { title += "Cheese Lovers"; price += 3.96; }
            else if (CYOAPizza.Checked)
            {
                title += "CYO Pizza";
                // Add toppings cost
                foreach (Control button in new Control[] { alfredoButton, tomatoButton, mozarellaButton, fetaButton, cheddarButton,
                                                           sausageButton, pepperoniButton, baconButton, chickenButton,
                                                           onionsButton, peppersButton, mushroomsButton, spinachButton })
                {
                    if (button is CheckBox cb && cb.Checked) price += 0.99;
                    if (button is RadioButton rb && rb.Checked) price += 0.99;
                }
            }

            total += price;
            totalDue.Text = $"${total:F2}";

            var item = new ListViewItem(title);
            item.SubItems.Add($"${price:F2}");
            pizzaList.Items.Add(item);
        }

        /// <summary>
        /// Submits the order, saves payment, and shows receipt.
        /// </summary>
        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            bool foundNumber = customers.Exists(c => c.Phone.Equals(phoneSubmission.Text));

            if (foundNumber)
            {
                payments.Add(new Payment("Pizza order", payWithCardBox.Checked, total, phoneSubmission.Text));

                var items = new List<Tuple<string, double>>();
                foreach (ListViewItem item in pizzaList.Items)
                {
                    string name = item.Text;
                    double price = Convert.ToDouble(item.SubItems[1].Text.Replace("$", ""));
                    items.Add(new Tuple<string, double>(name, price));
                }

                var customer = customers.FirstOrDefault(c => c.Phone.Equals(phoneSubmission.Text));
                string customerName = customer != null ? customer.Name : "Valued Customer";

                var receipt = new ReceiptUI(customerName, phoneSubmission.Text, items, total, payWithCardBox.Checked, deliveryButton.Checked);
                receipt.Show();

                pizzaList.Items.Clear();
                total = 0;
                File.WriteAllText(@".\paymentdatabase.json", JsonConvert.SerializeObject(payments));
                MessageBox.Show("Order made!", "Confirmation", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter info for first time customer", "Confirmation", MessageBoxButtons.OK);
                CustomerManagementGroup.Enabled = true;
            }
        }

        /// <summary>
        /// Adds a new customer and saves to database.json.
        /// </summary>
        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer(NameBox.Text, AddressBox.Text, PhoneBox.Text, ChargeAccountBox.Text, AreaFeatureBox.Text));
            File.WriteAllText(@".\database.json", JsonConvert.SerializeObject(customers));
            MessageBox.Show("Customer added successfully!");
        }

        /// <summary>
        /// Enables digital signature if paying with card.
        /// </summary>
        private void payWithCardBox_CheckedChanged(object sender, EventArgs e)
        {
            digitalSignature.Enabled = payWithCardBox.Checked;
        }

        /// <summary>
        /// Opens the Management form.
        /// </summary>
        private void openManagement_Click(object sender, EventArgs e)
        {
            var m = new Management();
            m.Show();
        }

        // === Beverage and Dessert Buttons ===

        private void addCokeButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Coke", 1.99);
        }

        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Sprite", 1.99);
        }

        private void addFantaButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Fanta", 1.99);
        }

        private void addSweetTeaButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Sweet Tea", 1.99);
        }

        private void addUnsweetTeaButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Unsweet Tea", 1.99);
        }

        private void addChipButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Chocolate Chip Cookie", 2.49);
        }

        private void addChocolateButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Chocolate Chunk Cookie", 2.49);
        }

        private void addOatmealButton_Click(object sender, EventArgs e)
        {
            AddItemToCart("Oatmeal Cookie", 2.49);
        }

        /// <summary>
        /// Helper method to add any item to the cart.
        /// </summary>
        private void AddItemToCart(string itemName, double price)
        {
            total += price;
            totalDue.Text = $"${total:F2}";

            var item = new ListViewItem(itemName);
            item.SubItems.Add($"${price:F2}");
            pizzaList.Items.Add(item);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            /// empty method
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            /// empty method
        }
    }
}