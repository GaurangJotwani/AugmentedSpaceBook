using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddOneToScore : MonoBehaviour
{
    public TMP_Text scoreText;
    int cScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void AddOne() {
        scoreText.text = cScore + 1 + "";
        cScore += 1;
    }
}
