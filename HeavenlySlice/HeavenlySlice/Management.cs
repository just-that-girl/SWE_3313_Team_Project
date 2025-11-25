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
            customers.Add(new Customer(NameBox.Text,AddressBox.Text,PhoneBox.Text,ChargeAccountBox.Text,AreaFeatureBox.Text));
            
        }

        private void PhoneSearchButton_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            foreach(Customer c in customers){

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
            
            payments.Add(new Payment(PaymentTitleBox.Text, CreditCardButton.Checked, Convert.ToDouble(PaymentAmountBox.Text),PhonePaymentBox.Text));
        }

        private void SaveButton_Click(object sender, EventArgs e) //creates or saves current list of customers into a file
        {
            try
            {
               
                System.IO.File.WriteAllText(@".\database.json", JsonConvert.SerializeObject(customers));
            }
            catch(Exception exc)
            {

            }
        }

        private void LoadButton_Click(object sender, EventArgs e)//loads list of customers from file named database.json
        {
            try
            {                
               customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(@".\database.json"));
            }
            catch(Exception exc)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                payments = JsonConvert.DeserializeObject<List<Payment>>(File.ReadAllText(@".\paymentdatabase.json"));
            }
            catch (Exception exc)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)//save button for payments
        {
            try
            {
                System.IO.File.WriteAllText(@".\paymentdatabase.json", JsonConvert.SerializeObject(payments));
            }
            catch (Exception exc)
            {

            }
        }
    }
}
