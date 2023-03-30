using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    
    [SerializeField] private MonoBehaviour XROrigin;
    [SerializeField] private MonoBehaviour InputActionManager;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MonoBehaviour playerMovement;
    [SerializeField] private MonoBehaviour leftXRController;
    [SerializeField] private MonoBehaviour leftXRRayInteractor;
    [SerializeField] private MonoBehaviour rightXRController;
    [SerializeField] private MonoBehaviour rightXRRayInteractor;
    [SerializeField] private GameObject XRDeviceSimulator;
    
    // Start is called before the first frame update
    void Start()
    {
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
            XRDeviceSimulator.SetActive(true);
        }
    }
}
