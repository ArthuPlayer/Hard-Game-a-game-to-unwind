using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float tempoDestruir;
    [SerializeField] private Animator animator;
    private float direcao;

    void Start()
    {
        Destroy(gameObject, tempoDestruir);

        if (tempoDestruir > 1)
            animator.SetBool("Desaparecer", true);

        direcao = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (direcao > 0)
            transform.position += new Vector3(1 * velocidade * Time.deltaTime, 0, 0);
        else
            transform.position += new Vector3(-1 * velocidade * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("Piso"))
        {
            animator.SetBool("Desaparecer", true);
            Destroy(this.gameObject, 1f);
        }
    }

    private void OnDestroy()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("Piso"))
        {
            animator.SetBool("Desaparecer", true);
            Destroy(this.gameObject, 1f);
        }
    }
}
