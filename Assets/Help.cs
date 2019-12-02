using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    private Text TextEnter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.Find("TextEnter");
        TextEnter = tmp.GetComponent<Text>();
        var color = TextEnter.color;
        color.a = (Mathf.Sin(Time.time * 6) + 1) / 2;
        TextEnter.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene(MapSelector.SelectedMap);
        }
        
        var color = TextEnter.color;
        color.a = (Mathf.Sin(Time.time * 6) + 1) / 2;
        TextEnter.color = color;
    }
}
