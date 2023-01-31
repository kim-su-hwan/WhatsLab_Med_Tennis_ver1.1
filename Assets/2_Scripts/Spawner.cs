using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
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
        GameObject cube = Instantiate(ball, points[Random.Range(0, points.Length)]);
        cube.GetComponent<BallMove>().SetDir(target);
        return cube;
    }


    private void BallCount(GameObject cube)
    {
        Debug.Log("check ball count");
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

}
