using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Civilian"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.UpdateUI();
        }
    }
}
