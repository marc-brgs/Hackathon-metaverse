using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float extinguishForce = 0.1f; // per second

    [SerializeField] private ParticleSystem hose;
    
    private bool isActive;

    private void Start()
    {
        isActive = false;
        var emission = hose.emission;
        emission.rateOverTime = 0;
    }

    void Update()
    {
        if (isActive && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f) && hit.collider.TryGetComponent(out Fire fire))
        {
            fire.TryExtinguish(extinguishForce * Time.deltaTime);
        }
    }

    public void Activate()
    {
        var emission = hose.emission;
        isActive = true;
        emission.rateOverTime = 30;
    }

    public void Disable()
    {
        var emission = hose.emission;
        isActive = false;
        emission.rateOverTime = 0;
    }
}
