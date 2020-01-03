using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start ()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update ()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    [Header("--- Move ---")]
    [SerializeField] float moveSpeed = 6f;

    [Header("--- Behaviour ---")]
    [SerializeField] float lifeTime = 4f;
    public float damage = 5f;
}
