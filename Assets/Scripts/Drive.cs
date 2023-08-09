using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 0.1f;
    public float rotationSpeed = 30.0f;
    private Movement movement;
    // Start is called before the first frame update
    private void Start()
    {
        

    }

    private void Awake()
    {
        movement = new Movement();
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = movement.MarsRover.Move.ReadValue<Vector2>()[1] * speed * Time.deltaTime;
        Debug.Log(translation);
        //if (translation > 0)
        //{
        //    wheel1.transform.Rotate(0, 0, 1.0f, Space.World);
        //    wheel2.transform.Rotate(0, 0, 1.0f, Space.World);
        //    wheel3.transform.Rotate(0, 0, 1.0f, Space.World);
        //    wheel4.transform.Rotate(0, 0, 1.0f, Space.World);
        //    wheel5.transform.Rotate(0, 0, 1.0f, Space.World);
        //    wheel6.transform.Rotate(0, 0, 1.0f, Space.World);
        //}
        //else if (translation < 0) {
        //    wheel1.transform.Rotate(0, 0, -1.0f, Space.World);
        //    wheel2.transform.Rotate(0, 0, -1.0f, Space.World);
        //    wheel3.transform.Rotate(0, 0, -1.0f, Space.World);
        //    wheel4.transform.Rotate(0, 0, -1.0f, Space.World);
        //    wheel5.transform.Rotate(0, 0, -1.0f, Space.World);
        //    wheel6.transform.Rotate(0, 0, -1.0f, Space.World);

        //}
        float rotation = movement.MarsRover.Move.ReadValue<Vector2>()[0] * rotationSpeed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
        transform.Rotate(0, rotation, 0);
    }
}
