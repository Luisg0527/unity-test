using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Variables de texto, y cantidad de puntos actuales
    public Text ammountPoints;
    string ammountText = "Points: ";
    int currentScore = 0;

    // Se activa el texto del puntaje
    public void ActiveScore() {
        ammountPoints.text = ammountText + "--";
    }

    // Añadir puntos y actualizar el texto
    public void AddPoints(int _points) {
        currentScore += _points;
        PrintScore();
    }

    // Imprime el texto "Points: " y la cantidad de puntos que se lleva
    public void PrintScore() {
        ammountPoints.text = ammountText + currentScore;
        GameControl.Instance.checkGameOver(currentScore);
    }
    
    // Se activa el texto del puntaje al iniciar el juego
    void Start()
    {
        ActiveScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
