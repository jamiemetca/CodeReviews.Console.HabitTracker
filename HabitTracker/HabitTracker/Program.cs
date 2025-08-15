using HabitTracker;

const string DATABASE_NAME = "habitTracker.db";
string USERNAME = "User1";

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
    var exampleHabits = Utils.GenerateRandomHabits(100, "John Smith");

    Console.WriteLine("Creating database");
    Database.Setup.InitialiseDatabase(DATABASE_NAME, exampleHabits);
}
else
{
    Console.WriteLine($"Database already exists");
}

Console.WriteLine("Waiting for delete command");
Console.ReadLine();

Database.Setup.TearDown(DATABASE_NAME);

// Start user loop
    // Request username
    // Exit application
    // View habits
    // Record habit
    // Delete habit
    // Update habit
    // Nuke everything
// Create a readme
// Create endpoints
    // Get all habits
    // Create habit
        // Entering "today now" or 01/01/2025 13:04
        // some other shorthands would be useful
    // delete habit
    // edit habit
