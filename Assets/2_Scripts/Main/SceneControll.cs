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
    }
    public void FixedTennisScene()
    {
        SceneManager.LoadScene("Tennis_modify2_fixed");

    }
}
