using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BallMove : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 dir = new Vector3(0,0,0);
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float gravity = 10.6f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dir.x*speed, 0, dir.z*speed);
        rb.AddForce(Vector3.down * gravity);
    }

    public void SetDir(Transform target)
    {
        dir = target.transform.position - gameObject.transform.position;
        dir = dir.normalized;
    }

}
