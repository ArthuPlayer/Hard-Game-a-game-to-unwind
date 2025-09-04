using System.Collections;
using UnityEngine;

public class RotinaBoss : MonoBehaviour
{
    private JumpEnemy m_JumpEnemy;
    private Throw m_throw;
    private Animator animator;
    
    void Start()
    {
        m_JumpEnemy = GetComponent<JumpEnemy>();
        m_throw = GetComponent<Throw>();
        animator = GetComponent<Animator>();
    }

    IEnumerator OrganizaTarefas()
    {
        animator.SetTrigger("Shoot");
        ChanceAtaque(1, 3);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Jump");
        m_JumpEnemy.Jumping();
    }

    private void ChanceAtaque(int numeroMin, int numeroMax)
    {
        int numero = Random.Range(numeroMin, numeroMax);

        if (numero == 2)
        {
            m_throw.Atirar();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Toca no Player e inicia a rotina
        {
            StartCoroutine(OrganizaTarefas());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Toca no Player e inicia a rotina
        {
            StartCoroutine(OrganizaTarefas());
        }
    }
}
