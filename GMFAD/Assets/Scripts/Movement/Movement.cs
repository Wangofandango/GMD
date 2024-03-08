using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 10.0f;
        
        private Rigidbody2D _rb;


        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 input)
        {
            
            _rb.velocity = input * movementSpeed;
            
            if (input != Vector2.zero) 
                Rotate(input);
        }

        private void Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}