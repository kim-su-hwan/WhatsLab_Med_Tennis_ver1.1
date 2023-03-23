using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject lefthand;
    private GameObject righthand;

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
    }

    public void LeftHandeVersion()
    {
        HandVersion = false;
        //lefthand.SetActive(true);
        //righthand.SetActive(false);
        
    }
    public void RightHandeVersion()
    {
        HandVersion = true;
        //lefthand.SetActive(false);
        //righthand.SetActive(true);
    }

    public void ChangeHand()
    {
        HandVersion = !HandVersion;
    }

}
