using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform location;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier; 
    bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space; 

    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public float groundDrag;

    private float maxHealth = 100;
    public float timeBeforeRegenStarts = 3;
    private float healthValueIncrement = 1;
    private float healthTimeIncrement = 0.1f;
    private float currentHealth;
    private Coroutine regeneratingHealth;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        currentHealth = maxHealth;
    }

    void Update()
    {
        CharacterInput();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;    

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CharacterInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Movement()
    {
        moveDirection = location.forward * verticalInput + location.right * horizontalInput;

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }       

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void ApplyDamage(float dmg)
    {
        currentHealth -= dmg;
   


        if(currentHealth <= 0 )
            KillPlayer();
        else if (regeneratingHealth != null)
            StopCoroutine(regeneratingHealth);
        
        regeneratingHealth = StartCoroutine(RegenerateHealth());
    }

    private void KillPlayer()
    {
        currentHealth = 0;

        if(regeneratingHealth !=null)
            StopCoroutine(regeneratingHealth);

        print("Dead");    
    }

    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(healthTimeIncrement);

        while(currentHealth < maxHealth)
        {
            currentHealth += healthValueIncrement;

            if(currentHealth > maxHealth)
                currentHealth = maxHealth;


            
            yield return timeToWait;
        }

        regeneratingHealth = null;
    }

    
}
