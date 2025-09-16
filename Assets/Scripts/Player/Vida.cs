using System.Collections;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaAtual;
    [SerializeField] private int vidaMaxima = 2;
    [SerializeField] private float tempoDeDestruir = 1f;
    [SerializeField] private bool player;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator PlayerAnim;
    [SerializeField] private bool cenaBoss;
    [SerializeField] private GameObject gameOver;

    private bool estahVivo = true;

    void Start()
    {
        vidaAtual = vidaMaxima;

        if (imageAnim == null)
        {
            imageAnim = null;
        }

        if (PlayerAnim == null)
        {
            PlayerAnim = GetComponent<Animator>();
        }
    }

    public void LevarDano(int dano)
    {
        vidaAtual = math.clamp(vidaAtual -= dano, 0, vidaMaxima);
        VerificaVida();
    }

    private void VerificaVida()
    {
        if (player) // Verifica primeiro se o player existe
        {
            if (vidaAtual == 1)
            {
                imageAnim.SetTrigger("MeiaVida");
            }
            else if (vidaAtual == 0)
            {
                imageAnim.SetTrigger("SemVida");
            }
        }

        if (vidaAtual <= 0)
        {
            if (player)
            {
                PlayerAnim.SetBool("Dead", true);
                StartCoroutine(TempoReiniciar(tempoDeDestruir));
            }
            estahVivo = true;
        }
    }

    public bool EstaVivo()
    {
        return estahVivo;
    }


    IEnumerator TempoReiniciar(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") && player) // E player
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Player") && !player) // E inimigo
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Tiro") && player) // E player
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Trap") && player)
        {
            PlayerAnim.SetBool("Dead", true);
            StartCoroutine(TempoReiniciar(tempoDeDestruir));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") && player) // E player
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Player") && !player) // E inimigo
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Tiro") && player) // E player
        {
            LevarDano(1);
        }
    }
}
