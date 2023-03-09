using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using System.Data.Common;
using System.IO;
using UnityEngine.Rendering;
using System.Data;
using System;

//SaveData type

[System.Serializable]
public class SaveData
{
    public float rot_x;
    public float rot_y;
    public float rot_z;
    public string time;
}
public class DataSave : MonoBehaviour
{
    //[SerializeField]
    private Camera cam;

    string path;
    public List<SaveData> sdList = new List<SaveData>();

    private void Start()
    {
        path = Application.dataPath + "/data.json";
        StartCoroutine(JsonSaveCoroutine());
    }
    void SaveDataJson(Quaternion rot)
    {
        SaveData sd = new SaveData();
        sd.rot_x = rot.x;
        sd.rot_y = rot.y;
        sd.rot_z = rot.z;
        sd.time = DateTime.Now.ToString();
        string jsonData = JsonUtility.ToJson(sd);

        Debug.Log(DateTime.Now.ToString() + jsonData);

        File.AppendAllText(path, jsonData);
    }
    IEnumerator JsonSaveCoroutine()
    {
        Debug.Log("StartCoutinge json");
        while (true)
        {
            SaveDataJson(cam.transform.rotation);
            yield return new WaitForSeconds(1f);

        }

    }
}
