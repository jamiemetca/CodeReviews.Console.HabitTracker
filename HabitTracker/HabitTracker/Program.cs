// TODO: 
// build out the menu options
// When recording a habit we need to accept shorthand dates e.g. today, yesterday, 01/01/2025 13:10
// And convert these to a long to be stored in the db
// After that
// Work on the view all records menu

using Database;
using HabitTracker;
using System.Net.Http.Json;

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
    // Record habit
    // View habits
    // Delete habit
    // Update habit
    // Nuke everything

while (true)
{
    USERNAME = Menu.GetUsername(USERNAME);
    var isFirstMenuLoad = true;

    var menuChoice = string.Empty;
    while (menuChoice != "c")
    {
        menuChoice = Menu.Main(USERNAME, isFirstMenuLoad);
        isFirstMenuLoad = false;

        Console.WriteLine($"Selected option");

        switch(menuChoice)
        {
            case "r":
                var habit = Menu.InsertHabit(USERNAME);
                HabitsRepository.InsertHabit(DATABASE_NAME, habit);
                break;
            default:
                break;
        }
    }

    Console.WriteLine($"Closing app");

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
