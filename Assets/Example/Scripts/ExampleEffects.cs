﻿/*
  ExampleEffects.cs - This script contains handles for button pushes.
  It provides some insight on the usage of AtmoLight.
  Created by Atmo, February 2, 2018.
*/

using System.Collections;
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

        strip.SetAll(new Color32(0,0,33,255));
    }

    public void RandomOn()
    {
        if (!randomOn && on)
        {
            SaveColors();
            randomOn = true;
            StartCoroutine(RandomEffect());
        }
    }

    public void RandomOff()
    {
        randomOn = false;
    }

    public void StripOn()
    {
        if (!on)
        {
            on = true;
            LoadColors();
        }
    }

    public void StripOff()
    {
        if (on)
        {
            on = false;
            randomOn = false;

            SaveColors();

            strip.SetAll(new Color32(0, 0, 0, 255));
        }
    }

    private IEnumerator RandomEffect()
    {
        while (randomOn)
        {
            for (int i = 0; i < strip._numLeds; i++)
            {
                strip.SetPixelColor(i, new Color32((byte)Random.Range(0, 20), (byte)Random.Range(0, 20), (byte)Random.Range(0, 20), 255));
            }

            yield return new WaitForSeconds(0.1f);
        }
        LoadColors();
    }

    private void SaveColors()
    {
        for (int i = 0; i < strip._numLeds; i++)
        {
            lastColors[i] = strip.GetPixelColor(i);
        }
    }

    private void LoadColors()
    {
        for (int i = 0; i < strip._numLeds; i++)
        {
            strip.SetPixelColor(i, lastColors[i]);
        }
    }
}
