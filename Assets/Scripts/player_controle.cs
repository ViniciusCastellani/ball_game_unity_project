using UnityEngine;

public class player_controle : MonoBehaviour
{
    public Rigidbody rb;

    public float horizontal;

    public float vertical;

    public float velocidade = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }
    void Walk()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontal, 0, vertical);

        rb.AddForce(direcao * velocidade);
    }
}
