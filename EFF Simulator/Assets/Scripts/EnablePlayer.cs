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
    [SerializeField] private LineRenderer leftLineRenderer;
    [SerializeField] private MonoBehaviour leftInteractorLineVisual;
    [SerializeField] private MonoBehaviour rightXRController;
    [SerializeField] private MonoBehaviour rightXRRayInteractor;
    [SerializeField] private LineRenderer rightLineRenderer;
    [SerializeField] private MonoBehaviour rightInteractorLineVisual;
    [SerializeField] private GameObject XRDeviceSimulator;
    [SerializeField] private GameObject mainCamera;
    
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
            leftLineRenderer.enabled = true;
            leftInteractorLineVisual.enabled = true;
            rightXRController.enabled = true;
            rightXRRayInteractor.enabled = true;
            rightLineRenderer.enabled = true;
            rightInteractorLineVisual.enabled = true;
            XRDeviceSimulator.SetActive(true);
            mainCamera.SetActive(true);
        }
    }
}
