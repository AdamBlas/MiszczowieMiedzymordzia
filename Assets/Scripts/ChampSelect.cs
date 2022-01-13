using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChampSelect : MonoBehaviour
{
    [Header("Icons")]
    [SerializeField] Sprite ahriIcon;
    [SerializeField] Sprite apheliosIcon;
    [SerializeField] Sprite eliseIcon;
    [SerializeField] Sprite tryndamereIcon;
    [SerializeField] Sprite zileanIcon;

    [Space]
    [Header("Backgrounds")]
    [SerializeField] Image championBackground;
    [SerializeField] Sprite ahriBackground;
    [SerializeField] Sprite apheliosBackground;
    [SerializeField] Sprite eliseBackground;
    [SerializeField] Sprite tryndamereBackground;
    [SerializeField] Sprite zileanBackground;

    [Space]
    [Header("GUI")]
    [SerializeField] Transform portraitOutline;
    [SerializeField] Image selectedChampIcon;
    [SerializeField] [Range(0f, 1f)] float portraitOutlineRotationSpeed;

    [Space]
    [SerializeField] Transform bigCircle;
    [SerializeField] [Range(0f, 1f)] float bigCircleRotationSpeed;

    [Space]
    [Header("Audio")]
    [SerializeField] AudioClip bgMusic;
    [SerializeField] AudioClip ahriPick;
    [SerializeField] AudioClip apheliosPick;
    [SerializeField] AudioClip elisePick;
    [SerializeField] AudioClip tryndamerePick;
    [SerializeField] AudioClip zileanPick;

    [Space]
    [Header("Lock Button")]
    [SerializeField] Image lockButton;

    AudioSource audioSourceBg;
    AudioSource audioSourcePick;
    string selectedChamp;
    bool champSelected = false;
    bool champLocked = false;


    public void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSourceBg = sources[0];
        audioSourcePick = sources[1];

        audioSourceBg.clip = bgMusic;
        audioSourceBg.loop = true;
        audioSourceBg.Play();

        audioSourcePick.loop = false;
        lockButton.enabled = false;

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

    public void OnChampPick()
    {
        if (champLocked)
            return;

        champSelected = true;
        selectedChampIcon.enabled = true;
        championBackground.enabled = true;
        lockButton.enabled = true;
    }
    public void OnAhriPick()
    {
        if (champLocked)
            return;

        selectedChampIcon.sprite = ahriIcon;
        championBackground.sprite = ahriBackground;
        selectedChamp = "Ahri";
        OnChampPick();
    }
    public void OnApheliosPick()
    {
        if (champLocked)
            return;

        selectedChampIcon.sprite = apheliosIcon;
        championBackground.sprite = apheliosBackground;
        selectedChamp = "Aphelios";
        OnChampPick();
    }
    public void OnElisePick()
    {
        if (champLocked)
            return;

        selectedChampIcon.sprite = eliseIcon;
        championBackground.sprite = eliseBackground;
        selectedChamp = "Elise";
        OnChampPick();
    }
    public void OnTryndamerePick()
    {
        if (champLocked)
            return;

        selectedChampIcon.sprite = tryndamereIcon;
        championBackground.sprite = tryndamereBackground;
        selectedChamp = "Tryndamere";
        OnChampPick();
    }
    public void OnZileanPick()
    {
        if (champLocked)
            return;

        selectedChampIcon.sprite = zileanIcon;
        championBackground.sprite = zileanBackground;
        selectedChamp = "Zilean";
        OnChampPick();
    }


    public void Lock()
    {
        if (!champSelected)
            return;

        if (champLocked)
            return;

        champLocked = true;
        if (selectedChamp.Equals("Ahri"))
            OnAhriLock();
        else if (selectedChamp.Equals("Aphelios"))
            OnApheliosLock();
        else if (selectedChamp.Equals("Elise"))
            OnEliseLock();
        else if (selectedChamp.Equals("Tryndamere"))
            OnTryndamereLock();
        else
            OnZileanLock();
    }
    public void OnAhriLock()
    {
        Play(ahriPick);
        StartCoroutine(LoadScene("Ahri Scene"));
    }
    public void OnApheliosLock()
    {
        Play(apheliosPick);
        StartCoroutine(LoadScene("Aphelios Scene"));
    }
    public void OnEliseLock()
    {
        Play(elisePick);
        StartCoroutine(LoadScene("Elise Scene"));
    }
    public void OnTryndamereLock()
    {
        Play(tryndamerePick);
        StartCoroutine(LoadScene("Tryndamere Scene"));
    }
    public void OnZileanLock()
    {
        Play(zileanPick);
        StartCoroutine(LoadScene("Zilean Scene"));
    }

    private void Play(AudioClip clip)
    {
        audioSourceBg.volume = 0.5f;
        audioSourcePick.clip = clip;
        audioSourcePick.Play();
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(audioSourcePick.clip.length);
        SceneManager.LoadScene(sceneName);
    }
}
