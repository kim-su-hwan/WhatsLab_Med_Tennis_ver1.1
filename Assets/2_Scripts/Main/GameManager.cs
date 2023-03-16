using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //false = leftHand , true = RightHand
    public bool HandVersion = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void Start()
    {
        if(HandVersion) { RightHandeVersion(); }
        else { LeftHandeVersion(); }
    }

    public void LeftHandeVersion()
    {
        HandVersion = false;
        GameObject.Find("RightHand Controller").SetActive(false);
    }
    public void RightHandeVersion()
    {
        HandVersion = true;
        GameObject.Find("LeftHand Controller").SetActive(false);
    }


}
