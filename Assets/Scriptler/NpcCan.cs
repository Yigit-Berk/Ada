using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // NPC'yi yok etme işlemi
        Destroy(gameObject);
    }
}
