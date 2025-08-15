using HabitTracker;

const bool DELETE_DB_ON_CLOSE = true;
const string DATABASE_NAME = "habitTracker.db";
string USERNAME = "User";

// Initialise things
    // Create database if required
        // ID
        // Habit title: Ran
        // Units: km
        // Count: 5
        // Date: today now
        // User - Useless but will add personal touch
    // Populate database with example data (if first start up)

if  (!File.Exists(DATABASE_NAME))
{
    // Generate 100 random habits
    var exampleHabits = Utils.GenerateRandomHabits(100, "Jane Smith");

    Console.WriteLine("Creating database");
    Database.Setup.InitialiseDatabase(DATABASE_NAME, exampleHabits);
}
else
{
    Console.WriteLine($"Database already exists");
}

// Start user loop
    // Request username
    // Exit application
    // View habits
    // Record habit
    // Delete habit
    // Update habit
    // Nuke everything

// TODO: 
    // build out the menu options
    // Start with Record a habit

while (true)
{
    USERNAME = Menu.GetUsername(USERNAME);

    var menuChoice = string.Empty;
    while (string.IsNullOrEmpty(menuChoice))
    {
        menuChoice = Menu.Main();
    }

    Console.WriteLine($"Option chosen {menuChoice}");

    return;
}

if (DELETE_DB_ON_CLOSE)
{
    Console.WriteLine("Waiting for delete command");
    Console.ReadLine();

    Database.Setup.TearDown(DATABASE_NAME);
}

// Create a readme
// Create endpoints
    // Get all habits
    // Create habit
        // Entering "today now" or 01/01/2025 13:04
        // some other shorthands would be useful
    // delete habit
    // edit habit
