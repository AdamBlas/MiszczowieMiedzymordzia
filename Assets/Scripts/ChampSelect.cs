using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampSelect : MonoBehaviour
{
    [SerializeField] AudioClip bgMusic;
    [SerializeField] AudioClip apheliosPick;
    [SerializeField] AudioClip elisePick;
    [SerializeField] AudioClip tryndamerePick;

    AudioSource audioSourceBg;
    AudioSource audioSourcePick;


    public void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSourceBg = sources[0];
        audioSourcePick = sources[1];

        audioSourceBg.clip = bgMusic;
        audioSourceBg.loop = true;
        audioSourceBg.Play();

        audioSourcePick.loop = false;
    }

    public void OnApheliosPick()
    {
        Play(apheliosPick);
    }
    public void OnElisePick()
    {
        Play(elisePick);
    }
    public void OnTryndamerePick()
    {
        Play(tryndamerePick);
    }
    private void Play(AudioClip clip)
    {
        audioSourceBg.volume = 0.5f;
        audioSourcePick.clip = clip;
        audioSourcePick.Play();
    }
}
