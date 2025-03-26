using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text winText;
    public SFXManager sound;
    // Al cargar la pantalla se verifica si el usuario si ganó y se despliega el texto y la musica
    void Start()
    {
        if (PlayerPrefs.GetInt("score") >= PlayerPrefs.GetInt("pointsToWin")) {
            winText.text = "You Win!!!";
            sound.EndGame();
        }
    }

    void Update()
    {
        
    }
}
