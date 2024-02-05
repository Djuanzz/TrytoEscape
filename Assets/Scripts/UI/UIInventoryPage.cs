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

    public Sprite image1, image2;
    public int quantity;
    public string title, description;

    private int curDraggedItemIndex = -1;

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

    private void HandleShowItemAction(UIInventoryItem item)
    {
        // throw new NotImplementedException();
    }

    private void HandleSwap(UIInventoryItem item)
    {
        // throw new NotImplementedException();
        int index = listOfUIItems.IndexOf(item);
        if (index == -1) {
            mouseFollower.Toogle(false);
            curDraggedItemIndex = -1;
            return;
        }
        
        listOfUIItems[curDraggedItemIndex].SetData(index == 0 ? image1 : image2, quantity);
        listOfUIItems[index].SetData(curDraggedItemIndex == 0 ? image1 : image2, quantity);
        mouseFollower.Toogle(false);
        curDraggedItemIndex = -1;
    }
    
    private void HandleEndDrag(UIInventoryItem item)
    {
        // throw new NotImplementedException();
        mouseFollower.Toogle(false);
        
    }

    private void HandleBeginDrag(UIInventoryItem item)
    {
        // throw new NotImplementedException();
        int index = listOfUIItems.IndexOf(item);
        if (index == -1) return;
        curDraggedItemIndex = index;

        mouseFollower.Toogle(true);
        mouseFollower.SetData(index == 0 ? image1 : image2, quantity);
    }

    private void HandleItemSelection(UIInventoryItem item)
    {
        // throw new NotImplementedException();
        Debug.Log(item.name + " is selected");
        itemDesc.SetDescription(image1, title, description);
        listOfUIItems[0].Select();

    }

    public void Show(){
        gameObject.SetActive(true);
        itemDesc.ResetDescription();

        listOfUIItems[0].SetData(image1, quantity);
        listOfUIItems[1].SetData(image2, quantity);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
