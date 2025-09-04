using UnityEngine;

public class RunBoss : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject alvo;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (alvo == null)
        {
            alvo = GameObject.Find("Player");
        }
    }

    void Update()
    {
        Corrida();
    }

    public void Corrida()
    {
        animator.SetBool("Run", true);
        Vector2 direcao = alvo.transform.position - transform.position;
        transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
    }
}
