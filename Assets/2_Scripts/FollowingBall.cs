using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class FollowingBall : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private Rigidbody rb;
    private bool isHit = false;
    
    private void Start()
    {        
        Vector3 dir = target.transform.position - gameObject.transform.position;
        GetComponent<Rigidbody>().AddForce(dir * 10);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * -0.2f);
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * 10);
        if (!isHit)
        {
            //transform.position = 
            //    Vector3.MoveTowards(gameObject.transform.position, 
            //    target.transform.position, Time.deltaTime*10);
        }
    }

    public void SettingBall()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * 10);
        rb = gameObject.GetComponent<Rigidbody>();

    }

    public void NowHit()
    {
        isHit = true;
    }

}
