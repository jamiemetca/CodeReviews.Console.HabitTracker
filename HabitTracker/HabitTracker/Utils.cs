using Database.Models;

namespace HabitTracker
{
    public static class Utils
    {
        private static Random _random = new Random();
        public static List<Habit> GenerateRandomHabits(int numberOfHabits, string username)
        {
            var max = DateTime.Now;
            var min = max.AddMonths(-1);

            var habits = new List<Habit>();

            for(int i = 0; i < numberOfHabits; i++)
            {
                var habit = GenerateRandomActivity(username);
                habit.Timestamp = GenerateRandomTime(min, max);
                
                habits.Add(habit);
            }

            return habits;
        }

        private static Habit GenerateRandomActivity(string username)
        {
            var habitsToChooseFrom = new List<Habit>()
            {
                new Habit("Ran", "km", _random.Next(1, 42), username),
                new Habit("Study", "min", _random.Next(10, 120), username),
                new Habit("Read", "pages", _random.Next(1, 100), username),
                new Habit("Press-ups", "reps", _random.Next(1, 42), username),
                new Habit("Meditate", "min", _random.Next(5, 15), username),
                new Habit("Cycle", "km", _random.Next(10, 100), username),
            };

            return habitsToChooseFrom[_random.Next(0, habitsToChooseFrom.Count)];
        }

        private static long GenerateRandomTime(DateTime min, DateTime max)
        {
            var secondsBetweenDates = (int)((max - min).TotalSeconds);
            var randomDiffMilliseconds = (_random.Next(0, secondsBetweenDates) * 1000);

            return ((DateTimeOffset)min).ToUnixTimeMilliseconds() + randomDiffMilliseconds;
        }

    }
}
