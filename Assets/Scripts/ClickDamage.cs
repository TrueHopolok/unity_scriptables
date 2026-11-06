using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDamage : MonoBehaviour
{
    void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos); // similar to OverlapBox, but for point
        /* 
        Both are the same:
            Enemy enemy = hit.TryGetComponent<Enemy>();
            hit.TryGetComponent<Enemy>(out Enemy enemy);
        */
        if (hit != null && hit.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(1);
        }
    }
}