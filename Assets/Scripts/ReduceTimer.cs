using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReduceTimer : MonoBehaviour
{
    
    public TMP_Text timeText;
    float cTime = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cTime -= Time.deltaTime;
        float seconds = Mathf.CeilToInt(cTime % 60);
        float minutes = 0.0f;
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if (seconds == 0)
        {
            Debug.Log("End Game!");
        }
    }
}
