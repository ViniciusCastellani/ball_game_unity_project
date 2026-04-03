using UnityEngine;

public class controle_vidas : MonoBehaviour
{
    public int total_vidas = 3;
    private int vidas_atuais;
    public GameObject[] coracoes;
    public GameObject txt_derrota;

    void Start()
    {
        vidas_atuais = total_vidas;
        AtualizarCoracoes();
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("inimigo"))
        {
            vidas_atuais--;
            AtualizarCoracoes();

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