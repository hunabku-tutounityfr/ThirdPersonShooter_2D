using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerStates : MonoBehaviour
{
    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start ()
    {
        ChangeStatus("gun");
        weaponAmmoAmount = weaponMagazineAmmo;
    }

    public void ChangeStatus (string newStatus)
    {
        switch (newStatus.ToLower())
        {
            case "stand":
                weaponEquipied = false;
                isReloading = false;
                spriteRenderer.sprite = stand_Sprite;
                break;
            case "gun":
                weaponEquipied = true;
                isReloading = false;
                spriteRenderer.sprite = gun_Sprite;
                break;
            case "reload":
                weaponEquipied = true;
                isReloading = true;
                spriteRenderer.sprite = reload_Sprite;
                weaponAmmoAmount = weaponMagazineAmmo;
                break;
        }
    }

    [Header("--- Sprites ---")]
    [SerializeField] Sprite reload_Sprite = null;
    [SerializeField] Sprite stand_Sprite = null;
    [SerializeField] Sprite gun_Sprite = null;

    [Header("--- Weapon ---")]
    public float weaponBulletDelay = 1f;
    public float weaponDamage = 15f;
    public int weaponMagazineAmmo = 7;
    public float weaponReloadDelay = 2f;
    public int weaponAmmoAmount = 0;

    [Header("--- Status ---")]
    public bool weaponEquipied = false;
    public bool isReloading = false;

    [Header("--- Components ---")]
    SpriteRenderer spriteRenderer = null;
}
