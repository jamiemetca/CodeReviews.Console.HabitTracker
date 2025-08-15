namespace Database.Models
{
    public class Habit
    {
        public Habit(string title, string units, int value, string username)
        {
            Title = title;
            Units = units;
            Value = value;
            Username = username;
        }

        public Habit(string title, string units, int value, long timeStamp, string username)
        {
            Title = title;
            Units = units;
            Value = value;
            Timestamp = timeStamp;
            Username = username;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Units { get; set; }
        public int Value { get; set; }
        public long Timestamp { get; set; }
        public string Username { get; set; }
    }
}
