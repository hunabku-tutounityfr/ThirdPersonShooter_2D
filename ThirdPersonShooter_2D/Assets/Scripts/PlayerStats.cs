using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    void Start ()
    {
        isDead = false;
        health = maxHealth;
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
    public bool isDead = false;
}
