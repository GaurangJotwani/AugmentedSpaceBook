using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToScale : MonoBehaviour
{
    float dist;
    private Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2) {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
                touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled
                ) {
                return;
            }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                dist = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = this.transform.localScale;

            }
            else {

                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(dist, 0)) return;

                var factor = currentDistance / dist;
                this.transform.localScale = initialScale * factor;
            }


        }
    }
}
