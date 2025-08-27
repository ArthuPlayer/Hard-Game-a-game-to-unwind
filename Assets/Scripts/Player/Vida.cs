using Unity.Mathematics;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaAtual;
    [SerializeField] private int vidaMaxima;

    private bool estahVivo;

    private Rigidbody2D rb;

    void Start()
    {
        vidaAtual = vidaMaxima;
        rb = GetComponent<Rigidbody2D>();
    }

    private void LevarDano(int dano)
    {
        vidaAtual = math.clamp(vidaAtual -= dano, 0, vidaMaxima);
    }

    public bool EstaVivo()
    {
        return estahVivo;
    }

    private void Morreu()
    {
        if (vidaAtual <= 0)
        {
            estahVivo = false;
            rb.Sleep();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            LevarDano(1);
        }
    }
}
