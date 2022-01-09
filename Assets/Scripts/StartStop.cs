using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStop : MonoBehaviour
{
    public AudioSource Get, Go;
    public GameObject Yazi, CarControl, Timer;
    private void Start()
    {
        StartCoroutine(StartGO());
    }
    IEnumerator StartGO()
    {
        yield return new WaitForSeconds(0.5f);
        Yazi.GetComponent<Text>().text = "3";
        Get.Play();
        Yazi.SetActive(true);
        
        yield return new WaitForSeconds(1);
        Yazi.SetActive(false);
        Yazi.GetComponent<Text>().text = "2";
        Get.Play();
        Yazi.SetActive(true);
        
        yield return new WaitForSeconds(1);
        Yazi.SetActive(false);
        Yazi.GetComponent<Text>().text = "1";
        Get.Play();
        Yazi.SetActive(true);

        yield return new WaitForSeconds(1);
        Yazi.SetActive(false);
        Go.Play();
        CarControl.SetActive(true);
        Timer.SetActive(true);
    }
}
