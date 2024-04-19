using System;

namespace Data
{
    public class Worker
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Position Position { get; }
        public Seniority Seniority { get; }

        
        public Worker(string firstName, string lastName, Position position, Seniority seniority)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Seniority = seniority;
        }

        protected bool Equals(Worker other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Position == other.Position && Seniority == other.Seniority;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Worker)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, (int)Position, (int)Seniority);
        }
    }
}