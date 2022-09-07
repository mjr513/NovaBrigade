using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float damage = 15f;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript player = other.GetComponent<HealthScript>();

            if (player != null)
            {
                player.TakeDamage(15f); 
            }

            
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthScript player = other.gameObject.GetComponent<HealthScript>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }


        }

    }





}
