using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControllerScript : MonoBehaviour
{ 
    private CharacterController charController;
    private int cameraSpeed = 270;
    private float playerSpeed = 3f;
    private float squatScale = 0.5f;
    private float gravity = -9.81f;
    private Camera not_camera;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        not_camera = GetComponentInChildren<Camera>();
        charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {   
        Cursor.visible = false;
        HandleLook();
        HandleMove();
        HandleSprint();
        HandleSquat();
    }

    private void HandleLook()
    {

        
        if (Math.Abs(not_camera.transform.rotation.eulerAngles.x - Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y") - 180)  > 90) 
        {
            not_camera.transform.Rotate(-Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse Y"), 0, 0);
        }
        transform.Rotate(0, Time.deltaTime * cameraSpeed * Input.GetAxis("Mouse X"), 0);
    }
    private void HandleMove()
    {       
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charController.Move(move * playerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime);

    }
    private void HandleSquat()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale -= Vector3.up * squatScale;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale += Vector3.up * squatScale;
        }
    }
    private void HandleSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           playerSpeed /= 2;
        }
    }

}
