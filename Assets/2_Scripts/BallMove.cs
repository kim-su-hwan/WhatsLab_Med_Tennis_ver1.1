using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

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

    private ActionBasedController abc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetTarget();

        if (GameManager.instance.HandVersion)
            abc = GameObject.Find("RightHand Controller").GetComponent<ActionBasedController>();
        else
            abc = GameObject.Find("LeftHand Controller").GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetTarget()
    {
        //GameObject tar = GameObject.Find("Target");
        //
        int num = Random.Range(0, 5);
        GameObject tar = GameObject.Find("Target" + num.ToString());
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
                Debug.Log("ball");
                SoundController.instance.SoundPlay("Ball");
                abc.SendHapticImpulse(0.3f, 0.3f);
            }
            if (this.gameObject.tag == "Bomb")
            {
                score -= 10;
                if (score < 0) score = 0;
                Debug.Log("bomb");
                SoundController.instance.SoundPlay("Bomb");
                abc.SendHapticImpulse(0.7f, 0.5f);
            }
            if (this.gameObject.tag == "Watermelon")
            {
                score += 20;
                Debug.Log("watermelon");
                SoundController.instance.SoundPlay("Watermelon");
                abc.SendHapticImpulse(0.5f, 0.3f);
            }
            ScoreController.instance.ShowScore(score);
            Debug.Log("Score : " + score);
        }
        if (other.gameObject.tag == "court")
        {
            rb.AddForce(Vector3.up * bounce);
        }
    }

}
