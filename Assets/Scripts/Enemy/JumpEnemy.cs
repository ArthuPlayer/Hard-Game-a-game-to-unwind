using Unity.VisualScripting;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    [SerializeField] private float forca;
    [SerializeField] private LayerMask chao;
    [SerializeField] private float raio = 0.25f;
    [SerializeField] private GameObject camadaChao;
    private Animator animator;
    private Rigidbody2D body;

    private void Update()
    {
        if (EstaNoPiso())
        {
            animator.SetBool("EstaNoAr", false);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Jumping()
    {
        body.AddForce(Vector2.up * forca);
        animator.SetBool("EstaNoAr", true);
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
