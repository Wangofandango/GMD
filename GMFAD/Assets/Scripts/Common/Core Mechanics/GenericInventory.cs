using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Core_Mechanics
{
    public class GenericInventory : MonoBehaviour
    {
        public List<IInventoryItem> Items { get; set; } = new();
        public event Action<IInventoryItem> OnItemAdded; 
        public event Action<IInventoryItem> OnItemRemoved;


        public void AddItem(IInventoryItem item)
        {
            Items.Add(item);
            OnItemAdded?.Invoke(item); // Trigger the event with the added item
        }

        public void RemoveItem(IInventoryItem item)
        {
            Items.Remove(item);
            OnItemRemoved?.Invoke(item); // Trigger the event with the removed item
        }

        public List<IInventoryItem> GetItems()
        {
            return Items;
        }
    }
}