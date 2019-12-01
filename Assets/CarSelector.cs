using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    public static int SelectedCar;

    public static readonly String[] CarNames = {"Blue", "Red", "Truck"};

    private GameObject[] CarImages;

    private GameObject[] CarButtons;

    // Start is called before the first frame update
    void Start()
    {
        SelectedCar = 0;

        CarImages = new[]
        {
            GameObject.Find("ImageBlue"),
            GameObject.Find("ImageRed"),
            GameObject.Find("ImageTruck"),
        };

        CarButtons = new[]
        {
            GameObject.Find("BtnBlue"),
            GameObject.Find("BtnRed"),
            GameObject.Find("BtnTruck"),
        };
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject image in CarImages)
        {
            image.SetActive(false);
        }
        
        CarImages[SelectedCar].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CarSelector");
    }
}
