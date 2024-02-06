using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/TryObjectSO")]
public class TryObjectSO : ScriptableObject
{
    [Header("Object Data")]
    [field: SerializeField]
    public int ObjectID;
    [field: SerializeField]
    public string ObjectName;
    [field: SerializeField]
    public Sprite ObjectImage;


    [Header("Object Type")]
    [field: SerializeField]
    public ObjectTypes ObjectType;


    [Header("Object Combination")]
    [field: SerializeField]
    public int CombineWithObjectID;
    [field: SerializeField]
    public int GeneratesObejctID;
    

    [Header("Object Placement")]
    [field: SerializeField]
    public ActiveRoom ActiveRoom;
    [field: SerializeField]
    public RoomPov RoomPov;


    [Header("Object Position")]
    [field: SerializeField]
    public Vector3 ObjectPosition;
    [field: SerializeField]
    public float ObjectWidth;
    [field: SerializeField]
    public float ObjectHeight;

}
