using System;
using Common;
using Interactables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Interaction_System
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private float interactionDistance = 3.0f;
        private int _interactionLayer;
        
        private GameObject interactor;
        
        private Vector2 Center => transform.position;
        private void Start()
        {
            _interactionLayer = LayerMask.GetMask("Interactable");
            //Get Parent gameobject
            interactor = transform.parent.gameObject;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Center, interactionDistance);
        }

        public void CheckForInteractions()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Center, interactionDistance, _interactionLayer);
            Collider2D closestCollider = null;
            float minDistance = float.MaxValue;

            foreach (var collider in colliders)
            {
                float distance = Vector2.Distance(Center, collider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCollider = collider;
                }
            }

            if (closestCollider)
            {
                var interactable = closestCollider.GetComponent<Iinteractable>();
                
                interactable?.Interact(interactor);
            }
        }
    }
}