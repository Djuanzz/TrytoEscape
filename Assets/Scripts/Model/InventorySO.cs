using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/InventorySO")]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItem> inventoryItems;

    [field: SerializeField]
    public int Size { get; private set; } = 10;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryChanged;

    public void Initialze(){
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public void AddItem(ItemSO item, int quantity){
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].isEmpty){
                inventoryItems[i] = new InventoryItem{
                    item = item,
                    quantity = quantity
                };
                return;
            }
        }
    }

    public Dictionary<int, InventoryItem> GetCurInventoryState(){
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].isEmpty) continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }

    public InventoryItem GetItemAt(int itemIndex){
        return inventoryItems[itemIndex];
    }

    public void AddItem(InventoryItem item){
        AddItem(item.item, item.quantity);
    }

    public void SwapItems(int itemIndex1, int itemIndex2)
    {
        InventoryItem temp = inventoryItems[itemIndex1];
        inventoryItems[itemIndex1] = inventoryItems[itemIndex2];
        inventoryItems[itemIndex2] = temp;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnInventoryChanged?.Invoke(GetCurInventoryState());
    }
}

[Serializable]
public struct InventoryItem
{
    public ItemSO item;
    public int quantity;
    public bool isEmpty => item == null;

    public InventoryItem ChangeQuantity(int quantity){
        return new InventoryItem{
            item = this.item,
            quantity = quantity
        };
    }

    public static InventoryItem GetEmptyItem() => new InventoryItem {
        item = null, 
        quantity = 0 
    };
}
