using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "Scriptable Objects/Room Objects")]
public class ObjectSO : ScriptableObject
{
    [Header("UI")]
    public string objectName;
    public Sprite objectSprite;
    public int objectId;
    public string roomName;

    // [Header("Object Placement")]
    // public float objectX;
    // public float objectY;
    // public float objectWidth;
    // public float objectHeight;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
