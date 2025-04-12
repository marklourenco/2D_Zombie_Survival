using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponHandler handler = collision.GetComponent<WeaponHandler>();
            if (handler != null)
            {
                handler.EquipPickupWeapon(weaponPrefab);
                Destroy(gameObject);
            }
        }
    }
}