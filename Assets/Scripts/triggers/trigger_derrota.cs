using UnityEngine;

public class trigger_derrota : MonoBehaviour
{
    public GameObject jogador, img_derrota;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            img_derrota.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
