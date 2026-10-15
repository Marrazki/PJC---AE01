using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem;


public class movimiento : MonoBehaviour
{
    Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Movimiento: " + moveInput);
        moveInput = moveInput.normalized * 0.02f;
        transform.position += new Vector3(moveInput.x, 0, 0);

    }
    public void OnMoveTeclado(InputValue value)
    {
        Debug.Log("peio");
        moveInput = value.Get<Vector2>();
        Debug.Log("Movimiento: " + moveInput);
        moveInput = moveInput.normalized * 0.02f;
        transform.position += new Vector3(moveInput.x, 0, 0);

    }
}
