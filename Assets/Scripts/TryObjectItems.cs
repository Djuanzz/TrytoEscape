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

    private void Start()
    {
        objectController = FindObjectOfType<TryObjectController>();
    }

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
            TryObjectItems dropTargetItem = dropTarget.GetComponent<TryObjectItems>();
            if (dropTargetItem != null)
            {
                Debug.Log("Object dropped: " + dragObject.gameObject.GetComponent<TryObjectItems>().item.ObjectName);
                Debug.Log("Object drop target: " + dropTargetItem.item.ObjectName);
                // CombineObjects(dragObject.gameObject, dropTarget);
                objectController.CombineObjects(dragObject.gameObject, dropTarget);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(originalParent);
        transform.position = startPosition;
        image.raycastTarget = true;
    }
}