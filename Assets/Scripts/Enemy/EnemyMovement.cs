using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int dir = 1;
    [SerializeField] private float velocidade;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (dir == 1) // O inimigo se move para a direita
        {
            transform.position += new Vector3(1 * velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        if (dir == 0) // O inimigo se move para a esquerda
        {
            transform.position += new Vector3(-1 * velocidade * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ParedeDireita")) // Toca na parede direita e se move para a Esquerda
        {
            dir = 0;
        }

        if (collision.gameObject.CompareTag("ParedeEsquerda")) // Toca na parede esquerda e se move para a Direita
        {
            dir = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dir = 1;
        }
    }
}
