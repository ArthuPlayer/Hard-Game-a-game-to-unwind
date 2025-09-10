using Unity.Mathematics;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaAtual;
    [SerializeField] private int vidaMaxima = 2;
    [SerializeField] private bool player;
    [SerializeField] private Animator animator;

    private bool estahVivo;
    private Rigidbody2D rb;

    void Start()
    {
        vidaAtual = vidaMaxima;
        rb = GetComponent<Rigidbody2D>();
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
                animator.SetTrigger("MeiaVida");
            }
            else if (vidaAtual == 0)
            {
                animator.SetTrigger("SemVida");
            }
        }

        if (vidaAtual <= 0)
        {
            estahVivo = false;
        }
    }

    public bool EstaVivo()
    {
        return estahVivo;
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
