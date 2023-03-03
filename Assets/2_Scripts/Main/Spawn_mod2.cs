using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ��ũ��Ʈ�� ������
//�ƴ� �úη� enemy�� ����� �߰��߰��� �� ���� ����� Ʋ���� �����°�
//�úη��� �� �巴�� �ȵ�� ���ε� �𸣰ٰ� �� ���� ��� ���ϴ���
//������ ������ ����ϴ� �̰��� ��ǻ�� ��Ŵ��;�Ӥ��ø�;�;
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
