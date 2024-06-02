using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    public class GameManager : MonoBehaviour
    {
        // This is really the only blurb of code you need to implement a Unity singleton
        private static GameManager _Instance;
        public static GameManager Instance
        {
            get
            {
                if (!_Instance)
                {
                    _Instance = new GameObject()
                        .AddComponent<GameManager>();

                    _Instance.GameLogic = GameObject.Find("GameLogic");

                    InstansiateFields();

                    SubscribeToEvents();
                    
                    // name it for easy recognition
                    _Instance.name = _Instance.GetType().ToString();
                    // mark root as DontDestroyOnLoad();
                    DontDestroyOnLoad(_Instance.gameObject);
                }
                return _Instance;
            }
        }

        private static void SubscribeToEvents()
        {
            Instance.PortalManager.DungeonCleared += OnDungeonCleared;
        }

        private static void OnDungeonCleared()
        {
            //Add gold to the user
            int minGold = 10;
            int maxGold = 30;
            int gold = UnityEngine.Random.Range(minGold, maxGold);
            FindObjectOfType<GoldCounter>().AddGold(gold);
        }

        public GameObject GameLogic;
        public PortalManager PortalManager { get; set; }
        public int RoundNumber { get; set; }

        

        private static void InstansiateFields()
        {
            _Instance.PortalManager = _Instance.GameLogic.GetComponentInChildren<PortalManager>();
        }
        

        public void StartGame()
        {
            RoundNumber = 1;
            
            PortalManager.InitiatePortals(RoundNumber);
            Debug.Log("Game has started!");
        }

        public void NextRound()
        {
            RoundNumber++;
            
            FindObjectOfType<RoundCounter>().NextRound(RoundNumber); //This doesn't seem to be very optimized though
            
            Debug.Log(RoundNumber);
            PortalManager.InitiatePortals(RoundNumber);
            Debug.Log("Round " + RoundNumber + " has started!");
        }
    }
}