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
    }
}