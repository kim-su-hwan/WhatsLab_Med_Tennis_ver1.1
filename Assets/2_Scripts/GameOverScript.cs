using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject gameovercanvas;
    [SerializeField]
    private TextMeshProUGUI score_text;

    public UnityEvent SaveData;

    public void InActiveCanvas()
    {
        canvas.SetActive(false);
    }

    public void ActiveGameOverCanvas()
    {
        int score = GameManager.instance.gameScore;
        score_text.text = $"Score  : {score}";
        Time.timeScale = 0;
        gameovercanvas.SetActive(true);
        SaveData.Invoke();
    }

}
