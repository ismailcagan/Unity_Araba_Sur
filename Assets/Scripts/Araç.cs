using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araç : MonoBehaviour
{
    public GameObject Araci;

    private void Start()
    {
        Araci.GetComponent<CarControllerTwo>().enabled = true;
    }
}
