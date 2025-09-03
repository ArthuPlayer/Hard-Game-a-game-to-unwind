using Unity.Mathematics;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaAtual;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private bool player;

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
        if (vidaAtual <= 0)
        {
            estahVivo = false;
            rb.Sleep();
        }
    }

    public bool EstaVivo()
    {
        return estahVivo;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") && player)
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Player") && !player)
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Tiro") && player)
        {
            LevarDano(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") && player)
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Player") && !player)
        {
            LevarDano(1);
        }

        if (collision.gameObject.CompareTag("Tiro") && player)
        {
            LevarDano(1);
        }
    }
}
