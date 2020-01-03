using UnityEngine;

public class States : MonoBehaviour
{
    void Start ()
    {
        ChangeStatus("stand");
    }

    void Update ()
    {
        
    }

    void ChangeStatus (string newStatus)
    {
        switch (newStatus.ToLower())
        {
            case "hold":
                hold_Status = true;
                reload_Status = false;
                stand_Status = false;
                gun_Status = false;
                machine_Status = false;
                silencer_Status = false;
                weaponEquipied = false;
                isReloading = false;
                break;
            case "reload":
                hold_Status = false;
                reload_Status = true;
                stand_Status = false;
                gun_Status = false;
                machine_Status = false;
                silencer_Status = false;
                weaponEquipied = true;
                isReloading = true;
                break;
            case "stand":
                hold_Status = false;
                reload_Status = false;
                stand_Status = true;
                gun_Status = false;
                machine_Status = false;
                silencer_Status = false;
                weaponEquipied = false;
                isReloading = false;
                break;
            case "gun":
                hold_Status = false;
                reload_Status = false;
                stand_Status = false;
                gun_Status = true;
                machine_Status = false;
                silencer_Status = false;
                weaponEquipied = true;
                isReloading = false;
                break;
            case "machine":
                hold_Status = false;
                reload_Status = false;
                stand_Status = false;
                gun_Status = false;
                machine_Status = true;
                silencer_Status = false;
                weaponEquipied = true;
                isReloading = false;
                break;
            case "silencer":
                hold_Status = false;
                reload_Status = false;
                stand_Status = false;
                gun_Status = false;
                machine_Status = false;
                silencer_Status = true;
                weaponEquipied = true;
                isReloading = false;
                break;
        }
    }

    [Header("--- Sprites ---")]
    [SerializeField] Sprite hold_Sprite = null;
    [SerializeField] Sprite reload_Sprite = null;
    [SerializeField] Sprite stand_Sprite = null;
    [Space]
    [SerializeField] Sprite gun_Sprite = null;
    [SerializeField] Sprite machine_Sprite = null;
    [SerializeField] Sprite silencer_Sprite = null;

    [Header("--- Status ---")]
    [SerializeField] bool hold_Status = false;
    [SerializeField] bool reload_Status = false;
    [SerializeField] bool stand_Status = false;
    [Space]
    [SerializeField] bool gun_Status = false;
    [SerializeField] bool machine_Status = false;
    [SerializeField] bool silencer_Status = false;
    [Space]
    public bool weaponEquipied = false;
    public bool isReloading = false;
}
