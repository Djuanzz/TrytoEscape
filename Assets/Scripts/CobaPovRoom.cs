using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CobaPovRoom : MonoBehaviour
{
    public ActiveRoom activeRoom;
    public RoomPov roomPov;

    [SerializeField]
    private RectTransform roomPanel;
    private Image imageComponent;

    private Sprite[] roomSprites;
    private int curSpriteIndex = 0;
    private EnumFunction enumFunction;

    private CobaSpawn cobaSpawn;

    private void Awake(){
        enumFunction = GetComponent<EnumFunction>();
        cobaSpawn = GetComponent<CobaSpawn>();
    }
    void Start(){
        imageComponent = roomPanel.GetComponent<Image>();
        roomSprites = Resources.LoadAll<Sprite>(activeRoom.ToString());
        Debug.Log(activeRoom);


        if (roomSprites.Length > 0){
            imageComponent.sprite = roomSprites[curSpriteIndex];
            Debug.Log("bg changed to : " + roomSprites[curSpriteIndex]);
        } else {
            Debug.Log("no sprites at resources/{room}");
        }

    }

    public void RightArrow()
    {
        curSpriteIndex = (curSpriteIndex + 1) % roomSprites.Length;
        imageComponent.sprite = roomSprites[curSpriteIndex];
        Debug.Log(enumFunction.ChangePov(curSpriteIndex));
        roomPov = enumFunction.ChangePov(curSpriteIndex);
        cobaSpawn.DestroyAllObjects();
        cobaSpawn.SpawnObject();
        Debug.Log("Background sprite changed to: " + roomSprites[curSpriteIndex].name);
    }

    public void LeftArrow()
    {
        curSpriteIndex = (curSpriteIndex - 1 + roomSprites.Length) % roomSprites.Length;
        imageComponent.sprite = roomSprites[curSpriteIndex];
        roomPov = enumFunction.ChangePov(curSpriteIndex);
        cobaSpawn.DestroyAllObjects();
        cobaSpawn.SpawnObject();
        Debug.Log("Background sprite changed to: " + roomSprites[curSpriteIndex].name);
    }

}
