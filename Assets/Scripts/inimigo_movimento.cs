using UnityEngine;
using UnityEngine.AI;

public class inimigo_movimento : MonoBehaviour
{
    public Transform jogador;
    private NavMeshAgent inimigo;
    public float tempo_parado = 1.5f;
    private float timer = 0f;

    void Start()
    {
        inimigo = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        if (timer > 0f){
            timer -= Time.deltaTime;
            inimigo.isStopped = true;
        }
        else
        {
            inimigo.isStopped = false;
            inimigo.SetDestination(jogador.position);
        }
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("Player"))
            timer = tempo_parado;
    }
}
