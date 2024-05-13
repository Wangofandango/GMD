using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PortalManager : MonoBehaviour
    {
        private PortalSpawner PortalSpawner { get; set; }
        
        
        public List<PortalData> ActivePortals { get; set; }
        
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
        
        private void Awake()
        {
            ActivePortals = new List<PortalData>();
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
        
        public void InitiatePortals(int roundNumber)
        {
            // Clear the list of active portals
            ActivePortals.Clear();
            
            
            // Calculate the number of portals to spawn based on round number
            int numPortalsToSpawn = Mathf.Clamp(roundNumber / 2, 1, PossiblePortals.Count); // Ensures at least 1 portal

            Debug.Log(numPortalsToSpawn);
            // Spawn portals using a loop
            for (int i = 0; i < numPortalsToSpawn; i++)
            {
                // Choose a random portal location from the list
                int randomIndex = Random.Range(0, PossiblePortals.Count);
                Vector2 spawnPosition = PossiblePortals[randomIndex].Position;

                // Store the portal data in the ActivePortals list
                ActivePortals.Add(PossiblePortals[randomIndex]);
                
                // Spawn the portal at the chosen position
                PortalSpawner.SpawnPortal(spawnPosition);

            }
        }
    }
}