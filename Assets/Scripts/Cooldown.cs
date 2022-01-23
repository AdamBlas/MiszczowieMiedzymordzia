using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [SerializeField] float cooldown;

    Image background;
    Image fill;
    Image subFill;
    Text text;

    float currCD;
    [HideInInspector] public bool skillAval = true;



    void Start()
    {
        background = transform.Find("Background").GetComponent<Image>();
        fill = transform.Find("Fill").GetComponent<Image>();
        text = GetComponentInChildren<Text>();

        background.enabled = false;
        fill.enabled = false;
        text.enabled = false;
    }

    public void StartCooldown()
    {
        currCD = cooldown;
    }

    public void Update()
    {
        if (currCD > 0)
        {
            currCD -= Time.deltaTime;
            fill.fillAmount = currCD / cooldown;

            if (currCD > 1)
            {
                text.text = ((int)currCD).ToString();
            }
            else
            {
                text.text = currCD.ToString("n1");
            }

            if (!fill.enabled)
            {
                fill.enabled = true;
                background.enabled = true;
                text.enabled = true;

                skillAval = false;
            }
        }
        else
        {
            if (fill.enabled)
            {
                fill.enabled = false;
                background.enabled = false;
                text.enabled = false;

                skillAval = true;
            }
        }
    }
}
