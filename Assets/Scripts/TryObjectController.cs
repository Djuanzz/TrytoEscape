using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryObjectController : MonoBehaviour
{
    [SerializeField]
    private List<TryObjectSO> tryObjectsList = new List<TryObjectSO>();
    [SerializeField]
    private TryObjectPage objectUI;

    private void Start(){
        foreach (TryObjectSO tryObject in tryObjectsList){
            objectUI.CreateObjectUI(tryObject);
        }
    }

    public void GetObjectByID(int id)
    {
        // Cari objek dengan ID yang sesuai dalam list TryObjectSO
        TryObjectSO objectToInstantiate = FindObjectByID(id);
        
        // Jika objek ditemukan, instansiasi UI untuk objek tersebut
        if (objectToInstantiate != null)
        {
            objectUI.CreateObjectUI(objectToInstantiate);
        }
        else
        {
            Debug.LogWarning("Object with ID " + id + " not found!");
        }
    }

    private TryObjectSO FindObjectByID(int id)
    {
        // Cari objek dalam list TryObjectSO yang memiliki ID yang sesuai
        foreach (TryObjectSO obj in tryObjectsList)
        {
            if (obj.ObjectID == id)
            {
                return obj;
            }
        }
        return null; // Jika tidak ditemukan, kembalikan null
    }
}
