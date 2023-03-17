using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_mod2 : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject[] player_spawns;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject[] ball;
    [SerializeField] private GameObject enemy;

    public float beat = (60 / 105) * 2;
    private float timer;

    GameObject en = null;
    private int num;

    private void Awake()
    {
        num = 2;
        en = Instantiate(enemy, player_spawns[num].transform);
        StartCoroutine(InitEnemy());
    }

    private void Update()
    {
        en.transform.position = Vector3.Lerp(en.transform.position, player_spawns[num].transform.position, 0.1f);
        if (timer > beat)
        {
            num = Random.Range(0, spawns.Length);
            timer -= beat;
            StartCoroutine(InitEnemy());            
        }
        timer += Time.deltaTime;        
    }

    private void InitBall(int num)
    {
        Destroy(Instantiate(ball[BallType()], spawns[num].transform), 8.0f);
    }



    IEnumerator InitEnemy()
    {    
        yield return new WaitForSecondsRealtime(3.0f);
        //GameObject en = Instantiate(enemy, player_spawns[num].transform);
        //yield return new WaitForSecondsRealtime(2.0f);
        //Destroy(en);
        InitBall(num);
    }
    private int BallType()
    {
        int type = Random.Range(0, 100);
        if (type < 70)
        {
            return 0;
        }
        else if (type >= 70 && type < 85)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

}
