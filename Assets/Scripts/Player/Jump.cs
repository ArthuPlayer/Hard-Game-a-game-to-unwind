using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float forcaPulo = 7;
    [SerializeField] private GameObject camadaPiso;
    [SerializeField] private float raio;
    [SerializeField] private LayerMask chao;
    
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Pulo()
    {
        if (EstaNoPiso())
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            animator.SetTrigger("Pulo");
            animator.SetBool("EstahNoPiso", false);
            Debug.Log("O butao de pulo esta funcionando");
        }
    }

    private bool EstaNoPiso()
    {
        bool estahNoPiso = Physics2D.OverlapCircle(camadaPiso.transform.position, raio, chao);
        return estahNoPiso;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Piso"))
        {
            animator.SetBool("EstahNoPiso", true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(camadaPiso.transform.position, raio);
    }
}
