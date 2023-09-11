using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Members
{
    // ------------------------ Private Member Variables ------------------------
    private string memberName;
    private string jobTitle;
    private int salary;

    // ------------------------ Public Member Variables ------------------------
    public int age;

    // ------------------------ Public Properties ------------------------
    public string JobTitle { 
        get
        {
            return jobTitle;
        }
        set
        {
            jobTitle = value;
        }
    }

    // ------------------------ Member Methods ------------------------
    public void Introducing(bool isFriend)
    {
        if (isFriend)
        {
            SharingPrivateInfo();
        }
        else
        {
            Console.WriteLine("Hi, my name is {0}, and my job title is {1}.  I'm {2} years old.", memberName, jobTitle, age);
        }
    }

    private void SharingPrivateInfo()
    {
        Console.WriteLine("My salary is {0}", salary);
    }

    // ------------------------ Constructor ------------------------
    public Members()
    {
        age = 30;
        memberName = "Lucy";
        salary = 60000;
        jobTitle = "Developer";
        Console.WriteLine("Object created");
    }

    // ------------------------ Finalizer (AKA Destructor) ------------------------
    ~Members()
    {
        // Finalizers are used to perform any necessary final clean-up when a class instance
        // is being collected by the garbage collector.  
        Console.WriteLine("Destruction of members object");
    }
}
