using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform weaponHolder;
    public float weaponDistance = 0.5f;

    public GameObject pistolPrefab;
    private GameObject currentPistol;
    public GameObject currentPickup;

    private int activeSlot = 1;

    private void Start()
    {
        currentPistol = Instantiate(pistolPrefab);
        currentPistol.transform.SetParent(weaponHolder, false);
        currentPistol.transform.localPosition = Vector3.zero;
        currentPistol.transform.localRotation = Quaternion.identity;
        ActiveSlot(1);
    }

    private void Update()
    {
        HandleWeaponRotation();

        Weapon weaponScript = GetActiveWeapon().GetComponent<Weapon>();

        if (weaponScript != null && !weaponScript.IsReloading())
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                    ActiveSlot(1);
                }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (currentPickup != null)
                    {
                        ActiveSlot(2);
                    }
                }
        }

        if (Input.GetButton("Fire1"))
        {
            weaponScript.Shoot();
        }
    }

    void HandleWeaponRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = (mousePos - weaponHolder.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        weaponHolder.rotation = Quaternion.Euler(0, 0, angle);

        weaponHolder.position = transform.position + direction * weaponDistance;
    }

    void ActiveSlot(int slot)
    {
        activeSlot = slot;
        if (currentPistol != null) currentPistol.SetActive(slot == 1);
        if (currentPickup != null) currentPickup.SetActive(slot == 2);
    }

    public void EquipPickupWeapon(GameObject weaponPrefab, int startingAmmo)
    {
        if (currentPickup != null)
        {
            Destroy(currentPickup);
        }

        currentPickup = Instantiate(weaponPrefab);
        currentPickup.transform.SetParent(weaponHolder, false); // false = keep local position
        currentPickup.transform.localPosition = Vector3.zero;
        currentPickup.transform.localRotation = Quaternion.identity;

        Weapon weaponScript = currentPickup.GetComponent<Weapon>();
        if (weaponScript != null)
        {
            weaponScript.SetTotalAmmo(startingAmmo);
        }

        currentPickup.SetActive(false);
    }

    public GameObject GetActiveWeapon()
    {
        return activeSlot == 1 ? currentPistol : currentPickup;
    }
}
