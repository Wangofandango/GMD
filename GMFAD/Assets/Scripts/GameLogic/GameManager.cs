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
        
        public GameObject GameLogic;
        public PortalManager PortalManager { get; set; }
        public int RoundNumber { get; set; }
        
        public GoldCounter GoldCounter { get; set; }
        
        public RoundCounter RoundCounter { get; set; }
        
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
            _Instance.GoldCounter.AddGold(gold);
        }
        

        private static void InstansiateFields()
        {
            _Instance.PortalManager = _Instance.GameLogic.GetComponentInChildren<PortalManager>();
            _Instance.GoldCounter = FindObjectOfType<GoldCounter>();
            _Instance.RoundCounter = FindObjectOfType<RoundCounter>();
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
            
            RoundCounter.NextRound(RoundNumber); 
            
            PortalManager.InitiatePortals(RoundNumber);
            Debug.Log("Round " + RoundNumber + " has started!");
        }
    }
}