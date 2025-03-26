using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Variable para cada sonido
    public AudioClip coins;
    public AudioClip endSound;

    // Funcion para reproducir el sonido de la muerte del enemigo
    public void getCoin() {
        AudioSource.PlayClipAtPoint(coins, Camera.main.transform.position, 0.2f);
    }

    // Funcion para musica de victoria
    public void EndGame() {
        AudioSource.PlayClipAtPoint(endSound, Camera.main.transform.position, 0.2f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
