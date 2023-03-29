using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
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
        Vector3 position = new Vector3(43f, 0f, 15f);
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
        UpdateUI();
    }

    public void UpdateUI()
    {
        civilians = GameObject.FindGameObjectsWithTag("Civilian");
        civilianCounter = 0;
        
        foreach(GameObject civilian in civilians)
        {
            if (civilian.activeSelf)
            {
                civilianCounter++;
            }
        }

        civilianCounterText.text = "CIVILIAN LEFT : " + civilianCounter;
    }
}
