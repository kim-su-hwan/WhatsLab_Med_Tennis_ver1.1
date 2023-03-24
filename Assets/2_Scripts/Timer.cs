using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject timecontroller;
    [SerializeField] private TMP_Text timer;
    public float time = 120.0f;
    public float re_time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        TimeCountUp();
        UpdateTimer();
    }
    void TimeCountUp()
    {
        time -= Time.deltaTime;
        if (time < 0.0f)
        {
            time = 0.0f;
            timecontroller.GetComponent<GameOverScript>().InActiveCanvas();
            timecontroller.GetComponent<GameOverScript>().ActiveGameOverCanvas();
        }
    }
    public void UpdateTimer()
    {
        int minute = (int)time / 60;
        int seconds = (int)time % 60;
        timer.text = "Time : " + minute.ToString() + " : " + seconds.ToString();
    }
}
