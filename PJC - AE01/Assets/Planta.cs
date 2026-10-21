
using UnityEngine;
using System.Collections;

public class Planta : MonoBehaviour
{
    public GameManager gameManager;
    public int cooldown = 5;
    public int recompensa = 10;

    public bool listaParaRecoger = false;

    private Coroutine corrutinaCrecimiento;

    private void Start()
    {
        IniciarCrecimiento();
    }

    public void Plantar(int c, int r)
    {
        cooldown = c;
        recompensa = r;

        IniciarCrecimiento();
    }

    private void IniciarCrecimiento()
    {
        // Evita tener varias corrutinas simultáneas.
        if (corrutinaCrecimiento != null)
        {
            StopCoroutine(corrutinaCrecimiento);
        }

        listaParaRecoger = false;
        corrutinaCrecimiento = StartCoroutine(EsperarCrecimiento());
    }

    IEnumerator EsperarCrecimiento()
    {
        Debug.Log("La planta está creciendo...");

        yield return new WaitForSeconds(cooldown);

        listaParaRecoger = true;
        corrutinaCrecimiento = null;

        Debug.Log("¡La planta está lista para recoger!");
    }

    public void Recoger()
    {
        if (!listaParaRecoger)
        {
            Debug.Log("La planta todavía no ha crecido.");
            return;
        }

        gameManager.SumarPuntos(recompensa);

        Debug.Log("¡Has recogido la planta y ganado "
                  + recompensa + " puntos!");

        // Empieza un nuevo ciclo de crecimiento.
        IniciarCrecimiento();
    }
}
