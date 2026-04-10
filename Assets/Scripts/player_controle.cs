using UnityEngine;

public class player_controle : MonoBehaviour
{
    public Rigidbody rb;
    public float horizontal;
    public float vertical;
    public float velocidade = 0;
    public GameObject modeloSonic;
    public float velocidadeRotacaoBola = 2500f;

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

        // Normaliza pra diagonal não ser mais rápida
        if (direcao.magnitude > 1f)
            direcao.Normalize();

        // Adapta à inclinação da rampa
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f))
            direcao = Vector3.ProjectOnPlane(direcao, hit.normal).normalized * direcao.magnitude;

        rb.AddForce(direcao * velocidade);
    }
}