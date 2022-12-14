using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    private string sceneName;
    private float timeLevel;
    public TMP_Text time, bestTime;
    public static bool stopTime;
    // Start is called before the first frame update
    void Start()
    {
        stopTime = false;
        sceneName = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.GetFloat(sceneName) == 0){
            bestTime.text = "Best: _____";
        }else{
            bestTime.text = "Best: " + PlayerPrefs.GetFloat(sceneName).ToString("F2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTime == false){
            timeLevel = timeLevel + Time.deltaTime;
            time.text = timeLevel.ToString("0");
        }else if(timeLevel < PlayerPrefs.GetFloat(sceneName) || PlayerPrefs.GetFloat(sceneName) == 0){
            PlayerPrefs.SetFloat(sceneName, timeLevel);
            PlayerPrefs.Save();
            bestTime.text = "Best: " + PlayerPrefs.GetFloat(sceneName).ToString("F2");
        }
        
    }
}
