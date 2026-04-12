using UnityEngine;

public class player_controle : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal, vertical;

    public float velocidade = 15f;
    public float velocidadeRotacaoBola = 2500f;
    public GameObject modeloSonic;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Capturamos o input no Update para maior precisão (não perde cliques)
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        HandleRotation();
    }

    void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        Vector3 direcao = new Vector3(horizontal, 0, vertical).normalized;
        rb.AddForce(direcao * velocidade, ForceMode.Acceleration);
    }

    void HandleRotation()
    {
        if (modeloSonic != null)
        {
            Vector3 velocidadeReal = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

            if (velocidadeReal.magnitude > 0.1f)
            {
                Vector3 eixoRotacao = new Vector3(velocidadeReal.z, 0, -velocidadeReal.x);

                modeloSonic.transform.Rotate(
                    eixoRotacao.normalized * velocidadeRotacaoBola * Time.deltaTime,
                    Space.World
                );
            }
        }
    }
}