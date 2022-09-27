using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // READ ME:
    // This script is responsible for the usage of first person view camera on the player.
    // Around horizontally is 360 turnover but vertically is locked to 180.
    // P.S Its working fine DONT TOUCH IT.
    // P.S 2.0 If it doesnt work fine talk to me 
    // ~Kon 

    public float sensX;
    public float sensY;
    public Transform location;
    float xRotation;
    float yRotation;




    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        location.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
