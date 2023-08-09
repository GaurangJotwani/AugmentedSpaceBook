using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goob;
    GameObject home;
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
        InvokeRepeating("Spawn", 0, 1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() {
        Debug.Log("Started Spawint");
        home = GameObject.FindWithTag("home");
        if (home)
        {
            Instantiate(goob, this.transform.position, this.transform.rotation);
        }
        else {
            Debug.Log("Cancel Spawint");
            CancelInvoke();
        }

        
    }
}
