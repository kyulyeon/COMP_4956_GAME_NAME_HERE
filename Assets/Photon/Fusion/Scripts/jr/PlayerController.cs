using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [Header("Player settings")]
    public float gravity = -10.0f;
    //public float jumpImpulse = 8.0f;
    public float accelerationFactor = 10.0f;
    public float turnFactor = 3.5f;
    //public float maxSpeed = 2.0f;
    //public float rotationSpeed = 1.0f;
    float acclerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    [Networked]
    [HideInInspector]
    public bool IsGrounded { get; set; }

    [Networked]
    [HideInInspector]
    public Vector3 Velocity { get; set; }

    //Components
    Rigidbody2D playerRigidBody;

    //Awake() is called when script loads
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Frame rate independent for physics calculations on network
    public override void FixedUpdateNetwork()
    {
        ApplyGravityForce();
        ApplySteering();
    }

    void ApplyGravityForce()
    {
        //create force for player
        Vector2 playerVectorForce = transform.up * accelerationFactor * acclerationInput;

        //apply force that pushes player
        playerRigidBody.AddForce(playerVectorForce, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        //update rotation angle 
        rotationAngle -= steeringInput * turnFactor;
        //Apply steering by rotating player object
        playerRigidBody.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        acclerationInput = inputVector.y;
    }

    //public virtual void Jump()
    //{
    //    var newVel = Velocity;
    //    newVel.y += jumpImpulse;
    //    Velocity = newVel;
    //}

    public virtual void Move(Vector3 direction)
    {
        //var deltaTime = Runner.DeltaTime;
        //var previousPos = transform.position;
        //var moveVelocity = Velocity;

        //direction = direction.normalized;

        //if (IsGrounded && moveVelocity.y < 0)
        //{
        //    moveVelocity.y = 0f;
        //}

        //moveVelocity.y += gravity * Runner.DeltaTime;

        //var horizontalVel = default(Vector3);
        //horizontalVel.x = moveVelocity.x;
        //horizontalVel.z = moveVelocity.z;

        //if (direction == default)
        //{
        //    horizontalVel = Vector3.Lerp(horizontalVel, default, braking * deltaTime);
        //}
        //else
        //{
        //    horizontalVel = Vector3.ClampMagnitude(horizontalVel + direction * acceleration * deltaTime, maxSpeed);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Runner.DeltaTime);
        //}

        //moveVelocity.x = horizontalVel.x;
        //moveVelocity.z = horizontalVel.z;

        //Controller.Move(moveVelocity * deltaTime);

        //Velocity = (transform.position - previousPos) * Runner.Simulation.Config.TickRate;
        //IsGrounded = Controller.isGrounded;
    }
}
