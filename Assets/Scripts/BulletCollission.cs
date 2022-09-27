using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollission : MonoBehaviour
{
    public float TimeToLive = 3f;
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
