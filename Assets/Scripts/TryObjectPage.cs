using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryObjectPage : MonoBehaviour
{
    [SerializeField]
    private TryObjectItems itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    public void CreateObjectUI(TryObjectSO item){
        TryObjectItems uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        uiItem.transform.SetParent(contentPanel);
        uiItem.InitialiazeItem(item);
    }
}
