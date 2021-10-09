using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampSelect : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField] Transform portraitOutline;
    [SerializeField] [Range(0f, 1f)] float portraitOutlineRotationSpeed;

    [Space]
    [SerializeField] Transform bigCircle;
    [SerializeField] [Range(0f, 1f)] float bigCircleRotationSpeed;

    [Space]
    [Header("Audio")]
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

        StartCoroutine(RotatePortraitOutline());
        StartCoroutine(RotateBigCircle());
    }

    IEnumerator RotatePortraitOutline()
    {
        Vector3 rotOffset = new Vector3(0, 0, Time.deltaTime * -5 * portraitOutlineRotationSpeed);

        while (true)
        {
            portraitOutline.Rotate(rotOffset, Space.Self);
            yield return null;
        }
    }

    IEnumerator RotateBigCircle()
    {
        Vector3 rotOffset = new Vector3(0, 0, Time.deltaTime * -1 * bigCircleRotationSpeed);

        while (true)
        {
            bigCircle.Rotate(rotOffset, Space.Self);
            yield return null;
        }
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
