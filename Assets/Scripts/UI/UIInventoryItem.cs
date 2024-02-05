using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image borderImage;

    public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

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
    public void SetData(Sprite sprite, int quantity){
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityText.text = quantity + "";
        empty = false;
    }

    public void Select(){
        borderImage.enabled = true;
    }

    public void OnDrop(){
        if(!empty){
            OnItemDroppedOn?.Invoke(this);
        }
    }

    public void OnEndDrag(){
        if(!empty){
            OnItemEndDrag?.Invoke(this);
        }
    }
    public void OnPointerClick(PointerEventData pointerData)
    {
        if(empty) return;
        
        if (pointerData.button == PointerEventData.InputButton.Right){
            OnRightMouseBtnClick?.Invoke(this);
        } else {
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
