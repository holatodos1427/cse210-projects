using System;

namespace ExerciseTracking
{
   
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


        protected int GetMinutes()
        {
            return _minutes;
        }


        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            string date = _date.ToString("dd MMM yyyy");
            return $"{date} {_name} ({_minutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}
