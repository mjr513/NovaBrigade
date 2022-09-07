using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("IsWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("IsWalking", false);
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetBool("IsRolling", true);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _animator.SetBool("IsRolling", false);
        }
    }
}
