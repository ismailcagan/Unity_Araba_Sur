using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTime : MonoBehaviour
{
    public static int Dakika, Saniye;
    public static float Salise;
    public static string SaliseEkran;
    public GameObject EkranD, EkranS, EkranSalise;
    private void Update()
    {
        Salise += Time.deltaTime * 10;
        SaliseEkran = Salise.ToString("f0");
        EkranSalise.GetComponent<Text>().text = "" + SaliseEkran;
        if (Salise>=9)
        {
            Salise = 0;
            Saniye += 1;
        }
        if (Saniye<=9)
        {
            EkranS.GetComponent<Text>().text = "0" + Saniye + ".";
        }
        else
        {
            EkranS.GetComponent<Text>().text = "" + Saniye + ".";
        }

        if (Saniye >= 60)
        {
            Saniye = 0;
            Dakika += 1;
        }
        if (Dakika<=9)
        {
            EkranD.GetComponent<Text>().text = "0" + Dakika + "";
        }
        else
        {
            EkranD.GetComponent<Text>().text = "" + Dakika + "";
        }
    }
}
