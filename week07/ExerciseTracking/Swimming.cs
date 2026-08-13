using System;

namespace ExerciseTracking
{
    // Swimming: we're given the number of laps, and each lap is 50
    // meters, so distance comes from that.
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps) : base("Swimming", date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // Laps to km, then km to miles.
            return _laps * 50 / 1000.0 * 0.62;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / GetMinutes()) * 60;
        }

        public override double GetPace()
        {
            return GetMinutes() / GetDistance();
        }
    }
}
