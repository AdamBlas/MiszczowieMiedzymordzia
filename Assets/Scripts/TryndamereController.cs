using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TryndamereController : Controller
{
    [SerializeField] VideoClip idle;
    [SerializeField] VideoClip r;

    [SerializeField] SpriteRenderer bonusBar;
    [SerializeField] SpriteRenderer immortalIcon;
    [SerializeField] Image background;
    [SerializeField] LineRenderer durationBar;

    Coroutine durationBarCoroutine;
    Vector3 leftPoint;
    Vector3 rightPoint;
    float barLength;


    new void Start()
    {
        base.Start();

        leftPoint = durationBar.GetPosition(0);
        rightPoint = durationBar.GetPosition(1);

        barLength = rightPoint.x - leftPoint.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(Ult());
        }
    }

    public IEnumerator Ult()
    {
        if (durationBarCoroutine != null)
            StopCoroutine(durationBarCoroutine);
        durationBarCoroutine = StartCoroutine(DurationBar());

        player.frame = 0;
        player.clip = r;
        yield return new WaitForSeconds((float)r.length);
        player.clip = idle;
    }

    public IEnumerator DurationBar()
    {
        bonusBar.enabled = true;
        immortalIcon.enabled = true;
        durationBar.enabled = true;
        background.enabled = true;

        durationBar.SetPositions(new Vector3[] { leftPoint, rightPoint });
        float duration = 5f;
        float durationLeft = duration;

        while (true)
        {
            durationBar.SetPosition(1, Vector3.Lerp(leftPoint, rightPoint, durationLeft / duration));
            if (durationBar.GetPosition(1).x == durationBar.GetPosition(0).x)
                break;
            durationLeft -= Time.deltaTime;
            yield return null;
        }

        bonusBar.enabled = false;
        immortalIcon.enabled = false;
        durationBar.enabled = false;
        background.enabled = false;
    }
}
