using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VehicleControl : MonoBehaviour
{
    private GameObject FrontWheel, RearWheel, FinishCoin;

    private Text TimeText, SpeedText, LeftText;

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
        FinishCoin = GameObject.Find("FinishCoin");
        RearWheelBody = RearWheel.GetComponent<Rigidbody2D>();
        FrontWheelBody = FrontWheel.GetComponent<Rigidbody2D>();
        CarBody = GetComponent<Rigidbody2D>();
        sounds = GetComponents<AudioSource>();
        audioD = sounds[0];
        audioSpace = sounds[1];
        MainCamera = Camera.main;
        FirstUpdate = true;

        var tmp = GameObject.Find("TimeText");
        TimeText = tmp.GetComponent<Text>();
        tmp = GameObject.Find("SpeedText");
        SpeedText = tmp.GetComponent<Text>();
        tmp = GameObject.Find("LeftText");
        LeftText = tmp.GetComponent<Text>();
        audioD.Play();
        audioD.volume = 0;
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
        if (Input.GetKey(KeyCode.A))
        {
            RearWheelBody.AddTorque(40);
            FrontWheelBody.AddTorque(40);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RearWheelBody.AddTorque(-40);
            FrontWheelBody.AddTorque(-40);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarBody.AddForce(Vector2.right * 40, ForceMode2D.Impulse);
            audioSpace.Play();
        }

        DoCamera();
        ProbeCrash();
        SetSoundVolume();
        SetText();
    }

    private void SetText()
    {
        TimeText.text = "Time: " + (Time.time - StartTime).ToString("0.00") + "s";
        SpeedText.text = "Speed: " + CarBody.velocity.magnitude.ToString("0.00");
        LeftText.text = "Distance: " + (FinishCoin.transform.position.x - CarBody.transform.position.x).ToString("0.00");
    }

    private void SetSoundVolume()
    {
        float z = RearWheelBody.angularVelocity;
        z = Mathf.Abs(z / 360f);
        var MAX = 10f;
        float vol = 0;
        if (z > MAX) vol = 1;
        else
        {
            vol = z / 30f;
        }

        var oldVol = audioD.volume;
        oldVol += Mathf.Min(vol - oldVol, 0.05f);
        audioD.volume = oldVol;
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
