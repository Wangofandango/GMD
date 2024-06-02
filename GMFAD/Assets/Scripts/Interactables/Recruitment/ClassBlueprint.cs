﻿using Common;
using Common.Utils;

namespace Interactables.Recruitment
{
    public class ClassBlueprint : Enumeration<ClassBlueprint>
    {
        public Range<int> Physical { get; set; } // Using Range<int> for stat ranges
        public Range<int> Magical { get; set; }
        public Range<int> Health { get; set; }

        public Range<int> MovementSpeed { get; set; }

        public ClassType ClassType { get; set; }

        public static readonly ClassBlueprint Warrior = new ClassBlueprint(0, "Warrior", ClassType.Warrior,
            new Range<int>(30, 40), new Range<int>(10, 30), new Range<int>(180, 220), new Range<int>(5, 8));

        public static readonly ClassBlueprint Mage = new ClassBlueprint(1, "Mage", ClassType.Mage,
            new Range<int>(10, 30), new Range<int>(40, 60), new Range<int>(120, 160), new Range<int>(2, 4));

        public static readonly ClassBlueprint Assassin = new ClassBlueprint(2, "Fighter", ClassType.Assassin,
            new Range<int>(50, 70), new Range<int>(30, 50), new Range<int>(80, 120), new Range<int>(6, 10));

        public static readonly ClassBlueprint Healer = new ClassBlueprint(3, "Healer", ClassType.Healer,
            new Range<int>(20, 40), new Range<int>(20, 40), new Range<int>(140, 180), new Range<int>(4, 6));

        public static readonly ClassBlueprint[] Classes = { Warrior, Mage, Assassin, Healer };

        protected ClassBlueprint(int value, string name, ClassType classType, Range<int> physical, Range<int> magical,
            Range<int> health, Range<int> movementSpeed) : base(value, name)
        {
            Physical = physical;
            Magical = magical;
            Health = health;
            ClassType = classType;
            MovementSpeed = movementSpeed;
        }
    }

    public enum ClassType
    {
        Warrior,
        Mage,
        Assassin,
        Healer
    }
}