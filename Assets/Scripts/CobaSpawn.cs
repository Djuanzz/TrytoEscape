using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaSpawn : MonoBehaviour
{
    [SerializeField]
    private List<CobaObject> itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    public RoomPov roomPov;
    public ActiveRoom activeRoom;

    void Start(){
        for (int i = 0; i < itemPrefab.Count; i++)
        {
            if (itemPrefab[i].objectSO.roomPov == roomPov && itemPrefab[i].objectSO.activeRoom == activeRoom)
            {
                CobaObject uiItem = Instantiate(itemPrefab[i], new Vector3(itemPrefab[i].objectSO.objectX,itemPrefab[i].objectSO.objectY,0), Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
            }
            // CobaObject uiItem = Instantiate(itemPrefab[i], new Vector3(itemPrefab[i].objectSO.objectX,itemPrefab[i].objectSO.objectY,0), Quaternion.identity);
            // uiItem.transform.SetParent(contentPanel);
        }
        // TryInventoryItem uiItem = Instantiate(itemPrefab, new Vector3(500,500,0), Quaternion.identity);
        // uiItem.transform.SetParent(contentPanel);
    }

}
