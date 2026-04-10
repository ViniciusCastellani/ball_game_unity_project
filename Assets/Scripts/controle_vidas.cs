using UnityEngine;

public class controle_vidas : MonoBehaviour
{
    public int total_vidas = 3;
    private int vidas_atuais;
    public GameObject[] coracoes;
    public GameObject txt_derrota;
    public float tempo_invencivel = 1.5f;
    private float timer_invencivel = 0f;
    private bool invencivel = false;
    
    void Start()
    {
        vidas_atuais = total_vidas;
        AtualizarCoracoes();
    }

    private void Update()
    {
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
        txt_derrota.SetActive(true);
        Time.timeScale = 0.0f;
    }
}