using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float tempoDestruir;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, tempoDestruir);

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.localScale.x > 1f)
        {
            transform.position += new Vector3(1 * velocidade * Time.deltaTime, 0, 0);
            sprite.flipX = false;
        }
        else if (player.localScale.x < -1f)
        {
            transform.position += new Vector3(-1 * velocidade * Time.deltaTime, 0, 0);
            sprite.flipX = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("Piso"))
        {
            animator.SetBool("Desaparecer", true);
            Destroy(this.gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("Piso"))
        {
            animator.SetBool("Desaparecer", true);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
