using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class ChecklistManager : MonoBehaviour
{
    public Transform content;
    public GameObject addPanel;
    public GameObject checklistItemPrefab;

    public TMP_Text height;
    public string bodytype;
    public string gender;
    public string imagePath;

    string filePath;

    private List<ListObject> checklistObject = new List<ListObject>();

    private void Start()
    {
        filePath = Application.persistentDataPath + "/checklist.text";
    }

    void CreateChecklistItem(string imagePath, string height, string bodytype, string gender)
    {
        GameObject item = Instantiate(checklistItemPrefab);
        item.transform.SetParent(content);
        ListObject list = item.GetComponent<ListObject>();
        list.SetObjectInfo(imagePath, height, bodytype, gender);
        checklistObject.Add(list);
    }
}
