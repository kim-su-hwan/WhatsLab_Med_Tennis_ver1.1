using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBall : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private Rigidbody rb;
    private bool isHit = false;


    private void Start()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * 10);
        rb = gameObject.GetComponent<Rigidbody>();
        Vector3 dir = target.transform.position - gameObject.transform.position;
        rb.AddForce(dir * 10);
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * 0.45f);

        if (!isHit)
        {
            //transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime*10);
            
        }
    }

    public void NowHit()
    {
        isHit = true;
    }

}
