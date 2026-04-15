using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_principal : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("main_scene");
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
