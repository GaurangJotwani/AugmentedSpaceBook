using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopAnimation : MonoBehaviour
{
    GameObject gameObj;

    public void setAnimationObj(GameObject obj) {
        gameObj = obj;
    }

    public void turnOffAnimation()
    {
        gameObj.SetActive(false);
    }

    public void turnOnAnimation()
    {
        gameObj.SetActive(true);
    }
}
