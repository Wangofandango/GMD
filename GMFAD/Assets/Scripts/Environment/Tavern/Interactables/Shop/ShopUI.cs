using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Interactables.Shop
{
    public class ShopUI : MonoBehaviour, IUserInterface
    {
        public void Show()
        {
            gameObject.SetActive(true);        
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}