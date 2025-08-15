using Database.Models;
using Microsoft.Data.Sqlite;

namespace Database
{
    static public class Setup
    {
        public static bool InitialiseDatabase(string databaseName, List<Habit> habits)
        {
            HabitsRepository.CreateHabitsTable(databaseName);

            foreach (Habit habit in habits)
            {
                var habitId = HabitsRepository.InsertHabit(databaseName, habit);
                HabitsRepository.GetHabit(databaseName, habitId);
            }

            return true;
        }

        public static void TearDown(string databaseName)
        {
            using (var connection = new SqliteConnection($"Data Source={databaseName}"))
            {
                Console.WriteLine("Removing database");

                // Clean up
                SqliteConnection.ClearAllPools();
                File.Delete("habitTracker.db");
            }
        }
    }
}
