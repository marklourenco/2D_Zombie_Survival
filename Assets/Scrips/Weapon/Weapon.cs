using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    private GameObject foundFirePoint;
    private SpriteRenderer spriteRenderer;

    [Header("Ammo Settings")]
    public int maxClipAmmo = 10; // bullets per reload
    public int totalAmmo = 100; // total reserve ammo
    public bool infiniteAmmo = false; // for pistol

    private int currentClipAmmo;
    private float lastFireTime;

    [Header("Timing")]
    public float fireRate = 0.5f;
    public float reloadTime = 2.0f;
    private bool isReloading = false;

    public bool isEquipped = false;
    private bool flip;

    private void Start()
    {
        currentClipAmmo = maxClipAmmo;

        foundFirePoint = GameObject.Find("FirePoint");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isEquipped)
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            flip = mouseScreenPos.x < Screen.width / 2;

            spriteRenderer.flipY = flip;
        }
    }

    public void Shoot()
    {
        Debug.Log($"Ammo: {currentClipAmmo}");

        if (isReloading) return;

        firePoint = foundFirePoint.transform;

        if (infiniteAmmo == false && totalAmmo <= 0 && currentClipAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= lastFireTime + fireRate)
        {
            if (currentClipAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 shootDir = (mousePos - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<WeaponBullet>().SetDirection(shootDir);

            currentClipAmmo--;
            lastFireTime = Time.time;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        if (!infiniteAmmo)
        {
            int neededBullets = maxClipAmmo - currentClipAmmo;
            int bulletsToReload = Mathf.Min(neededBullets, totalAmmo);

            currentClipAmmo += bulletsToReload;
            totalAmmo -= bulletsToReload;
        }
        else
        {
            currentClipAmmo = maxClipAmmo;
        }

        isReloading = false;
    }

    public void SetTotalAmmo(int amount)
    {
        totalAmmo = amount;
        currentClipAmmo = Mathf.Min(maxClipAmmo, totalAmmo);
        totalAmmo -= currentClipAmmo;
    }

    public int GetTotalAmmo() => infiniteAmmo ? -1 : totalAmmo;
    public int GetClipAmmo() => currentClipAmmo;

    public bool IsReloading() => isReloading;
}
