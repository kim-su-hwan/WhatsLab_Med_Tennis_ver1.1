using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Spwan_modify1 : MonoBehaviour
{
    public GameObject[] spawns;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject[] ball;

    public float beat = (60 / 105) * 2;
    private float timer;

    private void Update()
    {
        if(timer > beat) 
        {
            timer -= beat;
            InitBall();
        }
        timer += Time.deltaTime;
    }

    private void InitBall()
    {
        int num = Random.Range(0, spawns.Length);
        Destroy(Instantiate(ball[BallType()], spawns[num].transform),10.0f);
        
    }

    private int BallType()
    {
        int type = Random.Range(0, 100);
        if(type < 70)
        {
            return 0;
        }
        else if(type >=70&&type<85)
        {
            return 1;   
        }
        else
        {
            return 2;
        }
    }


}
