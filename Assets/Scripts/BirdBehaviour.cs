using UnityEngine;
using UnityEngine.UIElements;

public class BirdBehaviour : MonoBehaviour
{
    // Variables para el nombre el enemigo, un slider para cuantos puntos otorga y un enum con los nombres de los enemigos
    public BirdName nameBird = BirdName.BSpartan;
    [Range(0,10)] public int points = 0;
    public enum BirdName {
        BSpartan, RKnight, BKnight, RSpartan, Viking
    }

    // Maneja lo que pasa cuando el sprite toca al enemigo (añade puntos, destruye al enemigo y reproduce el sfx)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            GameControl.Instance.uiControl.AddPoints(points);
            GameObject.Destroy(this.gameObject);
            GameControl.Instance.sfxManager.getCoin();
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
