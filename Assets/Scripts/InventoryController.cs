using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;

    public List<InventoryItem> initialItems = new List<InventoryItem>();

    private void PrepareUi(){
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        this.inventoryUI.OnStartDragging += HandleStartDragging;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
    }

    private void PrepareInventoryData(){
        inventoryData.Initialze();
        inventoryData.OnInventoryChanged += UpdateInventoryUI;
        foreach (InventoryItem item in initialItems){
            if (item.isEmpty) continue;
            inventoryData.AddItem(item);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        inventoryUI.ResetAllItems();
        foreach (var item in inventoryState)
        {
            inventoryUI.UpdateData(
                item.Key, 
                item.Value.item.ItemImage, 
                item.Value.quantity
            );
        }
    }

    private void HandleSwapItems(int itemIndex1, int itemIndex2)
    {
        inventoryData.SwapItems(itemIndex1, itemIndex2);
    }

    private void HandleStartDragging(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty) return;
        inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        // throw new NotImplementedException();
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.isEmpty) {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO itemSO = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, itemSO.ItemImage, itemSO.Name, itemSO.Description, inventoryItem.quantity);
        // throw new NotImplementedException();
    }

    private void Start(){
        PrepareUi();
        PrepareInventoryData();
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            if(inventoryUI.isActiveAndEnabled){
                inventoryUI.Hide();
            }else{
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurInventoryState())
                {
                    inventoryUI.UpdateData(
                        item.Key, 
                        item.Value.item.ItemImage, 
                        item.Value.quantity
                    );
                }
            }
        }
    }
}
