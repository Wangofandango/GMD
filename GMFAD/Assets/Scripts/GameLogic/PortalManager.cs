using System;
using System.Collections.Generic;
using Interactables.Recruitment;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class PortalManager : MonoBehaviour
    {
        private PortalSpawner PortalSpawner { get; set; }
        
        
        public List<PortalProgress> ActivePortals { get; set; }
        
        //Locations to spawn portals
        public List<PortalData> PossiblePortals { get; set; }

        
        public enum PortalLocation
        {
            NorthEast,
            NorthWest,
            Middle,
            SouthEast,
            SouthWest
        }

        public class PortalData
        {
            public PortalData(Vector2 position, PortalLocation location)
            {
                Position = position;
                Location = location;
            }

            public Vector2 Position { get; set; }
            
            public PortalLocation Location { get; set; }
            
        }
        
        public class PortalProgress
        {
            public PortalProgress(PortalData portalData)
            {
                PortalData = portalData;
                GuildmembersInside = new List<GameObject>();
                Progress = 0;
            }

            public PortalData PortalData { get; set; }
            
            public List<GameObject> GuildmembersInside { get; set; }
            
            public int Progress { get; set; }
        }
        
        private void Awake()
        {
            ActivePortals = new List<PortalProgress>();
            PortalSpawner = GetComponent<PortalSpawner>();
            
            // Initialize the list of portal locations
            PossiblePortals = new List<PortalData>
            {
                new PortalData(new Vector2(-0.289f, 5.04f), PortalLocation.NorthEast),
                new PortalData(new Vector2(-4.921f, 5), PortalLocation.NorthWest),
                new PortalData(new Vector2(-2.645f, 3.254f), PortalLocation.Middle),
                new PortalData(new Vector2(-0.199f, 1.435f),  PortalLocation.SouthEast),
                new PortalData(new Vector2(-4.786f, 1.319f), PortalLocation.SouthWest)
            };
        }
        
        public PortalProgress GetRandomPortalPosition()
        {
            // Choose a random portal location from the list
            int randomIndex = Random.Range(0, ActivePortals.Count);
            return ActivePortals[randomIndex];
        }
        
        public void InitiatePortals(int roundNumber)
        {
            // Clear the list of active portals
            ActivePortals.Clear();
            
            
            int numPortalsToSpawn;

            // Define logic based on round number ranges
            if (roundNumber >= 1 && roundNumber <= 2)
            {
                numPortalsToSpawn = 1;
            }
            else if (roundNumber >= 3 && roundNumber <= 4)
            {
                numPortalsToSpawn = 2;
            }
            else if (roundNumber >= 5 && roundNumber <= 6)
            {
                numPortalsToSpawn = 3;
            }
            else if (roundNumber >= 7 && roundNumber <= 8)
            {
                numPortalsToSpawn = 4;
            }
            else
            {
                numPortalsToSpawn = 5;
            }
            
            Debug.Log(numPortalsToSpawn);
            // Spawn portals using a loop
            for (int i = 0; i < numPortalsToSpawn; i++)
            {
                // Choose a random portal location from the list
                int randomIndex = Random.Range(0, PossiblePortals.Count);
                Vector2 spawnPosition = PossiblePortals[randomIndex].Position;

                // Store the portal data in the ActivePortals list
                ActivePortals.Add(new PortalProgress(PossiblePortals[randomIndex]));
                
                // Spawn the portal at the chosen position
                PortalSpawner.SpawnPortal(spawnPosition);

            }
        }


        public void GuildmemberReachedPortal(GameObject o, PortalLocation randomPortalLocation, CharacterStats dataStats)
        {
            // Handle the logic for when a guildmember reaches a portal
            Debug.Log("Guildmember reached portal at " + randomPortalLocation);
            
            // Add the guildmember to the list of guildmembers inside the portal
            foreach (var portal in ActivePortals)
            {
                if (portal.PortalData.Location == randomPortalLocation)
                {
                    portal.GuildmembersInside.Add(o);
                }
            }
        }

        private void Update()
        {
            // Check if any guildmembers are inside the portals
            foreach (var portal in ActivePortals)
            {
                if (portal.GuildmembersInside.Count > 0)
                {
                    // Handle the logic for when guildmembers are inside the portal
                    
                    // Increase the progress of the portal
                    portal.Progress++;
                    
                    // Check if the progress is at the maximum value
                    if (portal.Progress >= 100)
                    {
                        // Remove the guildmembers from the portal, by activating them again.
                        foreach (var guildmember in portal.GuildmembersInside)
                        {
                            guildmember.SetActive(true);
                        }
                        
                        //Remove the portal gameobject
                        PortalSpawner.RemovePortal(portal.PortalData.Position);
                        
                        // Remove the portal from the list of active portals
                        ActivePortals.Remove(portal);
                        Debug.Log("Portal at " + portal.PortalData.Location + " has been completed!");

                        if (ActivePortals.Count == 0)
                        {
                            Debug.Log("All portals have been completed!");
                            
                            // Start the next round
                            GameManager.Instance.NextRound();
                        }
                        
                    }
                }
            }
        }
    }
}