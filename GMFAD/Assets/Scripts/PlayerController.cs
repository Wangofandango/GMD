using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float interactionDistance = 3.0f;

    private Rigidbody2D _rb;
    private Vector2 _movementDirection;

    public PlayerInputActions PlayerControls;

    private InputAction move;
    private InputAction interact;

    private int _interactionLayer;

    private void OnEnable()
    {
        move = PlayerControls.Player.Move;
        move.Enable();

        move.performed += ctx => _movementDirection = ctx.ReadValue<Vector2>();
        move.canceled += StopMovement;

        interact = PlayerControls.Player.Interact;
        interact.Enable();

        interact.performed += Interact;
    }

    private void OnDisable()
    {
        move.Disable();
        interact.Disable();
    }

    private void Awake()
    {
        PlayerControls = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        LayerMask interactableLayer = LayerMask.GetMask(ProjectData.Layers.Interactable.Name) | LayerMask.GetMask(ProjectData.Layers.Default.Name);
        //LayerMask playerLayer = LayerMask.GetMask(ProjectData.Layers.Player.Name);
        //int ignorePlayerLayer = ~playerLayer;
        _interactionLayer = interactableLayer;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_movementDirection.x == 0 && _movementDirection.y == 0) return;


        _rb.velocity = _movementDirection * movementSpeed;
        Rotate(_movementDirection);
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        _movementDirection = Vector2.zero;
        _rb.velocity = Vector2.zero;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //Display a raycast in the direction the player is facing, also make the raycast visible
        var position = transform.position;

        var direction = transform.up;
        Debug.DrawRay(position, direction, Color.red, interactionDistance);
        //Make a raycast in the direction the player is facing
        RaycastHit2D hit = Physics2D.Raycast(position, direction, interactionDistance, _interactionLayer);
        //Change this if statement to avoid nullreference exception
        if (hit.collider.TryGetComponent(out Iinteractable interactable))
        {
            interactable.Interact(gameObject);
        }
    }

    private void Rotate(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}

    
    
