using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    private GameObject foundFirePoint;
    public int ammo = 10;
    private int currentAmmo;
    public float fireRate = 0.5f;
    private float lastFireTime;
    public float reloadTime = 2.0f;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = ammo;

        foundFirePoint = GameObject.Find("FirePoint");
    }

    private void Update()
    {


        // && = AND
        // || = OR
    }

    public void Shoot()
    {
        firePoint = foundFirePoint.transform;

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= lastFireTime + fireRate)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 shootDir = (mousePos - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            bullet.GetComponent<WeaponBullet>().SetDirection(shootDir);

            currentAmmo--;
            lastFireTime = Time.time;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = ammo;
        isReloading = false;
    }
}
