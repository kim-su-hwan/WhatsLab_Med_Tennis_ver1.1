using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 스크립트는 개같네
//아니 시부레 enemy만 만들면 중간중간에 왜 방향 계산이 틀리게 나오는건
//시부레거 말 드럽게 안드네 원인도 모르겟고 왜 방향 계산 못하느디
//이진수 따위만 계산하는 미개한 컴퓨터 시킴얼;ㅣㅏㅓ리;어리;
public class Spawn_mod2 : MonoBehaviour
{
    public GameObject[] spawns;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject[] ball;
    [SerializeField] private GameObject enemy;

    public float beat = (60 / 105) * 2;
    private float timer;

    private void Update()
    {
        if (timer > beat)
        {
            timer -= beat;
            StartCoroutine(InitEnemy());
        }
        timer += Time.deltaTime;
    }

    private void InitBall(int num)
    {
        Destroy(Instantiate(ball[BallType()], spawns[num].transform), 10.0f);

    }



    IEnumerator InitEnemy()
    {
        int num = Random.Range(0, spawns.Length);
        GameObject en = Instantiate(enemy, spawns[num].transform);
        yield return new WaitForSecondsRealtime(2.0f);
        Destroy(en);
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
