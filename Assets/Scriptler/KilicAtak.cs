using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 100; // Kılıcın vereceği hasar miktarı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            NPCHealth npcHealth = other.GetComponent<NPCHealth>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage(damage);
            }
        }
    }
}