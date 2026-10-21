
using UnityEngine;
using System.Collections;

public class Planta : MonoBehaviour
{
    public GameManager gameManager;
    public int cooldown;
    public int recompensa;

    private int randomX;
    private int randomY;

    public bool listaParaRecoger = false;

    public Material materialVerde;
    public Material materialBlanco;

    private Coroutine corrutinaCrecimiento;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Generar valores aleatorios del 1 al 10, ambos incluidos.
        randomX = Random.Range(1, 11);
        randomY = Random.Range(1, 11);

        // Asignar los valores ANTES de iniciar la corrutina.
        cooldown = randomX;
        recompensa = randomY;

        Debug.Log("Cooldown: " + cooldown);
        Debug.Log("Recompensa: " + recompensa);

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
        if (corrutinaCrecimiento != null)
        {
            StopCoroutine(corrutinaCrecimiento);
        }

        listaParaRecoger = false;
        spriteRenderer.material = materialVerde;

        corrutinaCrecimiento = StartCoroutine(EsperarCrecimiento());
    }

    IEnumerator EsperarCrecimiento()
    {
        Debug.Log("La planta está creciendo...");

        yield return new WaitForSeconds(cooldown);

        listaParaRecoger = true;
        corrutinaCrecimiento = null;

        spriteRenderer.material = materialBlanco;

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

        Debug.Log("¡Has ganado " + recompensa + " puntos!");

        // Generar nuevos valores para el siguiente ciclo.
        cooldown = Random.Range(1, 11);
        recompensa = Random.Range(1, 11);

        IniciarCrecimiento();
    }
}
