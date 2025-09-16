using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float moveInput  = 1;
    private Animator animator;
    private SpriteRenderer sprite;
    private Vida vida;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        vida = GetComponent<Vida>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(velocidade * moveInput * Time.deltaTime, 0, 0);

        if (!vida.EstaVivo())
        {
            moveInput = 0;
        }
    }
    
    // Chamados nos butoes
    public void MoveLeft()
    {
        moveInput = -1 ;
        sprite.flipX = true;
        animator.SetBool("Run", true);
        Debug.Log("O butao de mover pra esquerda esta funcionando");
        Debug.Log("MoveInput: " + moveInput);
    }

    public void MoveRight()
    {
        moveInput = 1;
        sprite.flipX = false;
        animator.SetBool("Run", true);
        Debug.Log("O butao de mover pra direita esta funcionando");
        Debug.Log("MoveInput: " + moveInput);
    }

    public void StopMove()
    {
        animator.SetBool("Run", false);
        moveInput = 0;
    }


}

