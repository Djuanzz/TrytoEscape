using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TryInventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Image borderImage;

    public event Action<TryInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

    private bool empty = true;

    public void Awake(){
        ResetData();
        Deselect();
    }

    public void ResetData(){
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect(){
        borderImage.enabled = false;
    }

    public void SetData(Sprite sprite){
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        empty = false;
    }

    public void Select(){
        borderImage.enabled = true;
    }

    public void OnBeginDrag(){
        if (empty) return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop(){
        if (empty) return;
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag(){
        if (empty) return;
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        if(pointerData.button == PointerEventData.InputButton.Right){
            OnRightMouseBtnClick?.Invoke(this);
        }
        else{
            OnItemClicked?.Invoke(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(empty) return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
