using System.Collections.Generic;
using ScriptingUtils.InventorySystem.Data;

namespace ScriptingUtils.InventorySystem.Core
{
    public class Inventory
    {
        private int capacity;

        private int numberOfItems;
        
        private List<string> itemIDs;

        private Dictionary<string, IInventoryItem> _dictionary;
        
        private InventoryItemBlueprints _blueprints;

        private bool HasCapacity => capacity > numberOfItems;

        public void Add(string key)
        {
            if (!HasCapacity) return;
            
            var item = _blueprints.CreateOneOf(key);
            _dictionary.Add(item.InventoryID, item);
            itemIDs.Add(item.InventoryID);
            numberOfItems++;
        }

        public void Remove(string inventoryId)
        {
            if (!HasItem(inventoryId)) return;
            
            _dictionary.Remove(inventoryId);
            itemIDs.Remove(inventoryId);
            numberOfItems--;
        }

        public void Use(string inventoryId)
        {
            if (!HasItem(inventoryId)) return;
            
            _dictionary[inventoryId].Use();
        }
        public bool HasItem(string inventoryId)
        {
            return (_dictionary.ContainsKey(inventoryId));
        }
    }
}