using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace HeavenlySlice
{
    public partial class OrderMenu : Form
    {
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(@".\database.json"));
        List<Payment> payments = JsonConvert.DeserializeObject<List<Payment>>(File.ReadAllText(@".\paymentdatabase.json"));
        double total = 0.00;
        public OrderMenu()
        {
            InitializeComponent();
        }

        private void CYOAPizza_CheckedChanged(object sender, EventArgs e)
        {
            if (CYOAPizza.Checked)
            {
                pizzaCreatorBox.Enabled = true;
            }
            else
            {
                pizzaCreatorBox.Enabled = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            total = 0;
            pizzaList.Items.Clear();
        }

        private void addPizzaButton_Click(object sender, EventArgs e)
        {
            String title = "";
            double price = 0;
            if (tinySize.Checked)
            {
                title = "Tiny ";
                price += 5.99;
            }
            else if (smallSize.Checked)
            {
                title = "Small ";
                price += 7.99;
            }
            else if (mediumSize.Checked)
            {
                title = "Medium ";
                price += 9.99;
            }
            else if (largeSize.Checked)
            {
                title = "Large ";
                price += 12.99;
            }
            if (meatLovers.Checked)
            {
                title = title + "Meat Lovers";
                price += 5.94;
            }
            else if (veggieLovers.Checked)
            {
                title = title + "Veggie Lovers";
                price += 5.94;
            }
            else if (cheeseLovers.Checked)
            {
                title = title + "Cheese Lovers";
                price += 3.96;
            }
            else if (CYOAPizza.Checked)
            {
                title = title + "CYO Pizza";
                if (alfredoButton.Checked)
                {
                    price += 0.99;
                }
                if (tomatoButton.Checked)
                {
                    price += 0.99;
                }
                if (mozarellaButton.Checked)
                {
                    price += 0.99;
                }
                if (fetaButton.Checked)
                {
                    price += 0.99;
                }
                if (cheddarButton.Checked)
                {
                    price += 0.99;
                }
                if (sausageButton.Checked)
                {
                    price += 0.99;
                }
                if (pepperoniButton.Checked)
                {
                    price += 0.99;
                }
                if (baconButton.Checked)
                {
                    price += 0.99;
                }
                if (chickenButton.Checked)
                {
                    price += 0.99;
                }
                if (onionsButton.Checked)
                {
                    price += 0.99;
                }
                if (peppersButton.Checked)
                {
                    price += 0.99;
                }
                if (mushroomsButton.Checked)
                {
                    price += 0.99;
                }
                if (spinachButton.Checked)
                {
                    price += 0.99;
                }
                
            }
            total += price;
            totalDue.Text = ("$" + total);
            pizzaList.Items.Add(title).SubItems.Add("$" + price);
        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            Boolean foundNumber = false;
            foreach(Customer c in customers)
            {
                if (c.Phone.Equals(phoneSubmission.Text))
                {
                    foundNumber = true;
                    break;
                }

            }
            if (foundNumber)
            {
                payments.Add(new Payment("Pizza order",payWithCardBox.Checked,total,phoneSubmission.Text));
                pizzaList.Clear();
                total = 0;
                System.IO.File.WriteAllText(@".\paymentdatabase.json", JsonConvert.SerializeObject(payments));
                MessageBox.Show("Order made!","Confirmation",MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Enter info for first time customer","Confirmation",MessageBoxButtons.OK);
                CustomerManagementGroup.Enabled = true;
            }
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer(NameBox.Text, AddressBox.Text, PhoneBox.Text, ChargeAccountBox.Text, AreaFeatureBox.Text));
            System.IO.File.WriteAllText(@".\database.json", JsonConvert.SerializeObject(customers));
        }

        private void payWithCardBox_CheckedChanged(object sender, EventArgs e)
        {
            if (payWithCardBox.Checked)
            {
                digitalSignature.Enabled = true;
            }
            else
            {
                digitalSignature.Enabled = false;
            }
        }

        private void openManagement_Click(object sender, EventArgs e)
        {
            var m = new Management();
            m.Show();
        }
    }
}
