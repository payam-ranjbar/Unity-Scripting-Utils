using System;
using UnityEngine;

namespace ScriptingUtils.InventorySystem.Data
{
    [Serializable]
    public class StackableInventoryItem : IInventoryItem
    {
        public string keyDisplay;
        public string inventoryIDDisplay;
        
        [SerializeField] private GeneralItemStats _stats;
        
        private string _key;
        private string _inventoryID;

        private StackableInventoryItem(GeneralItemStats stats)
        {
            _stats = stats;
            GenerateInventoryID();
        }
        public void GenerateKey()
        {
            keyDisplay = _key = Guid.NewGuid().ToString();
        }

        public void GenerateInventoryID()
        {
            inventoryIDDisplay = _inventoryID = Guid.NewGuid().ToString();
        }
        
        public string Key => _key;

        public IInventoryItemStats Stats => _stats;

        public string InventoryID => _inventoryID;

        public void Use()
        {
            Debug.Log($"Item {nameof(StackableInventoryItem)} used");
        }

        public IInventoryItem Clone()
        {
            return  new StackableInventoryItem(_stats);
        }
    }
}