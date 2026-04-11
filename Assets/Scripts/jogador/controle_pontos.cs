using UnityEngine;
using TMPro;

public class controle_pontos : MonoBehaviour{
    int pontos;
    public int total_pontos, pontos_secao_01;
    public TextMeshProUGUI pontos_txt;

    public GameObject vitoria_img, parede_invisivel;

    void Start()
    {
        pontos = 0;
        GameObject[] coletaveis = GameObject.FindGameObjectsWithTag("coletavel");
        total_pontos = coletaveis.Length;
        vitoria_img.SetActive(false);
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("coletavel"))
        {
            objetoColidido.gameObject.SetActive(false);
            pontos++;
            pontos_txt.text = "pontos: " + pontos.ToString();

            if (pontos >= pontos_secao_01 && parede_invisivel != null)
                parede_invisivel.SetActive(false);

            if (pontos >= total_pontos)
                vitoria();
        }
    }

    void vitoria()
    {
        vitoria_img.SetActive(true);
        Time.timeScale = 0.0f;
    }
}