using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ObjDetailSO", menuName = "Scriptable Objects/Object POV")]
public class ObjDetailSO : ScriptableObject
{
    [Header("UI")]
    public string objectName;
    public Sprite objectSprite;
    public int objectId;
    public string roomName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
