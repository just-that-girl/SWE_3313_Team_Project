using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeavenlySlice
{
    public partial class Form1 : Form
    {
        List<Customer> customers = new List<Customer>();
        List<Payment> payments = new List<Payment>();
        public Form1()
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
            
            payments.Add(new Payment(PaymentTitleBox.Text, CreditCardButton.Checked, Convert.ToDouble(PaymentAmountBox.Text)));
        }
    }
}
