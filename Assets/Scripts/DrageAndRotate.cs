using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrageAndRotate : MonoBehaviour
{
    private bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            Touch screenTouch = Input.GetTouch(0);
            if (Input.touchCount == 1) {
                if (screenTouch.phase == TouchPhase.Moved) {
                    transform.Rotate(0f, screenTouch.deltaPosition.x, 0f);
                }
            }

            if (screenTouch.phase == TouchPhase.Ended) {

                isActive = true;
            }
        }
    }
}
