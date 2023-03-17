using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance !=this)
            {
                Destroy(this.gameObject);   
            }
        }
        GameManager.instance.HandSetting();
    }

    [SerializeField] private TextMeshProUGUI score_text;
    //static private int Score = 0;
    public void ShowScore(int score) { score_text.text = $"Score : {score}"; }
    //public void AddScore(int score) 
    //{ 
    //    Score += score;   
    //}
    //public void RemoveScore(int score) 
    //{ 
    //    Score -= score;
    //    if(Score < 0)
    //        Score = 0;
    //}


}
