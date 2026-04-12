using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger_derrota : MonoBehaviour
{
    public GameObject jogador, img_derrota;

    private bool perdeu = false;
    private float tempo_derrota = 3f;

    private void Update()
    {
        if (perdeu)
        {
            tempo_derrota -= Time.unscaledDeltaTime;
            if (tempo_derrota <= 0f)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("main_menu");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !perdeu)
        {
            img_derrota.SetActive(true);
            Time.timeScale = 0.0f;
            perdeu = true;
        }
    }
}
