using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce; 

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerClick;
    public bool allowButtonHold;

    int bulletsLeft;
    int bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke =  true;

    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    public int maxHealth;
    private int currentHealth;

    private Transform ui_healthbar;
    
    void Start()
    {
        currentHealth = maxHealth;

        RegenHealthBar();
    }

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    
    private void Update()
    {
        MyInput();

        if (ammunitionDisplay != null)
        ammunitionDisplay.SetText(bulletsLeft / bulletsPerClick + " / " + magazineSize / bulletsPerClick);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft <=0) Reload();

        if (Input.GetKeyDown(KeyCode.U)) TakeDamage(500);
    }

    private void Shoot()
    {
        readyToShoot = false;

        bulletsLeft--;
        bulletsShot++;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);    
        
        currentBullet.transform.forward =directionWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if(muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    void RegenHealthBar()
    {
        float t_health_ratio = (float)currentHealth / (float)maxHealth;

        //ui_healthbar.localScale = new Vector3(t_health_ratio, 1, 1);
    }

    public void TakeDamage (int p_damage)
    {
        currentHealth -= p_damage;
        RegenHealthBar();
    }
}
