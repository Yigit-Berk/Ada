using UnityEngine;

public class CanIksiri : MonoBehaviour
{
    public int healAmount = 30; // Can iksirinin iyileştirme miktarı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canbari_kod playerHealth = collision.GetComponent<canbari_kod>();
            if (playerHealth != null)
            {
               // playerHealth.Heal(healAmount);
                Debug.Log("Can iksiri toplandı, can arttı: " + healAmount);
                Destroy(gameObject); // Can iksirini yok et
            }
        }
    }
}