using TMPro;
using UnityEngine;
public class contador_fpss : MonoBehaviour
{
    // Variável de texto_fps (arraste no Inspector)
    public TextMeshProUGUI texto_fps;

    void Start()
    {
        // Chama a função a cada 1 segundo
        InvokeRepeating(nameof(CalcularFPS), 0f, 1f);
    }

    void CalcularFPS()
    {
        // Calcula o FPS (1 dividido pelo tempo entre frames)
        float fps = 1f / Time.deltaTime;
        // Atualiza o texto_fps com 2 casas decimais
        texto_fps.text = "FPS: " + fps.ToString("00");
        // Define cor baseada no FPS
        if (fps < 10)
        {
            texto_fps.color = Color.red;
        }
        else if (fps < 30)
        {
            texto_fps.color = Color.yellow;
        }
        else
        {
            texto_fps.color = Color.green;
        }
    }
}