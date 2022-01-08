using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EliseController : Controller
{
    [SerializeField] VideoClip humanIdle;
    [SerializeField] VideoClip spiderIdle;

    [SerializeField] VideoClip humanQ;
    [SerializeField] VideoClip humanW;
    [SerializeField] VideoClip humanE;
    [SerializeField] VideoClip human2spider;

    [SerializeField] VideoClip spiderQ;
    [SerializeField] VideoClip spiderW;
    [SerializeField] VideoClip spiderE;
    [SerializeField] VideoClip spider2human;

    [SerializeField] GameObject humanGUI;
    [SerializeField] GameObject spiderGUI;

    [SerializeField] EliseCooldown QBefore;
    [SerializeField] EliseCooldown WBefore;
    [SerializeField] EliseCooldown EBefore;
    [SerializeField] EliseCooldown RBefore;
    [SerializeField] EliseCooldown QAfter;
    [SerializeField] EliseCooldown WAfter;
    [SerializeField] EliseCooldown EAfter;
    [SerializeField] EliseCooldown RAfter;

    [SerializeField] GameObject humanBar;
    [SerializeField] GameObject spiderBar;

    bool inHumanForm = true;
    bool blocked = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inHumanForm && QBefore.humanAval && !blocked)
            {
                StartCoroutine(HumanQ());
            }
            if (!inHumanForm && QBefore.spiderAval && !blocked)
            {
                StartCoroutine(SpiderQ());
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (inHumanForm && WBefore.humanAval && !blocked)
            {
                StartCoroutine(HumanW());
            }
            if (!inHumanForm && WBefore.spiderAval && !blocked)
            {
                StartCoroutine(SpiderW());
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inHumanForm && EBefore.humanAval && !blocked)
            {
                StartCoroutine(HumanE());
            }
            if (!inHumanForm && EBefore.spiderAval && !blocked)
            {
                StartCoroutine(SpiderE());
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (inHumanForm && RBefore.humanAval && !blocked)
            {
                StartCoroutine(HumanR());
            }
            if (!inHumanForm && RBefore.spiderAval && !blocked)
            {
                StartCoroutine(SpiderR());
            }
        }
    }

    IEnumerator HumanQ()
    {
        QBefore.StartHumanCooldown();
        QAfter.StartHumanCooldown();
        player.frame = 0;
        player.clip = humanQ;
        blocked = true;

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = humanIdle;
        blocked = false;
    }
    IEnumerator HumanW()
    {
        WBefore.StartHumanCooldown();
        WAfter.StartHumanCooldown();
        player.frame = 0;
        player.clip = humanW;
        blocked = true;

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = humanIdle;
        blocked = false;
    }
    IEnumerator HumanE()
    {
        EBefore.StartHumanCooldown();
        EAfter.StartHumanCooldown();
        player.frame = 0;
        player.clip = humanE;
        blocked = true;

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = humanIdle;
        blocked = false;
    }
    IEnumerator HumanR()
    {
        QBefore.showsHumanCD = false;
        WBefore.showsHumanCD = false;
        EBefore.showsHumanCD = false;
        RBefore.showsHumanCD = false;
        QAfter.showsHumanCD = false;
        WAfter.showsHumanCD = false;
        EAfter.showsHumanCD = false;
        RAfter.showsHumanCD = false;

        RBefore.StartSpiderCooldown();
        RAfter.StartSpiderCooldown();
        player.frame = 0;
        player.clip = human2spider;
        blocked = true;
        inHumanForm = false;

        humanGUI.SetActive(false);
        spiderGUI.SetActive(true);

        humanBar.SetActive(false);
        spiderBar.SetActive(true);


        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = spiderIdle;
        blocked = false;
    }

    IEnumerator SpiderQ()
    {
        QBefore.StartSpiderCooldown();
        QAfter.StartSpiderCooldown();
        player.frame = 0;
        player.clip = spiderQ;
        blocked = true;

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = spiderIdle;
        blocked = false;

    }
    IEnumerator SpiderW()
    {
        WBefore.StartSpiderCooldown();
        WAfter.StartSpiderCooldown();
        player.frame = 0;
        player.clip = spiderW;
        blocked = true;

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = spiderIdle;
        blocked = false;
    }
    IEnumerator SpiderE()
    {
        EBefore.StartSpiderCooldown();
        EAfter.StartSpiderCooldown();
        player.frame = 0;
        player.clip = spiderE;
        blocked = true;

        yield return new WaitForSeconds(0.15f);
        spiderBar.SetActive(false);
        yield return new WaitForSeconds((float)player.length - 1f);
        spiderBar.SetActive(true);
        yield return new WaitForSeconds(0.85f);

        spiderBar.SetActive(true);
        player.frame = 0;
        player.clip = spiderIdle;
        blocked = false;
    }
    IEnumerator SpiderR()
    {
        QBefore.showsHumanCD = true;
        WBefore.showsHumanCD = true;
        EBefore.showsHumanCD = true;
        RBefore.showsHumanCD = true;
        QAfter.showsHumanCD = true;
        WAfter.showsHumanCD = true;
        EAfter.showsHumanCD = true;
        RAfter.showsHumanCD = true;

        RBefore.StartHumanCooldown();
        RAfter.StartHumanCooldown();
        player.frame = 0;
        player.clip = spider2human;
        blocked = true;
        inHumanForm = true;

        humanGUI.SetActive(true);
        spiderGUI.SetActive(false);

        humanBar.SetActive(true);
        spiderBar.SetActive(false);

        yield return new WaitForSeconds((float)player.length);

        player.frame = 0;
        player.clip = humanIdle;
        blocked = false;

    }

}
