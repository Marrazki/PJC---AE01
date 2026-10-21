
using UnityEngine;
using UnityEngine.InputSystem;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    private Vector2 mov;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMoveTeclado(InputValue value)
    {
        Debug.Log("MOVE");
        mov = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = mov * velocidad;
    }
}
