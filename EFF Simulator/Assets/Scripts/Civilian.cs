using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rescue()
    {
        this.gameObject.SetActive(false);
        
        GameManager.instance.UpdateUI();
    }
}
