using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer = true;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;
    PlayerInput playerInput;
    Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        animator.SetBool("grounded", groundedPlayer);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = playerInput.actions["Move"].ReadValue<Vector2>();
        move.z = move.y;
        move.y = 0f;
        animator.SetFloat("Speed", move.magnitude);
        move *= 2;
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            Debug.Log("jumped");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetTrigger("Jump");
            groundedPlayer = false;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundedPlayer = true;
        }
    }
    
}
