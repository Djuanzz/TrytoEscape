using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryInventoryPage : MonoBehaviour
{
    [SerializeField]
    private TryInventoryItem itemPrefab;
    
    [SerializeField]
    private RectTransform contentPanel;

    List<TryInventoryItem> listOfUIItems = new List<TryInventoryItem>();

    public Sprite image;
    public Sprite image1;

    public void InitializeInventoryUI(int inventorySize){
        for (int i = 0; i < inventorySize; i++)
        {
            TryInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemAction;
        }
    }

    private void HandleShowItemAction(TryInventoryItem item)
    {
        // throw new NotImplementedException();
        Debug.Log(item.name + "Item Clicked");
    }

    private void HandleEndDrag(TryInventoryItem item)
    {
        // throw new NotImplementedException();
        Debug.Log(item.name + "Item Clicked");
    }

    private void HandleSwap(TryInventoryItem item)
    {
        // throw new NotImplementedException();
        Debug.Log(item.name + "Item Clicked");
    }

    private void HandleBeginDrag(TryInventoryItem item)
    {
        Debug.Log(item.name + "Item Clicked");
        // throw new NotImplementedException();
    }

    private void HandleItemSelection(TryInventoryItem item)
    {
        // throw new NotImplementedException(); 
        foreach (var uiItem in listOfUIItems)
        {
            if(uiItem != item) uiItem.Deselect();
        }
        item.Select();
        Debug.Log(item.name + "Item Clicked");
        // listOfUIItems[0].Select();
        // listOfUIItems[1].Select();
    }

    public void Show(){
        gameObject.SetActive(true);
        listOfUIItems[0].SetData(image);
        listOfUIItems[1].SetData(image1);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }
}
