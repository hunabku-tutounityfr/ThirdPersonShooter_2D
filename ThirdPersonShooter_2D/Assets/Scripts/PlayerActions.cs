using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStates), typeof(PlayerStats))]
public class PlayerActions : MonoBehaviour
{
    void Awake ()
    {
        states = GetComponent<PlayerStates>();
        stats = GetComponent<PlayerStats>();
    }

    void Update ()
    {
        if (stats.isDead) return;
        
        // Move
        float vertivalMoveInput = Input.GetAxis("Vertical");
        float horizontalMoveInput = Input.GetAxis("Horizontal");

        transform.position += transform.right * vertivalMoveInput * moveSpeed * Time.deltaTime;
        transform.position += -transform.up * horizontalMoveInput * straffeSpeed * Time.deltaTime;


        // Rotation
        float rotationInput = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0f, 0f, -rotationInput * rotationSpeed));


        // Shoot
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && states.weaponEquipied && bullet != null && bulletStart != null && states.weaponAmmoAmount > 0 && !states.isReloading)
        {
            GameObject bullet_Clone = Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            StartCoroutine(ShootDelaying());
            states.weaponAmmoAmount--;
        }

        // Reload
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(1)) && states.weaponEquipied && !states.isReloading)
        {
            StartCoroutine(Reloading());
        }
    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            stats.Damage(collision.gameObject.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject.gameObject);
        }
    }

    IEnumerator ShootDelaying ()
    {
        canShoot = false;
        yield return new WaitForSeconds(states.weaponBulletDelay);
        canShoot = true;
    }

    IEnumerator Reloading ()
    {
        states.isReloading = true;
        states.ChangeStatus("reload");
        yield return new WaitForSeconds(states.weaponReloadDelay);
        states.isReloading = false;
        states.ChangeStatus("gun");
    }

    [Header("--- Movement ---")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float straffeSpeed = 2f;

    [Header("--- Rotation ---")]
    [SerializeField] float rotationSpeed = 6f;

    [Header("--- Shoot ---")]
    [SerializeField] GameObject bullet = null;
    [SerializeField] Transform bulletStart = null;
    [SerializeField] bool canShoot = false;

    [Header("--- Components ---")]
    PlayerStates states = null;
    PlayerStats stats = null;
}
