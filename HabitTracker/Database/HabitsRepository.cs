using Database.Models;
using Microsoft.Data.Sqlite;
using System.Text;

namespace Database
{
    static public class HabitsRepository
    {
        public static bool CreateHabitsTable(string databaseName)
        {
            using (var connection = new SqliteConnection($"Data Source={databaseName}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                CREATE TABLE habits (
                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    title TEXT NOT NULL,
                    units TEXT NOT NULL,
                    value INTEGER NOT NULL,
                    timestamp INTEGER NOT NULL,
                    username TEXT NOT NULL
                );
                ";

                Console.WriteLine("Creating tables...");
                command.ExecuteNonQuery();
            }
            return true;
        }

        public static long InsertHabit(string databaseName, Habit habit)
        {
            using (var connection = new SqliteConnection($"Data Source={databaseName}"))
            {
                connection.Open();

                var sql =
                @"
                INSERT INTO habits (title, units, value, timestamp, username)
                VALUES ($title, $units, $value, $timestamp, $username);
                ";

                using var command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("$title", habit.Title);
                command.Parameters.AddWithValue("$units", habit.Units);
                command.Parameters.AddWithValue("$value", habit.Value);
                command.Parameters.AddWithValue("$timestamp", habit.Timestamp);
                command.Parameters.AddWithValue("$username", habit.Username);

                command.ExecuteNonQuery();

                command.CommandText =
                @"
                    SELECT last_insert_rowid()
                ";
                var newId = (long)command.ExecuteScalar();

                return newId;
            }
        }

        public static Habit? GetHabit(string databaseName, long habitId)
        {
            var sql = @"
                SELECT * FROM habits
                WHERE id = $habitId;";
            try
            {
                using (var connection = new SqliteConnection($"Data Source={databaseName}"))
                {
                    connection.Open();

                    using var command = new SqliteCommand(sql, connection);
                    command.Parameters.AddWithValue("$habitId", habitId);

                    using var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var title = reader.GetString(1);
                            var units = reader.GetString(2);
                            var value = reader.GetInt32(3);
                            var timestamp = reader.GetInt64(4);
                            var username = reader.GetString(5);

                            return new Habit(title, units, value, timestamp, username);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No habit found. ({habitId})");
                    }
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
