using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner_test : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnObject;

    public Transform target;

    public float beat = (60 / 105) * 2;
    private float timer;

    private void Update()
    {
        if(timer > beat)
        {
            InitBall();
            timer -= beat;
        }
        timer += Time.deltaTime;
    }

    private GameObject InitBall()
    {
        GameObject cube = Instantiate(ball, gameObject.transform);
        Destroy(Instantiate(spawnObject, gameObject.transform), 1.0f);
        Vector3 dir = target.position - gameObject.transform.position;
        dir = dir.normalized;

        cube.GetComponent<Rigidbody>().velocity = new Vector3(dir.x * 20, dir.y * 10, dir.z * 20);
        return cube;
    }


}
