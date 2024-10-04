using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ListObject : MonoBehaviour
{
    public string id;
    public string imagePath;
    public string Height;
    public string bodytype;
    public string gender;

    public void SetObjectInfo(string imagePath,string height, string bodytype,string gender)
    {
        this.id= System.Guid.NewGuid().ToString();
        this.imagePath= imagePath;
        this.gender= gender;
        this.Height= height;
        this.bodytype= bodytype;
    }
}
