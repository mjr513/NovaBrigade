using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerTest : MonoBehaviour
{
    //Author: Alina Ponomareva
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        _animator.SetFloat("Speed", vertical);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _animator.SetBool("Aiming", true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _animator.SetBool("Aiming", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetBool("Reloading", true);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _animator.SetBool("Reloading", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool("IsWalkingLeft", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("IsWalkingLeft", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("IsWalkingBack", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("IsWalkingBack", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("IsWalkingRight", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("IsWalkingRight", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _animator.SetBool("Crouch", true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            _animator.SetBool("Crouch", false);
        }

    }
}
