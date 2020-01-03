using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyStates), typeof(EnemyStats))]
public class EnemyActions : MonoBehaviour
{
    void Awake ()
    {
        states = GetComponent<EnemyStates>();
        stats = GetComponent<EnemyStats>();
    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(ShootDelaying());
    }

    void Update ()
    {
        if (stats.isDead) return;
        
        if (player == null)
        {
            canShoot = false;
            return;
        }
        
        // Look at Player
        float angle = 0;
         
        Vector3 relative = transform.InverseTransformPoint(player.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0f, 0f, -angle + 90f);


        // Follow Player
        if (Vector3.Distance(transform.position, player.position) >= stopDistance)
        {
            Vector3 dir = player.position - transform.position;
            
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }


        // Shoot
        if (canShoot && states.weaponEquipied && bullet != null && bulletStart != null && states.weaponAmmoAmount > 0 && !states.isReloading)
        {
            GameObject bullet_Clone = Instantiate(bullet, bulletStart.position, bulletStart.rotation);
            StartCoroutine(ShootDelaying());
            states.weaponAmmoAmount--;
        }

        // Reload
        if (states.weaponAmmoAmount <= 0 && states.weaponEquipied && !states.isReloading)
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
        yield return new WaitForSeconds(stats.brainDelay);
        states.isReloading = true;
        states.ChangeStatus("reload");
        yield return new WaitForSeconds(states.weaponReloadDelay);
        states.isReloading = false;
        states.ChangeStatus("gun");
    }

    [Header("--- Movement ---")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float stopDistance = 1f;

    [Header("--- Shoot ---")]
    [SerializeField] GameObject bullet = null;
    [SerializeField] Transform bulletStart = null;
    [SerializeField] bool canShoot = false;

    [Header("--- Components ---")]
    EnemyStates states = null;
    EnemyStats stats = null;
    Transform player = null;
}
