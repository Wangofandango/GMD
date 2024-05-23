using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject portalPrefab;
        
        
        
        public void SpawnPortal(Vector2 spawnPosition)
        {
            Instantiate(portalPrefab, spawnPosition, Quaternion.identity);
        }

        public void RemovePortal(Vector3 portalDataPosition)
        {
            GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
            foreach (GameObject portal in portals)
            {
                if (portal.transform.position == portalDataPosition)
                {
                    Destroy(portal);
                }
            }
        }
    }
}