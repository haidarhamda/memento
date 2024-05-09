using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float maxSpeed = 5f;
    public float CurrentSpeed { get; private set; } = 0;
    [SerializeField] private float timeToAccelerate = 0.2f;
    private float acceleration;
    [SerializeField] private float timeToDecelerate = 0.12f;
    private float deceleration;
    private Vector3 move;
    private Vector3 previousMove;
    private Vector3 bufferMove;
    private const int LEFT = -1;
    private const int RIGHT = 1;
    private int lookDirection;
    [SerializeField] public Animator animator;

    private Camera mainCamera;

    private void Awake()
    {
        lookDirection = transform.rotation.y == 0 ? RIGHT : LEFT;
        acceleration = maxSpeed / timeToAccelerate;
        deceleration = maxSpeed / timeToDecelerate;

        animator = GetComponent<Animator>();

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerInput.MoveInput;
        previousMove = move;
        move = new(moveInput.x, moveInput.y, 0);

        if (previousMove.magnitude > 0 && move.magnitude == 0)
        {
            bufferMove = previousMove;
        }

        if (Mathf.Sign(move.x) != lookDirection && move.x != 0)
        {
            lookDirection = (int)Mathf.Sign(move.x);

            int yRot = lookDirection == 1 ? 0 : 180;
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        CurrentSpeed += acceleration * Time.deltaTime;

        float leftBoundary = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightBoundary = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0, maxSpeed);

        Vector3 appliedMove = move.normalized * CurrentSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + appliedMove;
        newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary + transform.localScale.x / 2, rightBoundary - transform.localScale.x / 2);
        if (bufferMove ==newPosition)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        transform.position = newPosition;

        move = newPosition;

    }
}
