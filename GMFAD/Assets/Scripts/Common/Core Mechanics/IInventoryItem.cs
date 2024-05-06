namespace Common.Core_Mechanics
{
    public interface IInventoryItem
    {
        void OnAddedToInventory();
        
        void OnRemovedFromInventory();
    }
}