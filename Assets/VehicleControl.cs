using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    private GameObject FrontWheel, RearWheel;

    private Rigidbody2D RearWheelBody, FrontWheelBody;
    
    private Camera MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        FrontWheel = GameObject.Find("FrontWheel");
        RearWheel = GameObject.Find("RearWheel");
        RearWheelBody = RearWheel.GetComponent<Rigidbody2D>();
        FrontWheelBody = FrontWheel.GetComponent<Rigidbody2D>();
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RearWheelBody.AddTorque(30);
            FrontWheelBody.AddTorque(30);    
        }

        if (Input.GetKey(KeyCode.D))
        {
            RearWheelBody.AddTorque(-30);
            FrontWheelBody.AddTorque(-30);
        }
        
        DoCamera();
    }
    
    private void DoCamera() {
        Vector3 pos = MainCamera.transform.position;
        pos.x = transform.position.x;
        MainCamera.transform.position = pos;
    }
}
