using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BestTime : MonoBehaviour
{
    public GameObject Yarisi;
    public GameObject finish;
    public GameObject EnDakika, EnSaniye, EnSalise;
    private void OnTriggerEnter()
    {
        if (LapTime.Saniye <= 9)
        {
            EnSaniye.GetComponent<Text>().text = "0" + LapTime.Saniye + ":";
        }
        else
        {
            EnSaniye.GetComponent<Text>().text = "" + LapTime.Saniye + ":";
        }
        if (LapTime.Dakika <= 9)
        {
            EnDakika.GetComponent<Text>().text = "0" + LapTime.Dakika + ":";
        }
        else
        {
            EnDakika.GetComponent<Text>().text = "" + LapTime.Dakika + ":";
        }

        EnSalise.GetComponent<Text>().text = "" + LapTime.Salise;
        
        LapTime.Dakika = 0;
        LapTime.Salise = 0;
        LapTime.Saniye = 0;
        Yarisi.SetActive(true);
        finish.SetActive(false);
    }
}
