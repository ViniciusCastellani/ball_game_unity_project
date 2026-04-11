using UnityEngine;

public class girar_camera : MonoBehaviour
{
    public GameObject mainCamera, camera_2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCamera.SetActive(false);
            camera_2.SetActive(true);
        }
    }
}