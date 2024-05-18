using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //This script is based on "THIRD PERSON MOVEMENT in Unity": https://www.youtube.com/watch?v=4HpC--2iowE and "FIRST PERSON MOVEMENT in Unity - FPS Controller": https://www.youtube.com/watch?v=_QajrabyTJc
    public static PlayerManager instance;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 10f, gravityForce = -15f, jumpSpeed = 4f, rotationTime = 0.2f, groundCheckRadius = 0.4f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private float horizontalInput, verticalInput, rotationSmoothVelocity;
    private Vector3 direction, yDirection;
    private bool isGrounded;

    void Awake(){
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    void Start(){
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask); //Project a sphere at groundCheck.position of radius groundCheckRadius, and see if colliding with groundMask
        if(isGrounded == true && yDirection.y < 0f){  //Constantly force player downwards so they may always touch the ground
            yDirection.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded == true){ //Player Jump
            yDirection.y = Mathf.Sqrt(jumpSpeed * -2f * gravityForce);
        }
        yDirection.y += gravityForce * Time.deltaTime; //Applying Gravity
        controller.Move(yDirection * Time.deltaTime);

        horizontalInput = Input.GetAxisRaw("Horizontal"); //Acquiring input based on arrow key inputs
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized; //Normalized so player isn't fast when moving diagonal

        if(direction.magnitude >= 0.1f){
            float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; //Atan2 is a function that returns the angle between x-axis and the vector starting at zero, terminating at x, z. x is the input first because we are rotating from 0 degrees. Atanf returns radian value hence * Mathf.Rad2Deg
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationSmoothVelocity, rotationTime); //To smooth the rotation of the character
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); //Rotating Player based on input

            controller.Move(direction * moveSpeed * Time.deltaTime); //Moving Player; Multiplying by Time.deltaTime makes it frame rate independent
        }
    }
}
