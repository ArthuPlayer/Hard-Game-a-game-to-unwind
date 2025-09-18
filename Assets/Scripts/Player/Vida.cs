using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaAtual;
    [SerializeField] private int vidaMaxima = 2;
    [SerializeField] private float tempoDeDestruir = 1f;
    [SerializeField] private bool player;
    [SerializeField] private bool boss;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator PlayerAnim;
    [SerializeField] private Animator BossAnim;
    [SerializeField] private Animator InimigoAnim;

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
            else
            {
                InimigoAnim.SetBool("Morreu", true);
                Destroy(gameObject, 0.5f);
            }
            estahVivo = false;
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

        if (collision.gameObject.CompareTag("TiroPlayer") && !player) // E inimigo
        {
            LevarDano(1);

            if (boss && vidaAtual == 3)
            {
                InimigoAnim.SetTrigger("EstahMorrendo");
                LevarDano(1);
            }

            if (boss && vidaAtual <= 0)
            {
                vidaAtual = 0;
                InimigoAnim.SetBool("Morreu", true);
            }
        }

        if (collision.gameObject.CompareTag("Tiro") && player) // E player
        {
            LevarDano(1);
        }
    }
}
