using UnityEngine;
using System.Collections;

public class Planta : MonoBehaviour
{
    public GameManager gameManager;
    public int cooldown;
    public int recompensa;

    private bool listaParaRecoger = false;

    public void Plantar(int c, int r)
    {
        cooldown = c;
        recompensa = r;

        StartCoroutine(EsperarCrecimiento());
    }

    IEnumerator EsperarCrecimiento()
    {
        yield return new WaitForSeconds(cooldown);

        listaParaRecoger = true;
        Debug.Log("¡La planta está lista para recoger!");
    }

    public void Recoger()
    {
        if (listaParaRecoger)
        {
            // Añade los puntos al GameManager
            gameManager.SumarPuntos(recompensa);

            listaParaRecoger = false;
        }
        else
        {
            Debug.Log("La planta todavía no ha crecido.");
        }
    }
}