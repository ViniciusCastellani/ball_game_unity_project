using UnityEngine;

public class camera_control : MonoBehaviour
{
    public GameObject jogador;
    public Vector3 distancia; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distancia = transform.position - jogador.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.transform.position + distancia;
    }
}
