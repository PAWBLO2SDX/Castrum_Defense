using System.Collections;
using UnityEngine;

public class RedFlash : MonoBehaviour
{
    public SpriteRenderer sprite;

        private void Awake()
    {
        if (sprite == null)
            sprite = GetComponentInChildren<SpriteRenderer>();

        if (sprite == null)
            Debug.LogWarning($"[{nameof(RedFlash)}] No SpriteRenderer assigned or found on '{gameObject.name}'.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleBulletCollision(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleBulletCollision(collision.gameObject);
    }

    private void HandleBulletCollision(GameObject other)
    {
        if (other == null) return;

        if (!other.CompareTag("Bullet")) return;

        // Optional: debug to confirm the event fires
        Debug.Log($"[{nameof(RedFlash)}] Hit by Bullet on '{gameObject.name}'");

        StartCoroutine(FlashRed());
    }

    public IEnumerator FlashRed()
    {
        if (sprite == null) yield break;

        var original = sprite.color;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = original;
    }
}
