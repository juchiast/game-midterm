using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleControl : MonoBehaviour
{
    private GameObject FrontWheel, RearWheel;

    private Rigidbody2D RearWheelBody, FrontWheelBody, CarBody;

    private Camera MainCamera;

    private bool FirstUpdate;
    
    private float StartTime;

    AudioSource[] sounds;

    AudioSource audioD, audioSpace;
    // Start is called before the first frame update
    void Start()
    {
        FrontWheel = GameObject.Find("FrontWheel");
        RearWheel = GameObject.Find("RearWheel");
        RearWheelBody = RearWheel.GetComponent<Rigidbody2D>();
        FrontWheelBody = FrontWheel.GetComponent<Rigidbody2D>();
        CarBody = GetComponent<Rigidbody2D>();
        sounds = GetComponents<AudioSource>();
        audioD = sounds[0];
        audioSpace = sounds[1];
        MainCamera = Camera.main;
        FirstUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstUpdate)
        {
            StartTime = Time.time;
            FirstUpdate = false;
        }

        audioSpace.Pause();
        audioD.Pause();
        if (Input.GetKey(KeyCode.A))
        {
            RearWheelBody.AddTorque(40);
            FrontWheelBody.AddTorque(40);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RearWheelBody.AddTorque(-40);
            FrontWheelBody.AddTorque(-40);
            audioD.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarBody.AddForce(Vector2.right * 40, ForceMode2D.Impulse);
            audioSpace.Play();
        }

        DoCamera();
        ProbeCrash();
    }

    private float FlipStartTime = -1;
    private float MAX_FLIP_TIME = 4;

    private void ProbeCrash() {
        var z = transform.eulerAngles.z;
        if (90 <= z && z <= 270)
        {
            if (FlipStartTime < 0) FlipStartTime = Time.time;
            else
            {
                var flipped = Time.time - FlipStartTime;
                if (flipped > MAX_FLIP_TIME) FinishGame(false);
            }
        }
        else
        {
            FlipStartTime = -1;
        }
    }

    private void DoCamera()
    {
        Vector3 pos = MainCamera.transform.position;
        pos.x = transform.position.x;
        MainCamera.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "FinishCoin")
        {
            FinishGame(true);
        }
    }

    private void FinishGame(bool win)
    {
        if (win)
        {
            float now = Time.time;
            FinishWin.FinishTime = now - StartTime;
            SceneManager.LoadScene("FinishWin");
        }
        else
        {
            SceneManager.LoadScene("FinishLose");
        }
    }
}
