using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Core_Mechanics
{
    public class GenericInventory<T> : MonoBehaviour
    {
        public List<T> Items { get; set; }
        public event Action<T> OnItemAdded; 
        public event Action<T> OnItemRemoved; 
        
        
        public GenericInventory()
        {
            Items = new List<T>();
        }

        public void AddItem(T item)
        {
            Items.Add(item);
            OnItemAdded?.Invoke(item); // Trigger the event with the added item
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
            OnItemRemoved?.Invoke(item); // Trigger the event with the removed item
        }

        public List<T> GetItems()
        {
            return Items;
        }
    }
}