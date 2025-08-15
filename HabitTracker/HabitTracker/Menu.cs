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

            Console.Clear();
            Console.WriteLine($"I'll use {username} for all of your habits");

            return username;

        }
        
        public static string Main()
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("(V) View logged habits");
            Console.WriteLine("(R) Record a habit");
            Console.WriteLine("(E) Edit a habit");
            Console.WriteLine("(D) Delete a habit");
            Console.WriteLine("(N) Nuke all habits");
            Console.WriteLine("(C) Close the application");

            var userSelection = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userSelection))
            {
                Console.Clear();

                Console.WriteLine("Not a valid option");
                userSelection = string.Empty;
            }

            return userSelection;
        }
    }
}
