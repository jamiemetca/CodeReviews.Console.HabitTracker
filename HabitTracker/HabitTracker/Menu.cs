using Database.Models;

namespace HabitTracker
{
    public static class Menu
    {
        public static string GetUsername(string username)
        {
            Console.Clear();

            Console.WriteLine("Welcome to habit tracker");
            Console.WriteLine($"What should I call you {username}?");

            var userSelection = Console.ReadLine();
            // TODO: validate input
            if (!string.IsNullOrWhiteSpace(userSelection))
            {
                username = userSelection;
            }

            return username;

        }
        
        public static string Main(string username, bool isFirstVisit = false)
        {
            Console.Clear();
            if (isFirstVisit)
            {
                Console.WriteLine($"I'll use {username} for all of your habits");
            }
            string userSelection = string.Empty;

            while(string.IsNullOrEmpty(userSelection))
            {
                Console.WriteLine("Main menu");
                Console.WriteLine("(V) View logged habits");
                Console.WriteLine("(R) Record a habit");
                Console.WriteLine("(E) Edit a habit");
                Console.WriteLine("(D) Delete a habit");
                Console.WriteLine("(N) Nuke all habits");
                Console.WriteLine("(C) Close the application");

                userSelection = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userSelection))
                {
                    Console.Clear();

                    Console.WriteLine("Not a valid option");
                    userSelection = string.Empty;
                }
            }

            return userSelection;
        }

        public static Habit InsertHabit(string username)
        {
            while(true)
            {
                Console.Clear();

                Console.WriteLine("Record a habit");
                Console.WriteLine("--------------");
                Console.WriteLine();

                string title = null;

                while(string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("What did you do?");
                    title = Console.ReadLine();

                    if (string.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("A title is required");
                    }
                }

                string? units = null;

                while(string.IsNullOrEmpty(units))
                {
                    Console.WriteLine("What are the units?");
                    units = Console.ReadLine();

                    if (string.IsNullOrEmpty(units))
                    {
                        Console.WriteLine("A quantity is required");
                    }
                }

                int? value = null;
                while(!value.HasValue)
                {
                    Console.WriteLine("What's the quantity?");
                    value = StringToInt(Console.ReadLine());

                    if (!value.HasValue)
                    {
                        Console.WriteLine("Value must be a number. Try again");
                    }
                }


                string? timestamp = null;
                long? timestamp_long = null;
                while(string.IsNullOrEmpty(timestamp))
                {
                    Console.WriteLine("When did you do it?");
                    timestamp = Console.ReadLine();
                    timestamp_long = StringDateToLong(timestamp);

                    if (!timestamp_long.HasValue)
                    {
                        Console.WriteLine("A date/time is required");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("This is what I have;");
                Console.WriteLine($"You {title} {value} {units} {timestamp}");

                Console.WriteLine();
                Console.WriteLine($"Is that right?");
                Console.WriteLine($"(Y) Yes");
                Console.WriteLine($"(N) No");
                var accept = Console.ReadLine();

                if (accept == "y")
                {
                    return new Habit
                    (
                        title,
                        units,
                        value.Value,
                        timestamp_long.Value,
                        username
                    );
                }
            }
        }

        private static int? StringToInt(string? s)
        {
            if (!string.IsNullOrEmpty(s) && Int32.TryParse(s, out int result))
            {
                return result;
            }

            return null;
        }

        private static long? StringDateToLong(string? s)
        {
            return long.MaxValue;
        }
    }
}
