using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private PhotonView photonView;
    
    [SerializeField] private MonoBehaviour XROrigin;
    [SerializeField] private MonoBehaviour InputActionManager;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MonoBehaviour playerMovement;
    [SerializeField] private MonoBehaviour leftXRController;
    [SerializeField] private MonoBehaviour leftXRRayInteractor;
    [SerializeField] private MonoBehaviour rightXRController;
    [SerializeField] private MonoBehaviour rightXRRayInteractor;
    
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

        if (photonView.IsMine)
        {
            XROrigin.enabled = true;
            InputActionManager.enabled = true;
            characterController.enabled = true;
            playerMovement.enabled = true;
            leftXRController.enabled = true;
            leftXRRayInteractor.enabled = true;
            rightXRController.enabled = true;
            rightXRRayInteractor.enabled = true;
        }
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
