using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSharpApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Your first lines of code
            //Replaces Java's System.out.println() method
            Console.WriteLine("Hello World!");

            Console.WriteLine("--- Gym Sign Up Form ---");

            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine() ?? "";

            Console.Write("Enter your email address: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Favourite workout type (e.g., legs, cardio, push): ");
            string workoutType = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Thanks. Processing your info...\n");

            Console.WriteLine("Press any key to end program...");


            Console.ReadLine();


            //MyFirstMethod()
            //GymSignUpForm()
            //UsingVarAndImplictTypes()
            //UsingNullableTypes()


        }

        static void MyFirstMethod()
        {
            Console.WriteLine("This is my first method!");

            int potato = 5;
            Console.WriteLine($"The value of potato is: {potato}");
        }



        static void StringManipulation()
        {
            fullName = fullName.Trim();
            email = email.Trim().ToLower();
            workoutType = workoutType.Trim().ToLower();

            string[] nameParts = fullName.Split(' ', 
                StringSplitOptions.RemoveEmptyEntries);
            string firstName = nameParts.Length > 0 ? nameParts[0] : "Student";

            string workoutPretty = workoutType.Length > 0
                ? char.ToUpper(workoutType[0]) + workoutType.Substring(1)
                : "Unknown";
        }

        static void UsingVarAndImplictTypes()
        {
            var emailAtIndex = email.indexOf('@');
            var hasValidEmailFormat = emailAtIndex > 0 && email.Contains('.');

            var usernameSuggestion = firstName.ToLower() + "." + workoutType;
            usernameSuggestion = usernameSuggestion.Replace(" ", "");
        }

        static void UsingNullableTypes()
        {
            Console.Write("Enter your age (optional, press Enter to skip): ");
            string? ageInput = Console.ReadLine();

            int? age = null;

            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (int.TryParse(ageInput, out int parsedAge))
                {
                    age = parsedAge;
                }
            }
        }


        //static void ProfileSummary()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("=== Profile Summary ===");

        //    Console.WriteLine($"Name: {fullName}");
        //    Console.WriteLine($"First name: {firstName}");
        //    Console.WriteLine($"Email: {email}");
        //    Console.WriteLine($"Email format looks valid: {hasValidEmailFormat}");
        //    Console.WriteLine($"Workout: {workoutPretty}");
        //    Console.WriteLine($"Suggested username: {usernameSuggestion}");

        //    if (age.HasValue)
        //    {
        //        Console.WriteLine($"Age: {age.Value}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Age: Not provided");
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine("Press Enter to exit.");
        //    Console.ReadLine();

        //}

        //Class activity:
        //1. Change username suggestion to:
        //      Use only first letter of first name + surname
        //      Add the last 2 digits of the year (hardcode year)
        //Hints: substrings and nameParts[nameParts.Length - 1]
        //2.  Add height input (optional)
        //      Enter height in cm (hint: double? heightCm)
        //      Display it or if null, return something appropriate
        //3.  HARD: cleanup user workout text
        //      If a user types:
        //          "leg day", "leg-day", "LEG DAY"
        //      Store it as "Leg Day", replacing - with space.
        //      Splitting words and capitalising each
    }
}
