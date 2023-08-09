using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public GameObject gmObj;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGmObj(GameObject obj) {
        gmObj = obj;
    }

    public void setIsPlaying(bool val) {
        isPlaying = val;
    }
}
