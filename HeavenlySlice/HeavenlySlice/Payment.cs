using System;

public class Payment
{
	string paymentTitle;
	Boolean creditCard;
	double paymentAmount;

	public Payment(string pT,Boolean cC,double pA)
	{
		this.paymentTitle = pT;
		this.creditCard = cC;
		this.paymentAmount = pA;
	}

	public string PaymentTitle
	{
		get
		{
			return this.paymentTitle;
		}
		set
		{
			this.paymentTitle = value;
		}
	}
	public Boolean CreditCard
	{
		get { return this.creditCard; }
		set { this.creditCard = value; }
	}
	public double PaymentAmount
	{
		get{ return this.paymentAmount; }
		set { this.paymentAmount = value; }
	}

}
