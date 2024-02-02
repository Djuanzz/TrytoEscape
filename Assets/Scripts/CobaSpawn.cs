using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaSpawn : MonoBehaviour
{
    [SerializeField]
    private List<CobaObject> itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private CobaPovRoom cobaPovRoom;

    private List<GameObject> instantiatedObjects = new List<GameObject>();

    void Start(){
        SpawnObject();
    }
    
    public void SpawnObject()
    {
        for (int i = 0; i < itemPrefab.Count; i++)
        {
            if (itemPrefab[i].objectSO.roomPov == cobaPovRoom.roomPov && itemPrefab[i].objectSO.activeRoom == cobaPovRoom.activeRoom)
            {
                CobaObject uiItem = Instantiate(itemPrefab[i], new Vector3(itemPrefab[i].objectSO.objectX, itemPrefab[i].objectSO.objectY, 0), Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                instantiatedObjects.Add(uiItem.gameObject); // Menambahkan game object ke dalam list instantiatedObjects
            }
        }
    }

    // Fungsi untuk menghancurkan semua game object yang telah dibuat
    public void DestroyAllObjects()
    {
        foreach (GameObject obj in instantiatedObjects)
        {
            Destroy(obj);
        }
        instantiatedObjects.Clear(); // Mengosongkan list instantiatedObjects setelah game object dihancurkan
    }
}
