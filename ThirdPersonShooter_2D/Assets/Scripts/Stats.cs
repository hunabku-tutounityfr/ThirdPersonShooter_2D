using UnityEngine;

public class Stats : MonoBehaviour
{
    void Start ()
    {
        isDead = false;
        health = maxHealth;
    }
    void Update ()
    {
        // Damage test
        if (Input.GetKeyDown(KeyCode.P))
        {
            Damage(10f);
        }
    }

    public void Damage (float amount)
    {
        if (health <= 0) isDead = true;
        if (isDead) return;
        
        if (health > 0)
        {
            health -= amount;
            healthBar_Bar_Transform.localScale = new Vector3(health / maxHealth, 1f);
        }
        
    }

    [Header("--- Stats ---")]
    [SerializeField] float health = 0f;
    [SerializeField] float maxHealth = 100f;
    [Space]
    [SerializeField] Transform healthBar_Bar_Transform = null;

    [Header("--- Status ---")]
    [SerializeField] bool isDead = false;
}
