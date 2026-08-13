using System;

namespace EternalQuest
{
    // a goal that has to be completed a certain number of times before it counts as finished, like going to the temple 10 times. Once you hit the target number, you get a bonus on top of the regular points.
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        // used when loading a saved goal, so we keep the progress that was already made instead of starting back over at zero.
        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
        {
            _amountCompleted = amountCompleted;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                PointsEarned = _points;

                if (_amountCompleted == _target)
                {
                    PointsEarned += _bonus;
                }
            }
            else
            {
                PointsEarned = 0;
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string mark = IsComplete() ? "[X]" : "[ ]";
            return $"{mark} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }
    }
}
