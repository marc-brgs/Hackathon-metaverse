using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private TextMeshProUGUI civilianCounterText;
    
    private int civilianCounter = 0;
    private GameObject[] civilians;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
 
        instance = this;
    }
    
    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        civilians = GameObject.FindGameObjectsWithTag("Civilian");
        civilianCounter = 0;
        
        foreach(GameObject civilian in civilians)
        {
            if (civilian.active)
            {
                civilianCounter++;
            }
        }

        civilianCounterText.text = "CIVILIAN LEFT : " + civilianCounter;
    }
}
