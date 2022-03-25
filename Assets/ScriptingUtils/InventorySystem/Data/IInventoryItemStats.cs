
using System;
using UnityEngine;

namespace ScriptingUtils.InventorySystem.Data
{
    public interface IInventoryItemStats
    {
        public abstract InventoryItemDescriptions Descriptions { get; }
        public abstract InventoryItemIcons Icons { get; }
        public abstract ItemRarity Rarity { get; }
    }

    [Serializable]
    public class GeneralItemStats : IInventoryItemStats
    {
        [SerializeField] private InventoryItemDescriptions _descriptions;
        [SerializeField] private InventoryItemIcons _icons;
        [SerializeField] private ItemRarity _rarity;

        public InventoryItemDescriptions Descriptions => _descriptions;

        public InventoryItemIcons Icons => _icons;

        public ItemRarity Rarity => _rarity;
    }
}