using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour 
 {
    public float damage;
    public float maxHealth = 100;
    public float timeBeforeRegenStarts = 3;
    public float healthValueIncrement = 1;
    public float healthTimeIncrement = 0.1f;
    public float currentHealth;
    public Transform respawnPoint;

    public KeyCode fKey = KeyCode.F;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(fKey))
        {
            KillPlayer();
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            KillPlayer();
            this.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
        else
            StopCoroutine("RegeneratingHealth");

    }

    private void KillPlayer()
    {
        currentHealth = 0;

        this.transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();

        StopCoroutine("RegeneratingHealth");

        print("DEAD");
    }

    IEnumerator RegeneratingHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(healthTimeIncrement);

        while (currentHealth < maxHealth)
        {
            currentHealth += healthValueIncrement;

            if (currentHealth > maxHealth)
            currentHealth = maxHealth;

            yield return timeToWait;
        }

    }

 
}

    