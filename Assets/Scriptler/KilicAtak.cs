using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 25; // Kılıcın vereceği hasar miktarı
    private bool isCheckingCollision = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCheckingCollision && other.CompareTag("NPC"))
        {
            NPCHealth npcHealth = other.GetComponent<NPCHealth>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage(damage);
            }
        }
    }

    // Animasyon olayı tarafından çağrılacak işlev
    public void StartCheckingCollision()
    {
        isCheckingCollision = true;
        Debug.Log("Çarpışma algılama başladı.");
    }

    // Animasyon olayı tarafından çağrılacak işlev
    public void StopCheckingCollision()
    {
        isCheckingCollision = false;
        Debug.Log("Çarpışma algılama durduruldu.");
    }
}