using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Se define la instancia GameControl, asi como los puntos para ganar y las variables para controlar al sprite, 
    // los sonidos y los enemigos
    public static GameControl Instance;
    public GameObject birdBehaviour;
    public PlayerControl playerControl;
    public UIControl uiControl;
    public int pointsToWin = 29;
    public SFXManager sfxManager;

    // Antes de ejecutar start, se usa player prefs para que todo tenga acceso a los puntos que se 
    // necesitan para ganar y se asigna este objeto a la instancia de game control
    public void Awake()
    {
        PlayerPrefs.SetInt("PointsToWin", pointsToWin);
        Instance = this;
        DontDestroyOnLoad(gameObject);   
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Verifica si el juego se acabo revisando los puntos que tiene el jugador
    public void checkGameOver(int _currentScore) {
        PlayerPrefs.SetInt("score", _currentScore);
        if(_currentScore >= pointsToWin) {
            SceneManager.LoadScene("EndScene");
        }
    }
}
