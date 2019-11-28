using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToMenu()
    {
        GameObject levelMenu = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        GameObject levelSetting = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        if (levelMenu != null)
        {
            levelMenu.SetActive(true);
            levelSetting.SetActive(false);
        }
        else
            Debug.Log("Null");
    }

    public void ToSetting()
    {
        GameObject levelMenu = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        GameObject levelSetting = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        if (levelSetting != null)
        {
            levelMenu.SetActive(false);
            levelSetting.SetActive(true);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
