using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;
    public int startingAmmo = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponHandler handler = collision.GetComponent<WeaponHandler>();
            if (handler != null && !handler.IsReloading())
            {
                handler.EquipPickupWeapon(weaponPrefab, startingAmmo);
                Destroy(gameObject);
            }
        }
    }
}