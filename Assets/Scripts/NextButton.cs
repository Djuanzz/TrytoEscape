using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{   
    [SerializeField]
    private TryRoomPage roomUI;
    private int curSpriteIndex = 0;
    [SerializeField]
    private TryObjectController objectController;

    public void RightArrow()
    {
        curSpriteIndex = (curSpriteIndex + 1) % roomUI.roomSprites.Length;
        Debug.Log(curSpriteIndex);
        roomUI.imageComponent.sprite = roomUI.roomSprites[curSpriteIndex];
        roomUI.roomController.roomPov = roomUI.roomController.enumFunction.ChangePov(curSpriteIndex);
        Debug.Log(roomUI.roomController.roomPov.ToString());
        objectController.DestroyAllObjects();
        objectController.SpawnObject();
        Debug.Log("Right Arrow Clicked");
    }

    public void LeftArrow()
    {
        curSpriteIndex = (curSpriteIndex - 1 + roomUI.roomSprites.Length) % roomUI.roomSprites.Length;
        Debug.Log(curSpriteIndex);
        roomUI.imageComponent.sprite = roomUI.roomSprites[curSpriteIndex];
        roomUI.roomController.roomPov = roomUI.roomController.enumFunction.ChangePov(curSpriteIndex);
        Debug.Log(roomUI.roomController.roomPov.ToString());
        objectController.DestroyAllObjects();
        objectController.SpawnObject();
        Debug.Log("Left Arrow Clicked");
    }
}
