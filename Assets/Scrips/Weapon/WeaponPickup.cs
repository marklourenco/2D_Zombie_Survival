using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerWeaponHolder holder = collision.GetComponent<PlayerWeaponHolder>();
            if (holder != null)
            {
                holder.EquipWeapon(weaponPrefab);
                Destroy(gameObject);
            }
        }
    }
}

public class PlayerWeaponHolder : MonoBehaviour
{
    public Transform weaponSlot;
    public void EquipWeapon(GameObject weaponPrefab)
    {
        foreach (Transform child in weaponSlot)
        {
            Destroy(child.gameObject);
        }

        Instantiate(weaponPrefab, weaponSlot.position, Quaternion.identity, weaponSlot);
    }
}
