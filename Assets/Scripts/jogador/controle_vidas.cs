using UnityEngine;
using UnityEngine.SceneManagement;

public class controle_vidas : MonoBehaviour
{
    public int total_vidas = 3;
    private int vidas_atuais;
    public GameObject[] coracoes;

    public GameObject derrota_img;
    
    public float tempo_invencivel = 1.5f;
    private float timer_invencivel = 0f;
    private bool invencivel = false;

    private bool perdeu = false;
    private float tempo_derrota = 3f;

    void Start()
    {
        vidas_atuais = total_vidas;
        AtualizarCoracoes();
    }

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
            return;
        }

        if (invencivel)
        {
            timer_invencivel -= Time.deltaTime;
            if (timer_invencivel <= 0f)
                invencivel = false;
        }
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("inimigo") && !invencivel)
        {
            vidas_atuais--;
            AtualizarCoracoes();

            invencivel = true;
            timer_invencivel = tempo_invencivel;

            if (vidas_atuais <= 0)
                derrota();
        }
    }

    void AtualizarCoracoes()
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            if (i < vidas_atuais)
            {
                coracoes[i].SetActive(true);
            } else
            {
                coracoes[i].SetActive(false);
            }
            
        }
    }

    void derrota()
    {
        if (perdeu)
            return;

        derrota_img.SetActive(true);
        Time.timeScale = 0.0f;
        perdeu = true;
    }
}