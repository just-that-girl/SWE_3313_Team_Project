using System;

namespace HeavenlySlice
{
    /// <summary>
    /// Represents a payment made by a customer.
    /// </summary>
    public class Payment
    {
        private string paymentTitle;
        private bool creditCard;
        private double paymentAmount;
        private string phone;

        /// <summary>
        /// Initializes a new instance of the Payment class.
        /// </summary>
        /// <param name="pT">Title or description of the payment.</param>
        /// <param name="cC">True if paid with credit card, false if cash.</param>
        /// <param name="pA">Amount of the payment.</param>
        /// <param name="p">Phone number associated with the payment.</param>
        public Payment(string pT, bool cC, double pA, string p)
        {
            this.paymentTitle = pT;
            this.creditCard = cC;
            this.paymentAmount = pA;
            this.phone = p;
        }

        /// <summary>
        /// Gets or sets the title or description of the payment.
        /// </summary>
        public string PaymentTitle
        {
            get { return this.paymentTitle; }
            set { this.paymentTitle = value; }
        }

        /// <summary>
        /// Gets or sets whether the payment was made with a credit card.
        /// </summary>
        public bool CreditCard
        {
            get { return this.creditCard; }
            set { this.creditCard = value; }
        }

        /// <summary>
        /// Gets or sets the amount of the payment.
        /// </summary>
        public double PaymentAmount
        {
            get { return this.paymentAmount; }
            set { this.paymentAmount = value; }
        }

        /// <summary>
        /// Gets or sets the phone number associated with the payment.
        /// </summary>
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
    }
}