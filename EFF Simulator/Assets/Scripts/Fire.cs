using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float currentIntensity = 1.0f;
    private float startIntensity = 5.0f;

    [SerializeField] private ParticleSystem firePS = null;

    private void Start()
    {
        startIntensity = firePS.emission.rateOverTime.constant;
    }

    private void ChangeIntensity()
    {
        var emission = firePS.emission.rateOverTime;
        emission.constant = currentIntensity * startIntensity;
    }
}
