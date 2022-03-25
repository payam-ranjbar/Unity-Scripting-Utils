using ScriptingUtils.ScriptableObjectDatabase;

namespace ScriptingUtils.InventorySystem.Data
{
    public interface IInventoryItem: IDBItem<string>
    {
         IInventoryItemStats Stats { get; }

         string InventoryID { get; }

         void Use();

         IInventoryItem Clone();


    }
}