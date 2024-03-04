using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float movementSpeed = 10.0f;

    private Rigidbody2D _rb;
    private Vector2 _movementDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         _movementDirection = ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private Vector2 ProcessInputs()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_movementDirection.x , _movementDirection.y) * movementSpeed;
    }
    
}
