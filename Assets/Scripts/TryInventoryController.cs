using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryInventoryController : MonoBehaviour
{
    [SerializeField]
    private TryInventoryPage inventoryUI;
    public int inventorySize = 10;

    private void Start(){
        inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void Update(){
        inventoryUI.Show();
    }
}
