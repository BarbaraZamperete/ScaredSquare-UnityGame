using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinsScript : MonoBehaviour
{
    public static bool save;
    public TMP_Text scoreTxt;
    private int score, totalScore;
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        save = false;
        // totalScore = PlayerPrefs.GetInt("totalScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
        // totalScoreTxt.text = totalScore.ToString();
        // SaveScore();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("coin") == true){
            score = score + 1;
            Destroy(col.gameObject);
        }
    }

    // private void SaveScore(){
    //     if(save == true){
    //         PlayerPrefs.SetInt("totalScore", score);
    //         PlayerPrefs.Save();
    //     }
    // }
}
