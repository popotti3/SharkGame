using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float  moveSpeed = 2f;

    private Rigidbody2D body;
    private Master controls;
    private Vector2 moveInput;
    // Start is called before the first frame update

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        controls = new Master();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {

    }

    
    private void FixedUpdate()
    {
       Move();    
       
    }

    private void Move()
    {
        moveInput = controls.player.Movement.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }
}
