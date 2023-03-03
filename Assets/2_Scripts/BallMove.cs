using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private static int score = 0;
    private Rigidbody rb;
    private Vector3 dir = new Vector3(0, 0, 0);
    [SerializeField]
    private float speed = 35.0f;
    [SerializeField]
    private float gravity = 0.5f;
    [SerializeField]
    private float bounce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetTarget();
        //rb.velocity = new Vector3(dir.x * speed, dir.y*speed/3, dir.z * speed);
        //Debug.Log("Velocity : " + rb.velocity);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void GetTarget()
    {
        GameObject tar = GameObject.Find("Target");
        dir = tar.transform.position - gameObject.transform.position;
        dir = dir.normalized;
        rb.velocity = dir * speed; 
    }
    //public void SetDir(Transform target)
    //{
    //    dir = target.transform.position - gameObject.transform.position;
    //    dir = dir.normalized;
    //    Debug.Log("Direction : " + gameObject.transform.position.x + " ,"+ gameObject.transform.position.y + " ,"+ gameObject.transform.position.z);
    //}

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Racket")
        {
            if (this.gameObject.tag == "Ball")
            {
                score += 10;
            }
            if (this.gameObject.tag == "Bomb")
            {
                score -= 10;
                if (score < 0) score = 0;
            }
            if (this.gameObject.tag == "Watermelon")
            {
                score += 20;
            }
            ScoreController.instance.ShowScore(score);
            Debug.Log(score);
        }
        if (other.gameObject.tag == "court")
        {
            rb.AddForce(Vector3.up * bounce);
        }
    }
    
}
