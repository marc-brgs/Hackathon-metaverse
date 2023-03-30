using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0, 1f)] private float currentIntensity = 1.0f;
    private float [] startIntensities = new float[0];
    
    [SerializeField] private ParticleSystem [] particleSystems = new ParticleSystem[0];
    
    private bool isLit = true;
    [SerializeField] private ParticleSystem postSmoke;
    
    private void Start()
    {
        startIntensities = new float[particleSystems.Length];
        for (int i = 0; i < particleSystems.Length; i++)
        {
            startIntensities[i] = particleSystems[i].emission.rateOverTime.constant;
        }
    }

    private float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = 1.0f;
    private void Update()
    {
        if (isLit && currentIntensity < 1f)
        {
            Regenerate();
        }
    }

    private void Regenerate()
    {
        if (Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            var emission = particleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
        
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;
        
        currentIntensity -= amount;
        ChangeIntensity();
        
        if (currentIntensity <= 0f)
        {
            isLit = false;
            postSmoke.gameObject.SetActive(true);
        }
        
        return !isLit; // succeed
    }
}
