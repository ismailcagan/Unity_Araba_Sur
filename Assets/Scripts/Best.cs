using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Best : MonoBehaviour
{
    public GameObject finish;
    public GameObject yarisi;

    private void OnTriggerEnter()
    {
        finish.SetActive(true);
        yarisi.SetActive(false);
    }
    
}
