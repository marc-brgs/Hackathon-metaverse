using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float currentIntensity = 1.0f;
    private float [] startIntensities = new float[0];
    
    [SerializeField] private ParticleSystem [] particleSystems = new ParticleSystem[0];

    private void Start()
    {
        startIntensities = new float[particleSystems.Length];
        for (int i = 0; i < particleSystems.Length; i++)
        {
            startIntensities[i] = particleSystems[i].emission.rateOverTime.constant;
        }
    }

    private void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            var emission = particleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
        
    }
}
