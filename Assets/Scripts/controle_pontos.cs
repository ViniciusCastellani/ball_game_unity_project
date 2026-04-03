using UnityEngine;
using TMPro;

public class controle_pontos : MonoBehaviour{
    int pontos;
    public int total_pontos;
    public int pontos_secao1;

    public TextMeshProUGUI txt_pontos;
    public GameObject txt_vitoria;
    public GameObject parede_invisivel;

    void Start()
    {
        pontos = 0;
        GameObject[] coletaveis = GameObject.FindGameObjectsWithTag("coletavel");
        total_pontos = coletaveis.Length;
        txt_vitoria.SetActive(false);
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("coletavel"))
        {
            objetoColidido.gameObject.SetActive(false);
            pontos++;
            txt_pontos.text = "pontos: " + pontos.ToString();

            if (pontos >= pontos_secao1 && parede_invisivel != null)
                parede_invisivel.SetActive(false);

            if (pontos >= total_pontos)
                vitoria();
        }
    }

    void vitoria()
    {
        txt_vitoria.SetActive(true);
        Time.timeScale = 0.0f;
    }
}