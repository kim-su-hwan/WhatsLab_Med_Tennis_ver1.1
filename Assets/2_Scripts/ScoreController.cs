using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    static private int Score = 0;

    public void AddScore(int score) { Score += score; }
    public void RemoveScore(int score) { Score -= score; }


}
