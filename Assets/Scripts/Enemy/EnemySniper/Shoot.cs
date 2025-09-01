using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private Transform alvo;
    [SerializeField] private LayerMask DestroyMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (alvo == null)
        {
            alvo = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direcao = alvo.position - transform.position;
        transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == DestroyMask)
        {
            Destroy(gameObject, 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == DestroyMask)
        {
            Destroy(gameObject, 1.5f);
        }
    }
}
