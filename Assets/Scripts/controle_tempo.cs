using TMPro;
using UnityEngine;

public class controle_tempo : MonoBehaviour
{
    public float tempo_total = 150f;
    public float tempo_alerta = 60f;
    private float tempo_atual;

    private int segundos_atuais;
    private int minutos_atuais;

    public TextMeshProUGUI txt_tempo;
    public GameObject txt_derrota;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempo_atual = tempo_total;   
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo_atual > 0f)
        {
            tempo_atual -= Time.deltaTime;

            if (tempo_atual <= tempo_alerta)
            {
                txt_tempo.color = Color.red;
            }

            minutos_atuais = Mathf.FloorToInt(tempo_atual / 60f);
            segundos_atuais = Mathf.FloorToInt(tempo_atual % 60f);
            txt_tempo.text = string.Format("{0:00}:{1:00}", minutos_atuais, segundos_atuais);            
        } else
        {
            txt_tempo.text = "00:00";
            derrota();
        }
    }

    void derrota()
    {
        txt_derrota.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
