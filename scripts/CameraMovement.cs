using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    float mouseRotateSpeed = 80f;
    float cameraSpeed = 1f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * mouseRotateSpeed * Time.deltaTime;
        float x = Input.GetAxis("Mouse Y") * mouseRotateSpeed * Time.deltaTime;
        transform.Rotate(-x, y, 0);

        Vector3 Angles = Camera.main.transform.eulerAngles;
        transform.eulerAngles = new Vector3(Angles.x, Angles.y, 0);

        if (Input.GetKeyDown("W"))
        {
            transform.position += Vector3.forward * cameraSpeed;
        }
    }
}
