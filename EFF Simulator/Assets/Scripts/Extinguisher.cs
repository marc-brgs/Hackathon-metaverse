using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float extinguishForce = 0.1f; // per second

    [SerializeField] private ParticleSystem Hose;
    
    private bool isEsting;

    public void Start()
    {
        
    }

    void Update()
    {
        var emissionModule = Hose.emission;
        
        if (Input.GetMouseButtonDown(0))
        {
            isEsting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isEsting = false;
        }

        if (isEsting)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f) && hit.collider.TryGetComponent(out Fire fire))
            {
                fire.TryExtinguish(extinguishForce * Time.deltaTime);
            }
            emissionModule.rateOverTime = 30;
        }


        if (!isEsting)
        {
            emissionModule.rateOverTime = 0;
        }
        
        
        
           




    }
}
