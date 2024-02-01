using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickup : MonoBehaviour
{
    public ObjectSO objectSO;

    void Pickup(){
        InventoryManager.Instance.Add(objectSO);
        Destroy(gameObject);
    }

    private void OnMouseDown() {
        Pickup();
        Debug.Log("Picked up " + objectSO.objectName);
    }
}
