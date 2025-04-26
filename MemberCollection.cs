// CAB301 Assessment 2 - Version A
// Maolin 
//The implementation of MemberCollection ADT



// Invariants:  (1) No duplicate members in this member collection (all the members in this member collection have different full names);
//              (2) Count >= 0;
//              (3) Members in this member collection are stored in Binary Search Tree (BST) 


//A class that models a node of Binary Search Tree
public class BTreeNode
{
    public IMember member;
    public BTreeNode? lchild; // reference to its left child 
    public BTreeNode? rchild; // reference to its right child

    public BTreeNode(IMember aMember)
    {
        this.member = aMember;
        this.lchild = null;
        this.rchild = null;
    }
}

partial class MemberCollection : IMemberCollection
{
    // Fields
    private BTreeNode? root; // root is the root of the binary search tree where members are stored 
    private int count; // the number of members currently stored in this member collection 


    // Constructor - create an object of MemberCollection object
    public MemberCollection()
    {
        root = null;
        count = 0;
    }


    // Properties


    // get the number of members in this member collection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }


    // Check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this member collection is empty; otherwise, return false. This member collection remains unchanged and new Number = old Number
    public bool IsEmpty()
    {
        if (root == null)
            return true;
        else
            return false;
    }

    // Insert a member into this member collection
    // Pre-condition: nil
    // Post-condition: if the member was not this member collection and was not null, the member has been added into this member collection, new Number = old Number + 1 and return true;
    //                  otherwise, the member has not been added into this member collection, new Number = old Number and return false.
    public bool Insert(IMember aMember)
    {
        if (aMember == null)
        {
            return false;
        }

        if (root == null)
        {
            root = new BTreeNode(aMember);
            count++;
            return true;
        }
        else
        {
            return InsertIterate(aMember, root);
        }
    }

    private bool InsertIterate(IMember member, BTreeNode ptr) {
        if (member.CompareTo(ptr.member) < 0) {
            if (ptr.lchild == null) {
                ptr.lchild = new BTreeNode(member);
                count++;
                return true;
            } else {
                return InsertIterate(member, ptr.lchild);
            }
        } else if (member.CompareTo(ptr.member) > 0) {
            if (ptr.rchild == null) {
                ptr.rchild = new BTreeNode(member);
                count++;
                return true;
            } else {
                return InsertIterate(member, ptr.rchild);
            }
        }
        else {
            return false;
        }
    }


    // Delete a member from this member collection
    // Pre-condition: nil
    // Post-condition:  if the member was in this member collection and was not null, the member has been removed out of this member collection, new Number = old Number - 1 and return true; 
    //                  otherwise, this member collection remains unchanged, and new Number = old Number, and return false. 

    public bool Delete(IMember aMember)
    {
        if (aMember != null)
        {
            BTreeNode ptr = root; // Search Reference
            BTreeNode parent = null; // Parent of root

            while ((ptr != null) && (aMember.CompareTo(ptr.member) != 0))
            {
                parent = ptr;

                if (aMember.CompareTo(ptr.member) < 0)
                {
                    ptr = ptr.lchild;
                }
                else
                {
                    ptr = ptr.rchild;
                }
            }

            if (ptr == null)
            {
                return false; // Member not found
            }

            // Case 3: item has two children
            if ((ptr.lchild != null) && (ptr.rchild != null))
            {
                // Special case: right subtree of ptr.lchild is empty
                if (ptr.lchild.rchild == null)
                {
                    ptr.member = ptr.lchild.member;
                    ptr.lchild = ptr.lchild.lchild;
                }
                else
                {
                    // General case: find right-most node of left subtree
                    BTreeNode p = ptr.lchild;
                    BTreeNode pp = ptr;
                    while (p.rchild != null)
                    {
                        pp = p;
                        p = p.rchild;
                    }
                    ptr.member = p.member;
                    pp.rchild = p.lchild;
                }
            }
            else
            {
                // Cases 1 & 2: item has no or only one child
                BTreeNode c;
                if (ptr.lchild != null)
                    c = ptr.lchild;
                else
                    c = ptr.rchild;

                // Remove node ptr
                if (ptr == root)
                    root = c;
                else
                {
                    if (ptr == parent.lchild)
                        parent.lchild = c;
                    else
                        parent.rchild = c;
                }
            }
            count--;
            return true;
        }
        return false;
    }

    // Search for a member  in this member collection  
    // Pre-condition: nil
    // Post-condition: if the member was in this member collection, return the reference of the member object;
    //                 otherwise, return null. This member collection remains unchanged. New Number = old Number.
    public IMember? Search(IMember aMember)
    {
        if (aMember != null)
        {
            BTreeNode ptr = root; // Start at the root

            while (ptr != null && aMember.CompareTo(ptr.member) != 0)
            {
                if (aMember.CompareTo(ptr.member) < 0)
                {
                    ptr = ptr.lchild;
                }
                else
                {
                    ptr = ptr.rchild;
                }
            }

            if (ptr != null)
                return ptr.member; // Found the member

            return null; // Not found
        }

        return null; // Invalid input
    }



    // Return an array that contains all the members in this member collection and the members in the array are sorted in the alphabetical order by their names
    // Pre-condition: nil
    // Post-condition: if the member collection was not empty, return an array that contains all the members in this member collection and the members in the array are sorted in alphabetical order by the members' full name;
    //                  otherwise, return null. This member collection remains unchanged and New Number = old Number.               
    public IMember[]? ToArray()
    {
        if (IsEmpty())
        {
            return null;
        }

        IMember[] memberArray = new IMember[count]; 
        int index = 0;
        InOrderTraverse(root, memberArray, ref index);
        return memberArray;
    }

    private void InOrderTraverse(BTreeNode root, IMember[] members, ref int index)
    {
        if (root != null)
        {
            InOrderTraverse(root.lchild, members, ref index);
            members[index++] = root.member; 
            InOrderTraverse(root.rchild, members, ref index);
        }   
    }

    // Clear this member collection
    // Pre-condition: nil
    // Post-condition: all the members in this member collection have been removed from this member collection, if any, and New Number = 0. 
    public void Clear()
    {
        root = null;
        count = 0;
    }
}

