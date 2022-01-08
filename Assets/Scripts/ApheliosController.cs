using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ApheliosController : Controller
{
    enum Status { calibrum, cal2sev, severum, sev2cal };

    [SerializeField] VideoClip calibrumIdle;
    [SerializeField] VideoClip calibrumToSeverum;
    [SerializeField] VideoClip severumIdle;
    [SerializeField] VideoClip severumToCalibrum;

    [SerializeField] GameObject greenAmmo;
    [SerializeField] GameObject redAmmo;

    Status status;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchWeapons();
        }
    }

    void SwitchWeapons()
    {
        if (status == Status.calibrum || status == Status.sev2cal)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(SwitchToSeverum());
        }
        else
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(SwitchToCalibrum());
        }
    }

    IEnumerator SwitchToSeverum()
    {
        greenAmmo.SetActive(false);
        redAmmo.SetActive(true);
        player.clip = calibrumToSeverum;
        status = Status.cal2sev;
        yield return new WaitForSeconds((float)player.length);
        player.clip = severumIdle;
        status = Status.severum;
    }

    IEnumerator SwitchToCalibrum()
    {
        greenAmmo.SetActive(true);
        redAmmo.SetActive(false);
        player.clip = severumToCalibrum;
        status = Status.sev2cal;
        yield return new WaitForSeconds((float)player.length);
        player.clip = calibrumIdle;
        status = Status.calibrum;
    }
}
