using System;

namespace ExerciseTracking
{
    // Cycling: we're given the speed, so distance and pace get
    // calculated from that instead.
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(DateTime date, int minutes, double speed) : base("Cycling", date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * GetMinutes()) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }
    }
}
