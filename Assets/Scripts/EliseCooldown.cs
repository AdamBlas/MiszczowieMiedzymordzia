using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliseCooldown : MonoBehaviour
{
    [SerializeField] float humanCooldown;
    [SerializeField] float spiderCooldown;

    Image background;
    Image fill;
    Image subFill;
    Text text;

    float currHumanCD;
    float currSpiderCD;
    [HideInInspector] public bool showsHumanCD = true;
    [HideInInspector] public bool humanAval = true;
    [HideInInspector] public bool spiderAval = true;



    void Start()
    {
        background = transform.Find("Background").GetComponent<Image>();
        fill = transform.Find("Fill").GetComponent<Image>();
        text = GetComponentInChildren<Text>();

        background.enabled = false;
        fill.enabled = false;
        text.enabled = false;

        Transform subFillObj = transform.Find("SubFill");
        if (subFillObj != null)
        {
            subFill = subFillObj.Find("Fill").GetComponent<Image>();
        }
    }

    public void StartHumanCooldown()
    {
        currHumanCD = humanCooldown;
    }
    public void StartSpiderCooldown()
    {
        currSpiderCD = spiderCooldown;
    }

    public void Update()
    {
        float cooldown = 0;
        float fillVal = 0;
        float subFillVal = 0;

        if (currHumanCD > 0)
            currHumanCD -= Time.deltaTime;
        if (currSpiderCD > 0)
            currSpiderCD -= Time.deltaTime;

        if (showsHumanCD)
        {
            cooldown = currHumanCD;
            fillVal = currHumanCD / humanCooldown;
            subFillVal = currSpiderCD / spiderCooldown;
        }
        else
        {
            cooldown = currSpiderCD;
            fillVal = currSpiderCD / spiderCooldown;
            subFillVal = currHumanCD / humanCooldown;
        }

        if (cooldown > 0)
        {
            if (!fill.enabled)
            {
                background.enabled = true;
                fill.enabled = true;
                text.enabled = true;
            }

            fill.fillAmount = fillVal;

            if (cooldown > 1)
            {
                text.text = ((int)cooldown).ToString();
            }
            else
            {
                text.text = cooldown.ToString("n1");
            }
        }
        else if (fill.enabled)
        {
            background.enabled = false;
            fill.enabled = false;
            text.enabled = false;
        }

        if (subFill != null)
        {
            subFill.fillAmount = 1 - subFillVal;
        }
    }
}
