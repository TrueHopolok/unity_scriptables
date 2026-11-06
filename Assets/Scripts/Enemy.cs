using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    int health;
    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Called by the spawner right after Instantiate
    public void Init(EnemyData enemyData)
    {
        data = enemyData;
        health = data.maxHealth;
        GetComponent<SpriteRenderer>().color = data.color;
        transform.localScale = Vector3.one * data.size;
    }

    void FixedUpdate()
    {
        if (data == null) return;
        body.linearVelocity = Vector2.down * data.speed;

        // Despawn when the enemy leaves the screen
        if (transform.position.y < -7f) Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health > 0) return;

        Debug.Log("Score +" + data.scoreValue);
        Destroy(gameObject);
    }
}