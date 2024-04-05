using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Transform gunTransform;
    public float  moveSpeed = 2f;

    public Sprite sideSprite;

    public Sprite topSprite;

    private Rigidbody2D body;

    private SpriteRenderer spriteRenderer;
    private Master controls;
    private Vector2 moveInput;

    private Vector2 aimInput;

    // Start is called before the first frame update

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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


    void Update(){
        Shoot();
        Aim();
        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
       if(moveInput.sqrMagnitude > 0.1f)
       {
            if(Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y)){
                spriteRenderer.sprite = sideSprite;
                spriteRenderer.flipX = moveInput.x < 0;
                spriteRenderer.flipY = false;
            }
            else{
                spriteRenderer.sprite = topSprite;
                spriteRenderer.flipY = moveInput.y < 0;
                spriteRenderer.flipX = false;
            }
       }

    }

    private void Aim()
    {
        aimInput = controls.player.Aim.ReadValue<Vector2>();
        if(aimInput.sqrMagnitude > 0.1){
            Vector2 aimDirection = Vector2.zero;
            if(UsingMouse())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                aimDirection = mousePosition - gunTransform.position;
            }
            else{
                aimDirection = aimInput;
            }

            float angle = Mathf.Atan2(aimDirection.x,-aimDirection.y) * Mathf.Rad2Deg;
            gunTransform.rotation = Quaternion.Euler(0,0, angle);
        }
    }

    private bool UsingMouse(){
        if(Mouse.current.delta.ReadValue().sqrMagnitude > 0.1){
            return true;
        }
        return false;
    }
    private void Shoot()
    {
        if(controls.player.Fire.triggered){
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            if (bullet == null){
                return;
            }
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }
}
