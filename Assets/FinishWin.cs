using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishWin : MonoBehaviour
{
    public static float FinishTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        var objResult = GameObject.Find("Result");
        objResult.GetComponent<Text>().text = "Time: " + FinishTime.ToString("0.00") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OK()
    {
        SceneManager.LoadScene("MapSelector");
    }
}
