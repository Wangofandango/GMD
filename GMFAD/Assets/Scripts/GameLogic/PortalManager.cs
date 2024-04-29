using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PortalManager : MonoBehaviour
    {
        private PortalSpawner PortalSpawner { get; set; }
        
        //Locations to spawn portals
        public List<Vector2> PortalLocations { get; set; }
        private void Awake()
        {
            PortalSpawner = GetComponent<PortalSpawner>();
            
            // Initialize the list of portal locations
            PortalLocations = new List<Vector2>
            {
                new Vector2(-0.289f, 5.04f),
                new Vector2(-4.921f, 5),
                new Vector2(-2.645f, 3.254f),
                new Vector2(-0.199f, 1.435f),
                new Vector2(-4.786f, 1.319f)
            };
        }
        
        public void InitiatePortals(int roundNumber)
        {
            // Calculate the number of portals to spawn based on round number
            int numPortalsToSpawn = Mathf.Clamp(roundNumber / 2, 1, PortalLocations.Count); // Ensures at least 1 portal

            Debug.Log(numPortalsToSpawn);
            // Spawn portals using a loop
            for (int i = 0; i < numPortalsToSpawn; i++)
            {
                // Choose a random portal location from the list
                int randomIndex = Random.Range(0, PortalLocations.Count);
                Vector2 spawnPosition = PortalLocations[randomIndex];

                // Spawn the portal at the chosen position
                PortalSpawner.SpawnPortal(spawnPosition);

            }
        }
    }
}