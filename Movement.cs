using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float crouchHeight = 1f; // New variable for crouch height
    public float timeToCrouch = 0.5f; // Time taken to crouch
    public float timeToStand = 0.2f; // Time taken to stand up

    public Transform playerCamera; // Reference to the player's camera
    private float originalHeight; // Original height of the player controller
    public Transform groundCheck;
    public float groundDistance = 0.4f; // Make sure this is declared
    public LayerMask groundMask; // Make sure this is declared

    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching = false;

    void Start()
    {
        originalHeight = controller.height; // Store the original height
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(controller.transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Apply crouching
        HandleCrouch();

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // Assuming Left Control for crouch, change as needed
        {
            if (!isCrouching)
            {
                StartCoroutine(CrouchStand(true, crouchHeight, timeToCrouch));
            }
            else
            {
                StartCoroutine(CrouchStand(false, originalHeight, timeToStand));
            }
        }
    }

    IEnumerator CrouchStand(bool crouch, float targetHeight, float time)
    {
        float startTime = Time.time;
        float initialHeight = controller.height;

        while (Time.time < startTime + time)
        {
            controller.height = Mathf.Lerp(initialHeight, targetHeight, (Time.time - startTime) / time);
            playerCamera.position = new Vector3(playerCamera.position.x, controller.transform.position.y + controller.height / 2f, playerCamera.position.z);
            yield return null;
        }

        controller.height = targetHeight;
        playerCamera.position = new Vector3(playerCamera.position.x, controller.transform.position.y + controller.height / 2f, playerCamera.position.z);

        isCrouching = crouch;
    }
}