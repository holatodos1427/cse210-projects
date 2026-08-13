using System;

namespace ExerciseTracking
{
    // Base class for every exercise. Holds what they all have in
    // common: what kind it is, when it happened, and how long it lasted.
    public abstract class Activity
    {
        private string _name;
        private DateTime _date;
        private int _minutes;

        public Activity(string name, DateTime date, int minutes)
        {
            _name = name;
            _date = date;
            _minutes = minutes;
        }

        // Protected so derived classes can use it in their own math,
        // but it's still hidden from everything outside the class.
        protected int GetMinutes()
        {
            return _minutes;
        }

        // Each activity calculates these differently, so we just
        // declare them here and let the derived classes fill them in.
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Builds the summary line. Works for any activity since it
        // just calls the methods above instead of doing its own math.
        public virtual string GetSummary()
        {
            string date = _date.ToString("dd MMM yyyy");
            return $"{date} {_name} ({_minutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}
