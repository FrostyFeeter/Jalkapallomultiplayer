using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 250f;
    public float minXAngle = -80f;
    public float maxAngle = 90f;
    Transform playerbody;
    private float mouseX;
    private float mouseY;

    private float xRotation = 0f;
    public CursorLockMode mode;
}
