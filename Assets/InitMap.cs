using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMap : MonoBehaviour
{
    public GameObject BluePrefab;
    public GameObject RedPrefab;
    public GameObject TruckPrefab;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        GameObject prefab = GetSelectedModel();
        GameObject car = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        car.transform.parent = Player.transform;
        car.transform.localPosition = Vector3.zero;
    }

    private GameObject GetSelectedModel()
    {
        string carName = CarSelector.CarNames[CarSelector.SelectedCar];
        switch (carName)
        {
            case "Blue":
                return BluePrefab;
            case "Red":
                return RedPrefab;
            case "Truck":
                return TruckPrefab;
        }
        throw new Exception("Can't start map due do invalid car");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
