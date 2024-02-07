using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryObjectController : MonoBehaviour
{
    [SerializeField]
    private List<TryObjectSO> tryObjectsList = new List<TryObjectSO>();
    [SerializeField]
    private TryObjectPage objectUI;
    private TryRoomController roomController;
    private Dictionary<ActiveRoom, Dictionary<RoomPov, List<TryObjectSO>>> dictionaryObject = new Dictionary<ActiveRoom, Dictionary<RoomPov, List<TryObjectSO>>>();
    private Dictionary<ActiveRoom, Dictionary<RoomPov, List<TryObjectSO>>> currDictObject = new Dictionary<ActiveRoom, Dictionary<RoomPov, List<TryObjectSO>>>();

    private void Start(){
        roomController = GetComponent<TryRoomController>();
        InitialiazeSpecificObjectItem();
        SpawnObject();
        // Debug.Log("TryObjectController Start");
        // PrintDictionaryDetails();
    }
    private void PrintDictionaryDetails()
    {
        foreach (var roomEntry in dictionaryObject)
        {
            Debug.Log("Active Room: " + roomEntry.Key);
            foreach (var povEntry in roomEntry.Value)
            {
                Debug.Log("  Room POV: " + povEntry.Key);
                Debug.Log("    Objects:");
                foreach (var tryObject in povEntry.Value)
                {
                    Debug.Log("      " + tryObject.name); // assuming TryObjectSO has a 'name' property
                }
                Debug.Log("+++++++++++++++++++++");
            }
            Debug.Log("--------------------");
        }
    }
    private void InitialiazeSpecificObjectItem(){
        foreach (TryObjectSO tryObject in tryObjectsList){
            if (!dictionaryObject.ContainsKey(tryObject.ActiveRoom)){
                dictionaryObject.Add(tryObject.ActiveRoom, new Dictionary<RoomPov, List<TryObjectSO>>());
            }
            if (!dictionaryObject[tryObject.ActiveRoom].ContainsKey(tryObject.RoomPov)){
                dictionaryObject[tryObject.ActiveRoom].Add(tryObject.RoomPov, new List<TryObjectSO>());
            }
            dictionaryObject[tryObject.ActiveRoom][tryObject.RoomPov].Add(tryObject);
        }
    }

    public void SpawnObject(){
        if (!currDictObject.ContainsKey(roomController.activeRoom))
            currDictObject.Add(roomController.activeRoom, new Dictionary<RoomPov, List<TryObjectSO>>());

        if (!currDictObject[roomController.activeRoom].ContainsKey(roomController.roomPov)){
            currDictObject[roomController.activeRoom].Add(roomController.roomPov, new List<TryObjectSO>());

            foreach (TryObjectSO tryObject in dictionaryObject[roomController.activeRoom][roomController.roomPov]){
                if (tryObject.IsInitialObject){
                    currDictObject[roomController.activeRoom][roomController.roomPov].Add(tryObject);
                    objectUI.CreateObjectUI(tryObject);
                }
            }
        }
        else {
            foreach (TryObjectSO tryObject in currDictObject[roomController.activeRoom][roomController.roomPov])
                objectUI.CreateObjectUI(tryObject);
        }
    }


    public void DestroyAllObjects(){
        objectUI.DestroyAllObjects();
    }

    public void DestroyObject(TryObjectSO item1, TryObjectSO item2, GameObject obj1, GameObject obj2){
        currDictObject[roomController.activeRoom][roomController.roomPov].Remove(item1);
        currDictObject[roomController.activeRoom][roomController.roomPov].Remove(item2);
        Destroy(obj1);
        Destroy(obj2);
    }

    public void GetObjectByID(int id)
    {
        TryObjectSO objectToInstantiate = FindObjectByID(id);
        
        if (objectToInstantiate != null){
            currDictObject[roomController.activeRoom][roomController.roomPov].Add(objectToInstantiate);
            objectUI.CreateObjectUI(objectToInstantiate);
        }
        else
            Debug.LogWarning("Object with ID " + id + " not found! or the object is not in the current room POV!");
    }

    private TryObjectSO FindObjectByID(int id)
    {
        foreach (TryObjectSO tryObject in dictionaryObject[roomController.activeRoom][roomController.roomPov])
        {
            if (tryObject.ObjectID == id)
                return tryObject;
        }
        return null;
    }

    public void CombineObjects(GameObject dragObject, GameObject dropTarget)
    {
        TryObjectItems item1 = dragObject.GetComponent<TryObjectItems>();
        TryObjectItems item2 = dropTarget.GetComponent<TryObjectItems>();
        if (item1.item.ObjectID == item2.item.CombineWithObjectID && item2.item.ObjectID == item1.item.CombineWithObjectID)
        {
            Debug.Log("CombineObjects SUCCESSSSSSS");
            GetObjectByID(item1.item.GeneratesObejctID);
            DestroyObject(item1.item, item2.item, dragObject, dropTarget);
        }
    }
}
