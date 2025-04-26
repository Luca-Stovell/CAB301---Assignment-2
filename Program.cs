using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Outer loop for increasing the number of members
        for (int iteration = 1; iteration <= 10; iteration++)
        {
            var MemberCollectionTest = CreateMembers(iteration);
            var memberArray = MemberCollectionTest.ToArray(); // Store the result of ToArray

            // Optional: Print members if you want to display them
            /*foreach (var member in memberArray)
            {
                Console.WriteLine(member.ToString());
            }*/
        }
    }

    static int GenerateRandomNumber()
    {
        int seed = (int)DateTime.Now.Ticks;
        Random rnd = new Random(seed);
        return rnd.Next(0, 100);
    }

    static public MemberCollection CreateMembers(int iteration)
    {
        var collection = new MemberCollection();  // Initialize collection

        // Calculate number of members based on the iteration number
        int numberOfMembers = iteration * 1000; // Increase the number of members in each iteration by a factor of 5
        Stopwatch stopwatch = new Stopwatch();  // Start stopwatch before the loop
        stopwatch.Start();

        // Loop through and insert members
        for (int i = 1; i <= numberOfMembers; i++)
        {
            string firstName = $"{i}";
            string lastName = "M";
            string contactNumber = $"000000000{i}";
            string pin = "0000";
            collection.Insert(new Member(firstName, lastName, contactNumber, pin)); // Insert member
        }

        stopwatch.Stop();  // Stop stopwatch after the loop

        Console.WriteLine($"{numberOfMembers} members inserted in iteration {iteration}.");
        Console.WriteLine($"Total Execution Time for iteration {iteration}: {stopwatch.ElapsedMilliseconds} ms");

        return collection; // Return the collection with inserted members
    }
}
