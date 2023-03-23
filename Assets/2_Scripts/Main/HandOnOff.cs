using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOnOff : MonoBehaviour
{
    [SerializeField] private GameObject leftHand = null;
    [SerializeField] private GameObject rightHand = null;

    private void Start()
    {
        if(GameManager.instance.HandVersion){ OnRightHand(); }
        else{OnLeftHand();}
    }

    public void OnLeftHand()
    {
        leftHand.SetActive(true);
        rightHand.SetActive(false);
    }
    public void OnRightHand()
    {
        leftHand.SetActive(false);
        rightHand.SetActive(true);
    }

}
