using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ObjectSO> items = new List<ObjectSO>();
    void Awake()
    {
        Instance = this;
        Debug.Log("Instance Inventory");
    }

    public void Add(ObjectSO item)
    {
        items.Add(item);
        Debug.Log("Adding item into inventory");
    }


    public void Remove(ObjectSO item)
    {
        items.Remove(item);
        Debug.Log("Remove item from inventory");
    }

}
