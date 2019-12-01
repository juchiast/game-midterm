using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    public static int SelectedCar;

    public static readonly String[] CarNames = {"Blue", "Red", "Truck"};

    private GameObject[] CarImages;

    private GameObject[] CarButtons;

    private EventSystem MyEventSystem;

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
        GameObject tmp = GameObject.Find("EventSystem");
        MyEventSystem = tmp.GetComponent<EventSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject image in CarImages)
        {
            image.transform.localScale = Vector3.zero;
        }

        CarImages[SelectedCar].transform.localScale = Vector3.one;
        MyEventSystem.SetSelectedGameObject(CarButtons[SelectedCar]);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MapSelector.SelectedMap);
    }

    public void SelectBlue()
    {
        SelectCar("Blue");
    }
    
    public void SelectRed()
    {
        SelectCar("Red");
    }
    
    public void SelectTruck()
    {
        SelectCar("Truck");
    }

    private void SelectCar(string name)
    {
        for (int i = 0; i < CarNames.Length; i++)
        {
            if (name == CarNames[i])
            {
                SelectedCar = i;
                break;
            }
        }
        throw new Exception("RIP");
    }
    
}
