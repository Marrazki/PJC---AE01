using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool pulsandoX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLANTA"))
        {
            if (pulsandoX)
            {
                Debug.Log("PEIO");
            }
        }
    }
    public void OnRecoger(InputValue value)
    {
        pulsandoX = !pulsandoX;
    }
}
