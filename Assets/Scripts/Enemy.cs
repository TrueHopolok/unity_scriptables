using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioSource enemyDeathSFX;
    EnemyData data;
    int health;
    Rigidbody2D body;
    Collider2D collider;
    Renderer renderer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
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

        collider.enabled = false;
        renderer.enabled = false;

        Debug.Log("Score +" + data.scoreValue);
        if (enemyDeathSFX)
        {
            enemyDeathSFX.Play();
            // StartCoroutine(WaitUntilFinishes()); // alternative
            Destroy(gameObject, enemyDeathSFX.clip.length);
        }
        else // audio clip wasnt set
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitUntilFinishes()
    {
        yield return new WaitUntil(() => enemyDeathSFX.isPlaying == false);
        Destroy(gameObject);
        yield return null;
    }
}
