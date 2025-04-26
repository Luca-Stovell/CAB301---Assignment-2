// CAB301 Assessment 2 - Version A
// Maolin 
//The implementation of Member ADT


//Invariants:   (1) Pin is a number which has a minimal of 4 and a maximal of 6 digits;
//              (2) ContactNumber has 10 digits and its first digit is 0;
//              (3) Neither LastName nor FirstName is empty.


class Member : IMember
{
    // Fields
    private string firstName;
    private string lastName;
    private string contactNumber;
    private string pin;


    // Properties
    public string FirstName { get { return firstName; } }  // Get and set the first name of this member
    public string LastName { get { return lastName; } }  // Get and set the last name of this member
    public string ContactNumber { get { return contactNumber; } set { if (IMember.IsValidContactNumber(value)) contactNumber = value; } }  // Get and set the contact number of this member
    public string Pin { get { return pin; } set { if (IMember.IsValidPin(value)) pin = value; } }// Get and set a pin number



    // Constructor with member's full details
    // Pre-conditions: both contactNumber and Pin are valid
    // Post-condition: a valid Member object has been created
    public Member(string firstName, string lastName, string contactNumber, string pin)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.contactNumber = contactNumber;
        this.pin = pin;
    }

    // Constructor 
    // Pre-conditions: nil
    // Post-condition: an idential Member object has been created
    public Member(IMember member)
    {
        this.firstName = member.FirstName;
        this.lastName = member.LastName;
        this.contactNumber = member.ContactNumber;
        this.pin = member.Pin;
    }



    // Define how to comapre two member objects of member
    // This member's full name is compared to another member's full name
    // The full name convention used in this assignment is: First Name + " " + Last Name
    // Pre-condition: nil
    // Post-condition: return -1 if this member's full name is before another member's full name in dictionary order
    //                 return 0, if this member's full name is the same with another member's full name in dictionary order
    //                 return +1, of this member's full name is after another member's full name in dictionary order, or another member is null

    public int CompareTo(IMember member)
    {
        if(member == null) return 1; //Validate that the Name is not Null 

        if (LastName.CompareTo(member.LastName) < 0)
        {
            return -1;
        }
        else if (LastName.CompareTo(member.LastName) == 0)
        {
            return FirstName.CompareTo(member.FirstName);
        }
        else
        {
            return 1;
        }
    }

       

    // Return a string containing the first name, last name and contact number of this member
    // Pre-condition: nil
    // Post-condition: a  string containing the first name, last name, and contact number of this member is returned
    public string ToString()
    {
        return lastName + "," + firstName + "," + contactNumber;
    }
}


