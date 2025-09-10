using UnityEngine;

public class RunBoss : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject alvo;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

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
        float direcao = alvo.transform.position.x - transform.position.x;

        if (alvo.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }

        if (alvo.transform.position.x <  transform.position.x)
        {
            sprite.flipX = true;
        }

        transform.position += new Vector3(direcao * velocidade * Time.deltaTime, 0, 0);
    }
}
