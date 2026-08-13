using System;

namespace EternalQuest
{
    // A goal that never really finishes, like reading your scripture every day. You just keep recording it and keep earning points.
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
            _timesCompleted = 0;
        }
        public EternalGoal(string name, string description, int points, int timesCompleted) : base(name, description, points)
        {
            _timesCompleted = timesCompleted;
        }

        public override void RecordEvent()
        {
            _timesCompleted++;
            PointsEarned = _points;
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName} ({_description}) -- recorded {_timesCompleted} times";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName},{_description},{_points},{_timesCompleted}";
        }
    }
}
