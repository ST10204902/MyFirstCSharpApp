using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSharpApp
{
    internal class Program
    {
        // Static variables to store user inputs and processed data in memory
        static string fullName;
        static string email;
        static string workoutType;
        static string firstName;
        static string workoutPretty;
        static string usernameSuggestion;
        static bool hasValidEmailFormat;
        static int? age;

        static void Main(string[] args)
        {
            //Your first lines of code
            //Replaces Java's System.out.println() method
            Console.WriteLine("Hello World!");

            Console.WriteLine("--- Gym Sign Up Form ---");

            Console.Write("Enter your full name: ");
            fullName = Console.ReadLine() ?? "";

            Console.Write("Enter your email address: ");
            email = Console.ReadLine() ?? "";

            Console.Write("Favourite workout type (e.g., legs, cardio, push): ");
            workoutType = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Thanks. Processing your info...\n");

            // Process the inputs using the defined methods
            StringManipulation();
            UsingVarAndImplictTypes();
            UsingNullableTypes();
            ProfileSummary();

            
        }
        /// <summary>
        /// Performs string normalization and formatting for user-related fields such as full name, email, and workout
        /// type.
        /// </summary>
        /// <remarks>Trims whitespace from input fields and converts email and workout type to lowercase.
        /// The method also extracts the first name from the full name and formats the workout type for display. This
        /// method should be called before using these fields to ensure consistent formatting.</remarks>
        static void StringManipulation()
        {
            fullName = fullName.Trim();
            email = email.Trim().ToLower();
            workoutType = workoutType.Trim().ToLower();

            string[] nameParts = fullName.Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            firstName = nameParts.Length > 0 ? nameParts[0] : "Student";

            workoutPretty = workoutType.Length > 0
                ? char.ToUpper(workoutType[0]) + workoutType.Substring(1)
                : "Unknown";
        }

        static void UsingVarAndImplictTypes()
        {
            var emailAtIndex = email.IndexOf('@');
            hasValidEmailFormat = emailAtIndex > 0 && email.Contains('.');

            usernameSuggestion = firstName.ToLower() + "." + workoutType;
            usernameSuggestion = usernameSuggestion.Replace(" ", "");
        }

        static void UsingNullableTypes()
        {
            Console.Write("Enter your age (optional, press Enter to skip): ");
            string ageInput = Console.ReadLine();

            age = null;

            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (int.TryParse(ageInput, out int parsedAge))
                {
                    age = parsedAge;
                }
            }
        }

        static void ProfileSummary()
        {
            Console.WriteLine();
            Console.WriteLine("=== Profile Summary ===");

            Console.WriteLine($"Name: {fullName}");
            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Email format looks valid: {hasValidEmailFormat}");
            Console.WriteLine($"Workout: {workoutPretty}");
            Console.WriteLine($"Suggested username: {usernameSuggestion}");

            if (age.HasValue)
            {
                Console.WriteLine($"Age: {age.Value}");
            }
            else
            {
                Console.WriteLine("Age: Not provided");
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
