using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private Transform alvo;
    [SerializeField] private float tempoDestruir;

    private Vida vida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = GetComponent<Vida>();

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
        Destroy(gameObject, tempoDestruir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject, 1.0f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("O Player tomou dano");
            vida.LevarDano(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject, 1.0f);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("O Player tomou dano");
        }
    }
}
