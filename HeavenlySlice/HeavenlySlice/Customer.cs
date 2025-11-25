using System;

namespace HeavenlySlice
{
    /// <summary>
    /// Represents a customer of Mom's and Pop's Pizzeria.
    /// </summary>
    public class Customer
    {
        private string name;
        private string address;
        private string phone;
        private string chargeAccount;
        private string areaFeature;

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        /// <param name="n">Customer's full name.</param>
        /// <param name="a">Customer's address.</param>
        /// <param name="p">Customer's phone number.</param>
        /// <param name="cA">Customer's charge account identifier.</param>
        /// <param name="af">Special area feature or delivery note.</param>
        public Customer(string n, string a, string p, string cA, string af)
        {
            this.name = n;
            this.address = a;
            this.phone = p;
            this.chargeAccount = cA;
            this.areaFeature = af;
        }

        /// <summary>
        /// Gets or sets the customer's full name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the customer's address.
        /// </summary>
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        /// <summary>
        /// Gets or sets the customer's charge account identifier.
        /// </summary>
        public string ChargeAccount
        {
            get { return this.chargeAccount; }
            set { this.chargeAccount = value; }
        }

        /// <summary>
        /// Gets or sets the customer's area feature or delivery note.
        /// </summary>
        public string AreaFeature
        {
            get { return this.areaFeature; }
            set { this.areaFeature = value; }
        }
    }
}