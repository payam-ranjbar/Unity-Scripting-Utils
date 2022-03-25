using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ScriptingUtils.InventorySystem.Data;
using ScriptingUtils.ScriptableObjectDatabase;
using UnityEditor.Compilation;
using UnityEngine;

namespace ScriptingUtils.InventorySystem.Core
{
    public class InventoryItemBlueprints : SOGenericDatabase<string, IInventoryItem>
    {
        [SerializeField] private StackableInventoryItem[] _stackableItems;
        
        [SerializeField] private bool _runtimeMutable;
        [SerializeField] private bool _editorMutable;

        protected override bool RuntimeMutable => _runtimeMutable;

        protected override bool EditorMutable => _editorMutable;

        protected override List<IInventoryItem> ItemList => GetListOfItems();

        private List<IInventoryItem> GetListOfItems()
        {
            return new List<IInventoryItem>(_stackableItems);
        }

        public IInventoryItem CreateOneOf(string key)
        {
            if (!Has(key))
            {
                Debug.LogError("Input key not valid to create an Item");
                return null;
            }

            var item = Get(key);
            
            return item.Clone();
        }
    }
}