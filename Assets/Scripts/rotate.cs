using UnityEngine;

public class rotate : MonoBehaviour
{
    public Vector3 velocidadeDeRotacao;
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidadeDeRotacao * Time.deltaTime);
    }
}
