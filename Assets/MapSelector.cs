using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    public static String SelectedMap;
    public static String SelectedCar;

    private GameObject MapCheck;
    private GameObject BtnWinter;
    private GameObject BtnNight;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectedMap = "NightMap";
        SelectedCar = "Blue";
        
        MapCheck = GameObject.Find("MapCheck");
        BtnWinter = GameObject.Find("BtnWinter");
        BtnNight = GameObject.Find("BtnNight");
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedMap == "NightMap")
        {
            MapCheck.transform.position = BtnNight.transform.position;
        }
        if (SelectedMap == "WinterMap")
        {
            MapCheck.transform.position = BtnWinter.transform.position;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CarSelector");
    }

    public void SelectNightMap()
    {
        SelectedMap = "NightMap";
    }

    public void SelectWinterMap()
    {
        SelectedMap = "WinterMap";
    }
}
