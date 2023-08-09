using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class PlayAudioOnClick : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    public GameObject obj;
    public TMP_Text txt;
    bool isPlaying;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.collider.gameObject.tag == "Audio")
                {
                    if (!isPlaying)
                    {
                        Debug.Log("STARTED");
                        audioData.Play();
                        obj.SetActive(false);
                        txt.text = "Pause";
                        isPlaying = true;
                    }
                    else {
                        audioData.Pause();
                        txt.text = "Audio";
                        isPlaying = false;
                        obj.SetActive(true);
                    }
                    
                }
            }

        }
    }
}
