using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipIcon : MonoBehaviour
{
    public Sprite playIcon;
    public Sprite pauseIcon;
    public GameObject AudioManager;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipIconType() {
        audioData = AudioManager.GetComponent<AudioSource>();
        StartStopAnimation s2 = AudioManager.GetComponent<StartStopAnimation>();
        if (this.GetComponent<Image>().sprite == playIcon)
        {
            this.GetComponent<Image>().sprite = pauseIcon;
            if (audioData) {
                audioData.Play();
                s2.turnOffAnimation();
            }
            
        }
        else {
            this.GetComponent<Image>().sprite = playIcon;
            if (audioData) {
                audioData.Pause();
                s2.turnOnAnimation();
            }
        }
    }

    public void makePlay() {
        this.GetComponent<Image>().sprite = playIcon;
    }
}
