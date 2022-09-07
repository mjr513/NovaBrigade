using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GunScript gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickupRange;
    public float dropForwardForce, dropUpWardForce;

    public bool equipped;
    public static bool slotfull;
    
    void Start()
    {
        if(!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if(equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true; 
            slotfull = true;
        }
    }

    
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.G) && !slotfull) PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.E)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotfull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;


        rb.isKinematic = true;
        coll.isTrigger = true;

        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotfull = false;


        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpWardForce, ForceMode.Impulse);

        rb.isKinematic = false;
        coll.isTrigger = false;

        gunScript.enabled = false;
    }
}
