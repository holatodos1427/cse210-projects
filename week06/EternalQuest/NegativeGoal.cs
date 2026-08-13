using System;

namespace EternalQuest
{
    // this is a "negative goal" for bad habits. Instead of gaining points, you lose them every time you record it. It is like duolingo where you lose points if you don't practice every day.
    public class NegativeGoal : Goal
    {
        private int _timesRecorded;

        public NegativeGoal(string name, string description, int points) : base(name, description, points)
        {
            _timesRecorded = 0;
        }

        // saved goal from a file.
        public NegativeGoal(string name, string description, int points, int timesRecorded) : base(name, description, points)
        {
            _timesRecorded = timesRecorded;
        }

        public override void RecordEvent()
        {
            _timesRecorded++;
            PointsEarned = -_points;
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName} ({_description}) -- slipped up {_timesRecorded} times";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal:{_shortName},{_description},{_points},{_timesRecorded}";
        }
    }
}
