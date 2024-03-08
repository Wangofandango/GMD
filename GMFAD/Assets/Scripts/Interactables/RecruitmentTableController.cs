using UnityEngine;

namespace Interactables
{
    public class RecruitmentTableController : MonoBehaviour, Iinteractable
    {

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Interact(GameObject interactor)
        {
            if (interactor.CompareTag("Player"))
            {
                Debug.Log("Interacted with Recruitment Table");
                // InitiateRecruitmentUI();
            }
        }

    }
}

