using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float groundDrag = 6f;
    private Rigidbody rb;
    private Camera mainCamera;

    [HideInInspector] public Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevent player from tilting when jumping
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        // Get the direction the camera is facing
        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

        // Calculate the movement direction based on the camera's facing direction
        movement = cameraForward * Input.GetAxis("Vertical") + mainCamera.transform.right * Input.GetAxis("Horizontal");
        movement = movement.normalized * speed;

        // Apply the movement to the player's rigidbody using AddForce
        rb.AddForce(movement, ForceMode.VelocityChange);

        // Add ground drag to the player's movement
        if (IsGrounded())
        {
            Vector3 groundVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(-groundVelocity * groundDrag, ForceMode.Acceleration);
        }
    }

    bool IsGrounded()
    {
        // Check if the player is touching the ground using a raycast
        float distanceToGround = GetComponent<Collider>().bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
    }
}