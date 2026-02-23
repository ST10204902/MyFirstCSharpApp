using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstCSharpApp
{
    internal class GymMember
    {
        // Variables to hold user input and processed data

        public string FullName { get; set; }
        public string Email { get; set; }
        public string WorkoutType { get; set; }
        public string FirstName { get; set; }
        public string WorkoutPretty { get; set; }
        public string UsernameSuggestion { get; set; }
        public bool HasValidEmailFormat { get; set; }
        public int? Age { get; set; }

        /// <summary>
        /// Normalizes and formats user-related string properties, including full name, email, and workout type.
        /// </summary>
        /// <remarks>This method trims whitespace from the FullName, Email, and WorkoutType properties,
        /// converts Email and WorkoutType to lowercase, and updates FirstName and WorkoutPretty based on the processed
        /// values. Call this method after setting the relevant properties to ensure consistent formatting.</remarks>
        public void StringManipulation()
        {
            FullName = FullName.Trim();
            Email = Email.Trim().ToLower();
            WorkoutType = WorkoutType.Trim().ToLower();

            string[] nameParts = FullName.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            FirstName = nameParts.Length > 0 ? nameParts[0] : "Student";

            WorkoutPretty = WorkoutType.Length > 0
                ? char.ToUpper(WorkoutType[0]) + WorkoutType.Substring(1)
                : "Unknown";
        }

        /// <summary>
        /// Demonstrates the use of implicit typing with the var keyword and updates related properties based on the
        /// current email and user information.
        /// </summary>
        /// <remarks>This method checks the format of the current email address and generates a username
        /// suggestion based on the user's first name and workout type. It is intended for illustrative or internal use
        /// to show how implicit typing can be used in C#.</remarks>
        public void UsingVarAndImplictTypes()
        {
            var emailAtIndex = Email.IndexOf('@');
            HasValidEmailFormat = emailAtIndex > 0 && Email.Contains('.');

            UsernameSuggestion = FirstName.ToLower() + "." + WorkoutType;
            UsernameSuggestion = UsernameSuggestion.Replace(" ", "");
        }

        /// <summary>
        /// Prompts the user to enter their age and updates the Age property with the entered value or null if no input
        /// is provided.
        /// </summary>
        /// <remarks>If the user enters a valid integer, the Age property is set to that value. If the
        /// input is empty or not a valid integer, Age is set to null. This method is intended for interactive console
        /// applications.</remarks>
        public void UsingNullableTypes()
        {
            Console.Write("Enter your age (optional, press Enter to skip): ");
            string ageInput = Console.ReadLine();

            Age = null;

            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (int.TryParse(ageInput, out int parsedAge))
                {
                    Age = parsedAge;
                }
            }
        }

        /// <summary>
        /// Displays a summary of the user's profile information to the console.
        /// </summary>
        /// <remarks>The summary includes the user's name, first name, email address, email format
        /// validity, workout information, suggested username, and age if available. The method pauses execution and
        /// waits for the user to press Enter before exiting.</remarks>
        public void ProfileSummary()
        {
            Console.WriteLine();
            Console.WriteLine("=== Profile Summary ===");

            Console.WriteLine($"Name: {FullName}");
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Email format looks valid: {HasValidEmailFormat}");
            Console.WriteLine($"Workout: {WorkoutPretty}");
            Console.WriteLine($"Suggested username: {UsernameSuggestion}");

            if (Age.HasValue)
            {
                Console.WriteLine($"Age: {Age.Value}");
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

    internal class Program
    {
        static void Main(string[] args)
        {
            //Your first lines of code
            //Replaces Java's System.out.println() method
            Console.WriteLine("Hello World!");

            Console.WriteLine("--- Gym Sign Up Form ---");

            GymMember FirstGymMember = new GymMember();

            Console.Write("Enter your full name: ");
            FirstGymMember.FullName = Console.ReadLine() ?? "";

            Console.Write("Enter your email address: ");
            FirstGymMember.Email = Console.ReadLine() ?? "";

            Console.Write("Favourite workout type (e.g., legs, cardio, push): ");
            FirstGymMember.WorkoutType = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Thanks. Processing your info...\n");

            // Process the inputs using the defined methods
            FirstGymMember.StringManipulation();
            FirstGymMember.UsingVarAndImplictTypes();
            FirstGymMember.UsingNullableTypes();
            FirstGymMember.ProfileSummary();
        }
    }
}
