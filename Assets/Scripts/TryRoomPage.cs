using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryRoomPage : MonoBehaviour
{
    [SerializeField]
    private RectTransform roomPanel;
    public Image imageComponent;
    public TryRoomController roomController;
    public Sprite[] roomSprites;
    // private ActiveRoom currentRoom;
    // private RoomPov currentPov;

    private void Start(){
        roomController.activeRoom = ActiveRoom.Chillroom;
        roomController.roomPov = RoomPov.Afront;
        LoadRoomSprites();
    }

    private void LoadRoomSprites(){
        roomSprites = Resources.LoadAll<Sprite>(roomController.activeRoom.ToString());
        // Debug.Log(roomSprites.Length);
        if (roomSprites.Length > 0){
            imageComponent.sprite = roomSprites[0];
        } else {
            Debug.Log("no sprites at resources/{room}");
        }
    }
}
