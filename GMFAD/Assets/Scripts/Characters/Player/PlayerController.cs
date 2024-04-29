using GameLogic;
using Interaction_System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputActions _playerControls;
         
        private Interactor interactor;
        [SerializeField] private Movement.Movement _movement;
        
        GameManager gameManager;

        private InputAction _movementInput;
        private InputAction _interactionInput;
        private void Awake()
        {
            _playerControls = new PlayerInputActions();
        }

        private void Start()
        {
            _movement = GetComponent<Movement.Movement>();
            interactor = GetComponentInChildren<Interactor>();
            
            //Start the game
            gameManager = GameManager.Instance;
            gameManager.StartGame();
        }

        private void OnEnable()
        {
            _movementInput = _playerControls.Player.Move;
            _movementInput.Enable();
            
            _interactionInput = _playerControls.Player.Interact;
            _interactionInput.Enable();
        }

        private void OnDisable()
        {
            _movementInput.Disable();
        }

        private void Update()
        {
            Vector2 movementInput = this._movementInput.ReadValue<Vector2>();
            _movement.Move(movementInput);
            
            if (_interactionInput.triggered)
            {
                interactor.CheckForInteractions();
            }
        }

        private void FixedUpdate()
        {
        }
    }
}

    
    
