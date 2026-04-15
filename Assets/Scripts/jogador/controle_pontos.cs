using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controle_pontos : MonoBehaviour{
    int pontos;
    public int total_pontos, pontos_secao_01;
    public TextMeshProUGUI pontos_txt;

    public GameObject vitoria_img, parede_invisivel;

    public AudioClip som_vitoria;
    private AudioSource audioSource;

    private bool venceu = false;
    private float tempo_vitoria = 3f;

    void Start()
    {
        pontos = 0;
        GameObject[] coletaveis = GameObject.FindGameObjectsWithTag("coletavel");
        audioSource = GetComponent<AudioSource>();
        total_pontos = coletaveis.Length;
        vitoria_img.SetActive(false);
    }

    private void Update()
    {
        if (venceu)
        {
            tempo_vitoria -= Time.unscaledDeltaTime;
            if (tempo_vitoria <= 0f)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("main_menu");
            }
        }
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
        if (venceu)
            return;

        venceu = true;
        vitoria_img.SetActive(true);

        if (som_vitoria != null && audioSource != null)
        {
            AudioListener.pause = false;
            audioSource.PlayOneShot(som_vitoria);
        }
        
        Time.timeScale = 0.0f;
    }
}