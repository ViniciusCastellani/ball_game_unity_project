using UnityEngine;

public class player_controle : MonoBehaviour
{
    private Rigidbody rb;
    
    private float horizontal, vertical;
    public float velocidade = 0;
    public float velocidadeRotacaoBola = 2500f;

    public GameObject modeloSonic;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Walk();

        if (modeloSonic != null)
        {
            Vector3 velocidadeReal = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

            if (velocidadeReal.magnitude > 0.1f)
            {
                Vector3 eixoRotacao = new Vector3(velocidadeReal.z, 0, -velocidadeReal.x);
                float intensidade = velocidadeReal.magnitude / velocidade * velocidadeRotacaoBola;
                modeloSonic.transform.Rotate(eixoRotacao * intensidade * Time.deltaTime, Space.World);
            }
        }
    }

    void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontal, 0, vertical);
        rb.AddForce(direcao * velocidade);
    }
}