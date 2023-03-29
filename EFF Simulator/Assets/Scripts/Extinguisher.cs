using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float extinguishForce = 0.1f; // per second
    
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f) && hit.collider.TryGetComponent(out Fire fire))
        {
            fire.TryExtinguish(extinguishForce * Time.deltaTime);
        }
    }
}
