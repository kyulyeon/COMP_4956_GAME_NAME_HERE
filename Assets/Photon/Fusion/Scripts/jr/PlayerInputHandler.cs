using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles the player inputs
public class PlayerInputHandler : MonoBehaviour
{

    //Components
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        playerController.SetInputVector(inputVector);
    }
}
