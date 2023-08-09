using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{

    public Material[] materials;
    public Transform device;

    bool wasInFront;

    bool inOtherWorld;

    bool hasCollided;

    // Start is called before the first frame update
    void Start()
    {
        SetMaterials(false);
    }

    void SetMaterials(bool fullRender)
    {

        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;

        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)stencilTest);
        }
    }

    bool GetIsInFront() {

        Vector3 pos = transform.InverseTransformPoint(device.position);
        return pos.z >= 0 ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform != device) return;

        Debug.Log("Entered");
        wasInFront = GetIsInFront();
        hasCollided = true;
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != device) return;

        hasCollided = false;
    }

    void WhileCameraColliding() {

        if (!hasCollided) return;

        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront) && !isInFront)
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }

        wasInFront = isInFront;
    }




    private void OnDestroy()
    {
        SetMaterials(true);
    }

    // Update is called once per frame
    void Update()
    {
        WhileCameraColliding();
    }
}
