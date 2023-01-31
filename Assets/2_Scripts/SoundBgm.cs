using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBgm : MonoBehaviour
{
    [SerializeField]
    private GameObject Bgm;

    //[SerializeField]
    //private GameObject SpawnBeat;

    public float music_bpm = 1;

    private void Start()
    {
        SoundSpeed(Bgm);
    }

    void SoundSpeed(GameObject bgm)
    {
        bgm.GetComponent<AudioSource>().pitch = bgm.GetComponent<AudioSource>().pitch * music_bpm;
    }

}
