// CAB301 Assessment 2 - Version A
// Maolin 
//The specifications of MemberCollection ADT


// Invariants:  (1) No duplicate members in this member collection (all the members in this member collection have different full names);
//              (2) Count >= 0;
//              (3) Members in this member collection are stored in the Binary Search Tree (BST) 

public interface IMemberCollection
{

    // get the number of members in this member collection 
    public int Number 
    {
        get;
    }

    // Check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this member collection was empty; otherwise, return false. This member collection remains unchanged and new Number = old Number.
    bool IsEmpty();

    // Insert a member into this member collection
    // Pre-condition: nil
    // Post-condition: if the member was not in this member collection, the member has been added into this member collection, new Number = old Number + 1 and return true; otherwise, the member has not been added into this member collection, new Number = old Number and return false.
    bool Insert(IMember aMember);


    // Delete a member from this member collection
    // Pre-condition: nil
    // Post-condition:  if the member was in this member collection, the member has been removed out of this member collection, new Number = old Number - 1 and return true; 
    //                  otherwise, this member collection remains unchanged, and new Number = old Number, and return false. 
    bool Delete(IMember aMember);


    // Search for a member  in this member collection  
    // Pre-condition: nil
    // Post-condition: if the member was in this member collection, return the reference of the member object;
    //                 otherwise, return null. This member collection remains unchanged. New Number = old Number.
    IMember? Search(IMember aMember);

    // Return an array that contains all the members in this member collection and the members in the array are sorted in alphabetical order by member's full name
    // Pre-condition: nil
    // Post-condition: if the member collection was not empty, return an array that contains all the members in this member collection and the members in the array are sorted in alphabetical order by member's full name;
    //                  otherwise, return null. This member collection remains unchanged and New Number = old Number.               
    IMember[]? ToArray();

    // Clear this member collection
    // Pre-condition: nil
    // Post-condition: all the members in this member collection, if any, have been removed from this member collection and New Number = 0. 
    void Clear();


}


