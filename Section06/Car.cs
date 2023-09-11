using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Car
{
    // ------------------------ Private Member Variables ------------------------
    private string _name;				// By convention, member variables are set to private
	private int _hp;
	private string _color;
				
    // ------------------------ Public Properties ------------------------
    public string Name {				// By convention, we get the private member variables from outside
		get { return _name; }			// of the class by using a getter method.  And we set the private 
		set { _name = value; }			// member variables from outside of the class by using a setter 
	}                                   // method.  
                                        
	// ------------------------ Public Properties ------------------------
    public int MaxSpeed { get; set; }   // You can remove either the getter or setter method
                                        // This is useful for cases where you want immutability
                                        // such as a birthday.  Or if you want something as read
                                        // only.  
										// 
										// Ideal scenarios:
										//		*Read only - Use only a getter method
										//		*Write only - Use only a setter method

    // ------------------------ Default Constructor ------------------------
    public Car()
	{
		_name = "Car";
		_hp = 0;
		_color = "red";
		Drive();
	}

    // ------------------------ Partial Specification Constructor ------------------------

    public Car(string name, int hp = 0)
    {
        _name = name;
        _hp = hp;
        _color = "red";
        Console.WriteLine(name + " was created");
        Drive();
    }

    // ------------------------ Full Specification Constructor ------------------------
    public Car(string name, int hp = 0, string color = "black")
	{
		_name = name;
		_hp = hp;
		_color = color;
		Console.WriteLine(name + " was created");
        Drive();
    }

    // ------------------------ Member Methods ------------------------
    private void Drive()				// Making the method private makes it so that only the class can call on it's Drive() method
	{
		Console.WriteLine(_name + " is driving");
	}

	public void Stop()
	{
		Console.WriteLine(_name + " Car stopped");
	}

	public void Details()
	{
		Console.WriteLine("The " + _color + " " + _name + " has a horsepower of " + _hp);
	}
}
