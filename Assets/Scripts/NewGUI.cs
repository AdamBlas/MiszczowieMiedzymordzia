using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGUI : MonoBehaviour
{
    [SerializeField] GameObject advancedHud;
    [SerializeField] GameObject introHud;

    [SerializeField] Color on;
    [SerializeField] Color onHover;
    [SerializeField] Color off;
    [SerializeField] Color offHover;


    SpriteRenderer sprite;
    bool isOn = false;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = off;

        advancedHud.SetActive(false);
        introHud.SetActive(true);
    }

    public void OnMouseEnter()
    {
        sprite.color = isOn ? onHover : offHover;
    }
    public void OnMouseExit()
    {
        sprite.color = isOn ? on : off;
    }
    public void OnMouseDown()
    {
        isOn = !isOn;
        sprite.color = isOn ? onHover : offHover;

        advancedHud.SetActive(isOn);
        introHud.SetActive(!isOn);
    }
}
