using TMPro;
using UnityEngine;
public class contador_fpss : MonoBehaviour
{
    // Variável de texto (arraste no Inspector)
    public TextMeshProUGUI texto;
    void Start()
    {
        // Chama a função a cada 1 segundo
        InvokeRepeating(nameof(CalcularFPS), 0f, 1f);
    }
    void CalcularFPS()
    {
        // Calcula o FPS (1 dividido pelo tempo entre frames)
        float fps = 1f / Time.deltaTime;
        // Atualiza o texto com 2 casas decimais
        texto.text = fps.ToString("00") + " FPS";
        // Define cor baseada no FPS
        if (fps < 10)
        {
            texto.color = Color.red;
        }
        else if (fps < 30)
        {
            texto.color = Color.yellow;
        }
        else
        {
            texto.color = Color.green;
        }
    }
}