//CAB301 Assignment 2 - Version A
//Maolin Tang
//The specification of Member ADT



//Invariants:   (1) Pin is a number which has a minimal of 4 and a maximal of 6 digits;
//              (2) ContactNumber has 10 digits and its first digit is 0;
//              (3) Neither LastName nor FirstName is empty.

public interface IMember
    {

        // Get the first name of this member
        public string FirstName  
        {
            get;

        }
        // Get the last name of this member
        public string LastName 
        {
            get;
        }

        // Get and set the contact number of this member
        // A valid contact phone number has 10 digits and its first digit is 0
        public string ContactNumber 
        {
                get;
                set; //contact number must be valid 
        }

        // Get and set a pin for this member
        // A pin is valid if it is a number which has a minimal of 4 and a maximal of 6 digits
        public string Pin 
        {
            get;
            set; //pin must be valid 
        }

        // Define how to comapre two member objects of member
        // This member's full name is compared to another member's full name
        // The full name convention used in this assignment is: First Name + " " + Last Name
        // Pre-condition: nil
        // Post-condition: return -1 if this member's full name is before another member's full name in dictionary order
        //                 return 0, if this member's full name is the same with another member's full name in dictionary order
        //                 return +1, of this member's full name is after another member's full name in dictionary order, or another member is null
        public int CompareTo(IMember member);
        


        // Check if a contact phone number is valid. A contact phone number is valid if it has 10 digits and the first digit is 0.
        // Pre-condition: nil
        // Post-condition: return true, if the phone number id is not null and valid; returns false otherwise.
        public static bool IsValidContactNumber(string phonenumber)
        {
            foreach(char digit in phonenumber){
                if(!char.IsDigit(digit)){
                    return false;
                }    
            }
            if(phonenumber[0] == '0' && phonenumber.Length == 10){
                return true;
            }
            return false;
        }

        // Check if a pin is valid. A pin is valid if it is a number which has a minimal of 4 and a maximal of 6 digits.
        // Pre-condition: nil
        // Post-condition: return true, if the pin is not null and valid; returns false otherwise.
        public static bool IsValidPin(string pin)
        {
            foreach(char digit in pin){
                if(!char.IsDigit(digit)){
                    return false;
                }    
            }
            if(4 <= pin.Length && pin.Length <= 6){
                return true;
            }
            return false;

        }


        // Return a string containing the first name, last name and contact number of this member
        // Pre-condition: nil
        // Post-condition: a string containing the first name, last name, and contact number of this member is returned
        public string ToString();
        
}

