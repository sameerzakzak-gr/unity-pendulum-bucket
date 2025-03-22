using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Came : MonoBehaviour
{
    public CharacterController characterController;
    float mouseRotateSpeed = 80f;
    float cameraSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //  Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * mouseRotateSpeed * Time.deltaTime;
        float x = Input.GetAxis("Mouse Y") * mouseRotateSpeed * Time.deltaTime;
        transform.Rotate(-x, y, 0);

        Vector3 Angles = Camera.main.transform.eulerAngles;
        transform.eulerAngles = new Vector3(Angles.x, Angles.y, 0);
        MoveMyCamera();
    }

    void MoveMyCamera()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * cameraSpeed * Time.deltaTime);

    }
}
