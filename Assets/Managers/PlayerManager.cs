using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //This script is based on THIRD PERSON MOVEMENT in Unity - https://www.youtube.com/watch?v=4HpC--2iowE
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 10f, rotationTime = 0.2f;
    private float horizontalInput, verticalInput, rotationSmoothVelocity;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Acquiring input based on arrow key inputs
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized; //Normalized so player isn't fast when moving diagonal

        if(direction.magnitude >= 0.1f){
            applyRotation();
            applyMove();
        }
    }

    private void applyRotation(){
        float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; //Atan2 is a function that returns the angle between x-axis and the vector starting at zero, terminating at x, z. x is the input first because we are rotating from 0 degrees. Atanf returns radian value hence * Mathf.Rad2Deg
        float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationSmoothVelocity, rotationTime); //To smooth the rotation of the character
        transform.rotation = Quaternion.Euler(0f, rotation, 0f); //Rotating Player based on input
    }

    private void applyMove(){
        controller.Move(direction * moveSpeed * Time.deltaTime); //Multiplying by Time.deltaTime makes it frame rate independent
    }
}
