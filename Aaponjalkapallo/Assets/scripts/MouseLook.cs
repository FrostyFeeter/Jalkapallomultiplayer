using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 250f;
    public float minXAngle = -80f;
    public float maxAngle = 90f;
    Transform playerBody;
    private float mouseX;   
    private float mouseY;

    private float xRotation = 0f;
    public CursorLockMode mode;
    void Start()
    {
        Cursor.lockState = mode;
        playerBody = gameObject.transform.parent;
    }
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") *mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") *mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        xRotation = Mathf.Clamp(xRotation, minXAngle, maxAngle);
    }
    
}
