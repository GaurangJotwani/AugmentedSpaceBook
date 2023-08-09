using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllGoobs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("goober");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }
}
