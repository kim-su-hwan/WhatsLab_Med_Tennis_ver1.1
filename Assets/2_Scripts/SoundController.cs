using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    public AudioSource audioBox;
    public AudioClip basicBallSound;
    public AudioClip watermelonBallSound;
    public AudioClip bombBallSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }



    public void SoundPlay(string name)
    {
        switch(name) {
            case "Ball":
                audioBox.clip= basicBallSound;
                audioBox.Play();
                break;
            case "Watermelon":
                audioBox.clip= watermelonBallSound;
                audioBox.Play();
                break;
            case "Bomb":
                audioBox.clip= bombBallSound;
                audioBox.Play();
                break;
            default:
                break;
        }
    }



}
