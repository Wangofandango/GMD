﻿using Common.Core_Mechanics;
using UnityEngine;

namespace Interactables.Recruitment
{
    public static class GuildMemberFactory
    {
        //A list of names
        private static string[] _names = {"Bob", "Alice", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Ivan", "Jenny", "Kevin", "Linda", "Michael", "Nancy", "Oscar", "Pamela", "Quincy", "Rachel", "Steve", "Tina", "Ulysses", "Victoria", "Walter", "Xena", "Yvonne", "Zach"};
        
        
        // Generate a new guildmember with a random name and class
        public static GuildMemberData GenerateGuildMember()
        {
            string randomName = _names[Random.Range(0, _names.Length)];
            
            ClassBlueprint randomClass = ClassBlueprint.Classes[Random.Range(0, ClassBlueprint.Classes.Length)];
            
            //From the Class blueprint, make a stats object and give to the guildmember
            CharacterStats stats = CalculateStats(randomClass);
            
            GuildMemberData newGuildMemberData = new GuildMemberData
            {
                ClassType = randomClass.ClassType,
                Stats = stats,
                Name = randomName
            };
            
            return newGuildMemberData;
        }
        
        // Generate a new guildmember with a specific class
        public static GuildMemberData GenerateGuildMember(ClassBlueprint classBlueprint)
        {
            string randomName = _names[Random.Range(0, _names.Length)];
            
            //From the Class blueprint, make a stats object and give to the guildmember
            CharacterStats stats = CalculateStats(classBlueprint);
            
            GuildMemberData newGuildMemberData = new GuildMemberData
            {
                ClassType = classBlueprint.ClassType,
                Stats = stats,
                Name = randomName
            };
            
            return newGuildMemberData;
        }
        
        private static CharacterStats CalculateStats(ClassBlueprint classBlueprint)
        {
            return new CharacterStats
            {
                Health = Random.Range(classBlueprint.Health.Min, classBlueprint.Health.Max),
                Physical = Random.Range(classBlueprint.Physical.Min, classBlueprint.Physical.Max),
                Magical = Random.Range(classBlueprint.Magical.Min, classBlueprint.Magical.Max)
            };
        }
        
        
        
    }
}