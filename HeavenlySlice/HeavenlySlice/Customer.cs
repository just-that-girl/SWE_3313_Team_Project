using System;
public class Customer
{

	string name;
	string address;
	string phone;
	string chargeAccount;
	string areafeature;

	public Customer(string n, string a, string p, string cA, string af)
	{
		
		this.name = n;
		this.address = a;
		this.phone = p;
		this.chargeAccount = cA;
		this.areafeature = af;
	}
	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
	}
	public string Address
	{
		get
		{
			return this.address;
		}
		set
		{
			this.address = value;
		}
	}
	public string Phone
	{
		get
		{
			return this.phone;
		}
		set
		{
			this.phone = value;
		}
	}
	public string ChargeAccount
	{
		get
		{
			return this.chargeAccount;
		}
		set
		{
			this.chargeAccount = value;
		}
	}
	public string AreaFeature
	{
		get
		{
			return this.areafeature;
		}
		set
		{
			this.chargeAccount = value;
		}
	}
}
