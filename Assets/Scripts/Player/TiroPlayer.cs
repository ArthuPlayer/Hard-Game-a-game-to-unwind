using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float tempoDestruir;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right * velocidade * Time.deltaTime);
        Destroy(gameObject, tempoDestruir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            animator.SetBool("Desaparecer", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
