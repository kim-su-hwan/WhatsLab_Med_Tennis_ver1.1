using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneControll : MonoBehaviour
{
    public void MoveTennisScene()
    {
        SceneManager.LoadScene("Tennis_modify2");
        if (GameManager.instance.HandVersion) Debug.Log(":::Right");
        else Debug.Log(":::Left");
    }
    public void FixedTennisScene()
    {
        SceneManager.LoadScene("Tennis_modify2_fixed");
        if (GameManager.instance.HandVersion) Debug.Log(":::Right");
        else Debug.Log(":::Left");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        GameManager.instance.gameScore= 0;
        if (GameManager.instance.HandVersion) Debug.Log(":::Right");
        else Debug.Log(":::Left");
    }

}
