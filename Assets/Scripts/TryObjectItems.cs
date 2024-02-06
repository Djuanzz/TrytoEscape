using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TryObjectItems : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image image;
    public TryObjectSO item;
    public RectTransform objectTransform;
    private TryObjectPage objectPage;
    private TryObjectController objectController;
    Transform originalParent;
    Vector3 startPosition;

    public void InitialiazeItem(TryObjectSO newItem)
    {
        item = newItem;
        image.sprite = item.ObjectImage;
        objectTransform.anchoredPosition = new Vector3(item.ObjectPosition.x, item.ObjectPosition.y, item.ObjectPosition.z);
        objectTransform.sizeDelta = new Vector2(item.ObjectWidth, item.ObjectHeight);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        originalParent = transform.parent;
        startPosition = transform.position;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        TryObjectItems dragObject = droppedObject.GetComponent<TryObjectItems>();
        if (dragObject != null)
        {
            GameObject dropTarget = eventData.pointerEnter;

            Debug.Log("Object dropped: " + dragObject);
            Debug.Log("Object drop target: " + dropTarget);
            CombineObjects(dragObject.gameObject, dropTarget);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(originalParent);
        transform.position = startPosition;
        image.raycastTarget = true;
    }

    public void CombineObjects(GameObject item1, GameObject item2)
    {
        if (item1.GetComponent<TryObjectItems>().item.ObjectID == item2.GetComponent<TryObjectItems>().item.CombineWithObjectID && item2.GetComponent<TryObjectItems>().item.ObjectID == item1.GetComponent<TryObjectItems>().item.CombineWithObjectID)
        {
            Debug.Log("Combined");
            Destroy(item1);
            Destroy(item2);
            // ----- MASIH ERROR DISINI NULL REFERENCE, LANJUT BESOK. KEMUNGKINAN FUCTION INI BAKAL DIPINDAH KE FILE LAIN YANG KHSUUS MENANGANI COMBINE OBJECT
            // objectController.GetObjectByID(item2.GetComponent<TryObjectItems>().item.GeneratesObejctID);
            Debug.Log("Object generated: " + item2.GetComponent<TryObjectItems>().item.GeneratesObejctID);
        }
        else
        {
            Debug.Log("Not Combined");
        }
    }
}