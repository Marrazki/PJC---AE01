
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Planta plantaCercana;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PLANTA"))
        {
            plantaCercana = collision.GetComponent<Planta>();
            Debug.Log("Estás cerca de una planta");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PLANTA"))
        {
            Planta planta = collision.GetComponent<Planta>();

            if (plantaCercana == planta)
            {
                plantaCercana = null;
            }
        }
    }

    public void OnRecoger(InputValue value)
    {
        if (value.isPressed && plantaCercana != null)
        {
            plantaCercana.Recoger();
        }
    }
}
