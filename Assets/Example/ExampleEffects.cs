﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEffects : MonoBehaviour {

    private Strip strip;
    private Color32[] lastColors;
    private bool randomOn = false;
    private bool on = true;

    // Use this for initialization
    void Start()
    {
        strip = GetComponent<Strip>();

        lastColors = new Color32[strip._numLeds];

        strip.SetAll(new Color32(10,12,3,255));

    }

    public void RandomOn()
    {
        if (!randomOn && on)
        {
            randomOn = true;
            StartCoroutine(RandomEffect());
        }
    }

    public void RandomOff()
    {
        randomOn = false;
    }

    private IEnumerator RandomEffect()
    {
        while (randomOn)
        {
            for (int i = 0; i < strip._numLeds; i++)
            {
                strip.setPixelColor(i, new Color32((byte)Random.Range(0,20),(byte)Random.Range(0, 20),(byte)Random.Range(0, 20),255));
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StripOn()
    {
        if (!on)
        {
            on = true;
            for (int i = 0; i < strip._numLeds; i++)
            {
                strip.setPixelColor(i, lastColors[i]);
            }
        }
    }

    public void StripOff()
    {
        if (on)
        {
            on = false;
            randomOn = false;
            for (int i = 0; i < strip._numLeds; i++)
            {
                lastColors[i] = strip.GetPixelColor(i);
            }

            strip.SetAll(new Color32(0, 0, 0, 255));
        }
    }
}
