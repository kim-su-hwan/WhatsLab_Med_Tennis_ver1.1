using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using System.Data.Common;
using System.IO;
using UnityEngine.Rendering;
using System.Data;
using System;
using Newtonsoft.Json.Linq;

//SaveData type

[System.Serializable]
public class SaveData
{
    public float rot_x;
    public float rot_y;
    public float rot_z;
    public string time;
}

public class SaveDataScore
{
    public int score;
    public string time;
}

public class DataSave : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private JArray jsonSet;

    string path;
    public List<SaveData> sdList = new List<SaveData>();

    private void Start()
    {
        path = Application.dataPath + "/data.json";
        jsonSet = new JArray();
        StartCoroutine(JsonSaveCoroutine());
    }
    void SaveDataJson(Quaternion rot)
    {
        JObject data = new JObject();;

        data.Add("Rotation_X",rot.x.ToString());
        data.Add("Rotation_Y", rot.y.ToString());
        data.Add("Rotation_Z", rot.z.ToString());
        data.Add("Now_time", DateTime.Now.ToString());

        Debug.Log(data);
        jsonSet.Add(data);
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

    public void SaveGameOverData()
    {
        JObject data = new JObject();


        data.Add("Score",GameManager.instance.gameScore.ToString());
        data.Add("Time", DateTime.Now.ToString());
        jsonSet.Add(data);

        Debug.Log(data);

        File.AppendAllText(path, jsonSet.ToString());
    }

}
