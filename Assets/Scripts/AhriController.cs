using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AhriController : Controller
{

    [SerializeField] VideoClip q;
    [SerializeField] VideoClip w;
    [SerializeField] VideoClip e;
    [SerializeField] VideoClip idle;

    [SerializeField] Image[] charges;
    [SerializeField] ParticleSystem healEffect;
    [SerializeField] int emissionRate;
    [SerializeField] float emissionTime;

    [SerializeField] Cooldown qCooldown;
    [SerializeField] Cooldown wCooldown;
    [SerializeField] Cooldown eCooldown;

    bool castingSpell = false;
    int chargesAmount = 0;

    bool qReady = true;
    bool wReady = true;
    bool eReady = true;
    Coroutine eCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !castingSpell && qCooldown.skillAval)
        {
            if (eCoroutine != null)
                StopCoroutine(eCoroutine);

            StartCoroutine(Q());
        }
        if (Input.GetKeyDown(KeyCode.W) && !castingSpell && wCooldown.skillAval)
        {
            if (eCoroutine != null)
                StopCoroutine(eCoroutine);

            StartCoroutine(W());
        }
        if (Input.GetKeyDown(KeyCode.E) && !castingSpell && eCooldown.skillAval)
        {
            if (eCoroutine != null)
                StopCoroutine(eCoroutine);

            eCoroutine = StartCoroutine(E());
        }
    }

    IEnumerator Q()
    {
        castingSpell = true;
        qCooldown.StartCooldown();
        player.frame = 0;
        player.clip = q;

        yield return new WaitForSeconds(0.5f);
        AddStack();
        yield return new WaitForSeconds((float)player.length - 1.25f);
        AddStack();
        yield return new WaitForSeconds(0.75f);

        castingSpell = false;
        player.frame = 0;
        player.clip = idle;
    }

    IEnumerator W()
    {
        wCooldown.StartCooldown();
        castingSpell = true;
        player.frame = 0;
        player.clip = w;

        yield return new WaitForSeconds(0.75f);
        AddStack();
        AddStack();
        AddStack();
        yield return new WaitForSeconds((float)player.length - 0.75f);

        castingSpell = false;
        player.frame = 0;
        player.clip = idle;
    }

    IEnumerator E()
    {
        eCooldown.StartCooldown();
        castingSpell = true;
        player.frame = 0;
        player.clip = e;

        yield return new WaitForSeconds(0.5f);
        AddStack();
        yield return new WaitForSeconds(0.75f);

        castingSpell = false;

        yield return new WaitForSeconds((float)player.length - 1.25f);
        player.frame = 0;
        player.clip = idle;
    }

    void AddStack()
    {
        if (chargesAmount == 9)
        {
            chargesAmount = 0;
            StartCoroutine(Heal());
        }
        else
        {
            ++chargesAmount;
            if (chargesAmount > 9)
                chargesAmount = 9;
        }

        for (int i = 0; i < 9; i++)
        {
            charges[i].enabled = i < chargesAmount;
        }
    }

    IEnumerator Heal()
    {
        var emission = healEffect.emission;
        emission.rateOverTime = emissionRate;
        yield return new WaitForSeconds(emissionTime);
        emission.rateOverTime = 0;
    }
}
