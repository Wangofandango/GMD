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

        
        private static void InstansiateFields()
        {
            _Instance.PortalManager = _Instance.GameLogic.GetComponentInChildren<PortalManager>();
            
            _Instance.RoundNumber = 1;
        }
        

        public void StartGame()
        {
            RoundNumber = RoundNumber++;
            
            PortalManager.InitiatePortals(RoundNumber);
            Debug.Log("Game has started!");
        }

        public void NextRound()
        {
            RoundNumber = RoundNumber++;
            
            PortalManager.InitiatePortals(RoundNumber);
            Debug.Log("Round " + RoundNumber + " has started!");
        }
    }
}