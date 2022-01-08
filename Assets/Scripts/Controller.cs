using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Controller : MonoBehaviour
{
    [HideInInspector] public VideoPlayer player;
    public Coroutine coroutine;

    public void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
}
