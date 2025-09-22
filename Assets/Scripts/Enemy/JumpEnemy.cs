using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    [SerializeField] private float forca;
    [SerializeField] private LayerMask chao;
    [SerializeField] private float raio = 0.25f;
    [SerializeField] private GameObject camadaChao;
    [SerializeField] private GameObject alvo;
    [SerializeField] private bool boss;

    private Animator animador;
    private Rigidbody2D rb;

    void Start()
    {
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jumping()
    {
        if (!boss)
        {
            rb.AddForce(Vector2.up * forca);
        }

        if (boss && EstaNoPiso())
        {
            Vector2 direcao = (alvo.transform.position - Vector3.down) - transform.position;
            rb.AddForce(direcao * forca, ForceMode2D.Impulse);
        }

    }

    private bool EstaNoPiso()
    {
        bool estahNoPiso = Physics2D.OverlapCircle(camadaChao.transform.position, raio, chao);
        return estahNoPiso;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(camadaChao.transform.position, raio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Inimigo Pulou");
            Jumping();
        }
    }
}
