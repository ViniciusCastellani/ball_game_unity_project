using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class inimigo_movimento : MonoBehaviour
{
    public Transform jogador;
    private NavMeshAgent inimigo;

    public float tempo_parado = 1.5f;
    private float timer = 0f;

    public AudioSource audio_source;
    public AudioClip som_hit;

    private bool pode_tocar_som = true;

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
            pode_tocar_som = true;
            inimigo.isStopped = false;
            inimigo.SetDestination(jogador.position);
        }
    }

    private void OnTriggerEnter(Collider objetoColidido)
    {
        if (objetoColidido.CompareTag("Player"))
        {
            timer = tempo_parado;
            if (pode_tocar_som)
            {
                audio_source.PlayOneShot(som_hit);
                pode_tocar_som = false;
            }
        }
    }
}
