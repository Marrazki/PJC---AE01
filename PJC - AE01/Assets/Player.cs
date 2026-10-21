
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Planta plantaCercana;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        playerInput.actions
            .FindActionMap("Interacciones")
            .Enable();
    }
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

    public void OnRecogerTeclado(InputValue value)
    {
        Debug.Log("RECOGER");
        if (value.isPressed && plantaCercana != null)
        {
            plantaCercana.Recoger();
        }
    }
}
