using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDesc itemDesc;

    [SerializeField]
    private MouseFollower mouseFollower;

    // --- UNTUK MENDAPATKAN INDEX DAN REFFERENCE DARI ITEM
    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    // public Sprite image1, image2;
    // public int quantity;
    // public string title, description;

    private int curDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private void Awake(){
        Hide();
        mouseFollower.Toogle(false);
        itemDesc.ResetDescription();
    }

    public void InitializeInventoryUI(int inventorySize){
        for (int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemAction;

        }
    }

    private void ResetDraggedItem(){
        mouseFollower.Toogle(false);
        curDraggedItemIndex = -1;
    }

    public void CreateDraggedItem(Sprite itemSprite, int quantity){
        mouseFollower.Toogle(true);

    }

    public void UpdateData(int itemIndex, Sprite itemSprite, int quantity){
        if (listOfUIItems.Count > itemIndex)
            listOfUIItems[itemIndex].SetData(itemSprite, quantity);
    }

    private void HandleShowItemAction(UIInventoryItem inventoryItem)
    {
        // throw new NotImplementedException();
    }

    private void HandleSwap(UIInventoryItem inventoryItem)
    {
        // throw new NotImplementedException();
        int index = listOfUIItems.IndexOf(inventoryItem);
        if (index == -1) {
            return;
        }
        
        // listOfUIItems[curDraggedItemIndex].SetData(index == 0 ? image1 : image2, quantity);
        // listOfUIItems[index].SetData(curDraggedItemIndex == 0 ? image1 : image2, quantity);
        // mouseFollower.Toogle(false);
        // curDraggedItemIndex = -1;

        OnSwapItems?.Invoke(curDraggedItemIndex, index);
        HandleItemSelection(inventoryItem);
    }
    
    private void HandleEndDrag(UIInventoryItem inventoryItem)
    {
        // throw new NotImplementedException();
        ResetDraggedItem();
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItem)
    {
        // throw new NotImplementedException();
        int index = listOfUIItems.IndexOf(inventoryItem);
        if (index == -1) return;
        curDraggedItemIndex = index;
        HandleItemSelection(inventoryItem);
        OnStartDragging?.Invoke(index);
    }

    private void HandleItemSelection(UIInventoryItem inventoryItem)
    {
        // throw new NotImplementedException();
        Debug.Log(inventoryItem.name + " is selected");
        int index = listOfUIItems.IndexOf(inventoryItem);
        if (index == -1) return;
        OnDescriptionRequested?.Invoke(index);
    }

    private void DeselectAllItems(){
        foreach (UIInventoryItem inventoryItem in listOfUIItems){
            inventoryItem.Deselect();
        }
    }

    public void ResetSelection(){
        itemDesc.ResetDescription();
        DeselectAllItems();
    }
    
    public void Show(){
        gameObject.SetActive(true);
        ResetSelection();
    }

    public void Hide(){
        gameObject.SetActive(false);
        ResetDraggedItem();
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description, int quantity){
        itemDesc.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
    }

    internal void ResetAllItems()
    {
        foreach (UIInventoryItem inventoryItem in listOfUIItems)
        {
            inventoryItem.ResetData();
            inventoryItem.Deselect();
        }
    }
}
