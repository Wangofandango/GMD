using System;
using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5.0f;
        private Rigidbody2D _rb;
        
        //Animation
        private Animator _animator;
        private static readonly int MoveX = Animator.StringToHash("moveX");
        private static readonly int MoveY = Animator.StringToHash("moveY");
        private static readonly int isWalking = Animator.StringToHash("isWalking");
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Vector2 input)
        {
            _rb.velocity = input * movementSpeed;
            
            
            //If i am moving
            if (input != Vector2.zero)
            {
                _animator.SetFloat(MoveX, input.x);
                _animator.SetFloat(MoveY, input.y);
                _animator.Play("Player_Walk");
                // Left or Right Logic
                if (input.x < 0)
                {
                    _spriteRenderer.flipX = true;
                }
                else
                {
                    _spriteRenderer.flipX = false;
                }
            }
            else
            {
                _animator.Play("Player_Idle");
            }
            
        }

        private void Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}