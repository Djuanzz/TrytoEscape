using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "Scriptable Objects/Room Objects")]
public class ObjectSO : ScriptableObject
{
    [Header("UI")]
    public string objectName;
    public Sprite objectSprite;
    public string  objectId;

    [Header("Object Details")]
    public ActiveRoom activeRoom;
    public RoomPov roomPov;
    public bool isMachine;
    public bool isDetail;
    public Sprite detailSprite;

    [Header("Object Placement")]
    public float objectX;
    public float objectY;
}
