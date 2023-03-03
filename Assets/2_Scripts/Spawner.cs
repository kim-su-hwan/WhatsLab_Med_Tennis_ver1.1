using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] ball;
    public GameObject spawnObject;
    public Transform[] points;

    public Transform target;

    public float beat = (60 / 105) * 2;
    private float timer;
    private Queue<GameObject> balls = new Queue<GameObject>();

   


    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            BallCount(InitBall());
            timer -= beat;            
        }
        timer += Time.deltaTime;
    }

    private GameObject InitBall()
    {
        int points_num = 0;
        Destroy(Instantiate(spawnObject, points[points_num]), 1.0f);
        //GameObject cube = Instantiate(ball[RandomBall(Random.Range(0,101))], points[points_num]);
        GameObject cube = Instantiate(ball[0], points[points_num]);
        SetDir(cube);
        
//        cube.GetComponent<BallMove>().SetDir(target);
        return cube;
    }
    private void SetDir(GameObject initball)
    {
        Vector3 dir = target.position - initball.transform.position;
        dir = dir.normalized;  
        initball.GetComponent<Rigidbody>().velocity = new Vector3(dir.x*35,dir.y*9,dir.z*35); 
    }


    private void BallCount(GameObject cube)
    {
        if(balls== null)
        {
            balls.Enqueue(cube);
            return;
        }
        if(balls.Count > 10)
        {
            Destroy(balls.Dequeue());            
        }
        balls.Enqueue(cube);
    }
    
    private int RandomBall(int num)
    {
        //probability 60 20 20
        if(num < 60)
        {
            return 0;
        }
        else if(num >=60 && num < 80)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
