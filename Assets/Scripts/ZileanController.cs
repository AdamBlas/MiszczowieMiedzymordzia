using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ZileanController : Controller
{
    [SerializeField] VideoClip idle;
    [SerializeField] VideoClip r;

    [SerializeField] SpriteRenderer rIcon;
    [SerializeField] SpriteRenderer revIcon;

    bool onCooldown = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !onCooldown)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(Ult());
        }
    }

    public IEnumerator Ult()
    {
        onCooldown = true;
        rIcon.enabled = false;
        revIcon.enabled = true;
        player.frame = 0;
        player.clip = r;

        yield return new WaitForSeconds(5.25f);
        revIcon.enabled = false;
        yield return new WaitForSeconds((float)r.length - 5.25f);

        player.clip = idle;
        onCooldown = false;
        rIcon.enabled = true;
    }
}
