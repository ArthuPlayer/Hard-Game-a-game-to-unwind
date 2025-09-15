using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float raioPulo;
    [SerializeField] private float forca;
    [SerializeField] private LayerMask piso;
    private Animator animator;
    private Rigidbody2D body;

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

    private bool EstaColidindo()
    {
        bool estahColidindo = Physics2D.OverlapCircle(transform.position, raioPulo, piso);
        return estahColidindo;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioPulo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pular") || EstaColidindo())
        {
            Jumping();
        }
    }
}
