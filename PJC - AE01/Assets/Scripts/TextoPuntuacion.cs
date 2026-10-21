
using UnityEngine;
using TMPro;

public class TextoPuntuacion : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text textoPuntos;

    void Update()
    {
        textoPuntos.text = ": " + gameManager.puntuacion;
    }
}
