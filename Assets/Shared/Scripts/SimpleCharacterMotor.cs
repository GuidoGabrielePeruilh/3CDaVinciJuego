using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SimpleCharacterMotor : MonoBehaviour
{
    public CursorLockMode cursorLockMode = CursorLockMode.Locked;
    public bool cursorVisible = false;
    [Header("Movement")]
    public float walkSpeed = 2;
    public float runSpeed = 4;
    public float gravity = 9.8f;
    [Space]
    [Header("Look")]
    public Transform cameraPivot;
    public float lookSpeed = 45;
    public bool invertY = true;
    [Space]
    [Header("Smoothing")]
    public float movementAcceleration = 1;

    CharacterController controller;
    Vector3 movement, finalMovement;
    float speed;
    Quaternion targetRotation, targetPivotRotation;
    float xMove;
    float zMove;
    float xLook;
    float yLook;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = cursorLockMode;
        Cursor.visible = cursorVisible;
        targetRotation = targetPivotRotation = Quaternion.identity;
    }

    void Update()
    {
        UpdateTranslation();
        UpdateLookRotation();
    }

    void UpdateLookRotation()
    {
        yLook *= invertY ? -1 : 1;
        targetRotation = transform.localRotation * Quaternion.AngleAxis(xLook * lookSpeed * Time.deltaTime, Vector3.up);
        targetPivotRotation = cameraPivot.localRotation * Quaternion.AngleAxis(yLook * lookSpeed * Time.deltaTime, Vector3.right);

        transform.localRotation = targetRotation;
        cameraPivot.localRotation = targetPivotRotation;
    }

    void UpdateTranslation()
    {
        if (controller.isGrounded)
        {
            var run = Input.GetKey(KeyCode.LeftShift);

            var translation = new Vector3(xMove, 0, zMove);
            speed = run ? runSpeed : walkSpeed;
            movement = transform.TransformDirection(translation * speed);
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
        finalMovement = Vector3.Lerp(finalMovement, movement, Time.deltaTime * movementAcceleration);
        controller.Move(finalMovement * Time.deltaTime);
    }

    public void UpdateInputMove(InputAction.CallbackContext context)
    {
        var readValue = context.ReadValue<Vector2>();
        xMove = readValue.x;
        zMove = readValue.y;
    }

    public void UpdateInputLook(InputAction.CallbackContext context)
    {
        var readValue = context.ReadValue<Vector2>();
        xLook = readValue.x;
        yLook = readValue.y;
    }
}
