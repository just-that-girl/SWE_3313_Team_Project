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
    public partial class Management : Form
    {

        List<Customer> customers = new List<Customer>();
        List<Payment> payments = new List<Payment>();

        public Management()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer(NameBox.Text, AddressBox.Text, PhoneBox.Text, ChargeAccountBox.Text, AreaFeatureBox.Text));

        }

        private void PhoneSearchButton_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            foreach (Customer c in customers)
            {

                if (c.Phone.Equals(PhoneSearchBox.Text))
                {
                    NameResultLabel.Text = c.Name;
                    AddressResultLabel.Text = c.Address;
                    PhoneResultLabel.Text = c.Phone;
                    ChargeAccountResultLabel.Text = c.ChargeAccount;
                    AreaFeatureResultLabel.Text = c.AreaFeature;
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                NameResultLabel.Text = "Not found!";
                AddressResultLabel.Text = "Not found!";
                PhoneResultLabel.Text = "Not found!";
                ChargeAccountResultLabel.Text = "Not found!";
                AreaFeatureResultLabel.Text = "Not found!";
            }

        }

        private void ProcessPaymentButton_Click(object sender, EventArgs e)
        {

            payments.Add(new Payment(PaymentTitleBox.Text, CreditCardButton.Checked, Convert.ToDouble(PaymentAmountBox.Text), PhonePaymentBox.Text));
        }

        private void SaveButton_Click(object sender, EventArgs e) //creates or saves current list of customers into a file
        {
            try
            {
                File.WriteAllText(@".\database.json", JsonConvert.SerializeObject(customers));
                MessageBox.Show("Customers saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error saving customers: {exc.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)//loads list of customers from file named database.json
        {
            try
            {
                if (File.Exists(@".\database.json"))
                {
                    customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(@".\database.json"));
                    MessageBox.Show("Customers loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No customer database found.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error loading customers: {exc.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@".\paymentdatabase.json"))
                {
                    payments = JsonConvert.DeserializeObject<List<Payment>>(File.ReadAllText(@".\paymentdatabase.json"));
                    MessageBox.Show("Payments loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No payment database found.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error loading payments: {exc.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)//save button for payments
        {
            try
            {
                File.WriteAllText(@".\paymentdatabase.json", JsonConvert.SerializeObject(payments));
                MessageBox.Show("Payments saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error saving payments: {exc.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
