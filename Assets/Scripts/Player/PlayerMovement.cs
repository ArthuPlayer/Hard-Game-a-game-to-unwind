using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;

    [SerializeField] private float moveInput  = 1;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(velocidade * moveInput * Time.deltaTime, 0, 0);
    }
    
    // Chamados nos butoes
    public void MoveLeft()
    {
        moveInput = -1;
        Debug.Log("O butao de mover pra esquerda esta funcionando");
    }

    public void MoveRight()
    {
        moveInput = 1;
        Debug.Log("O butao de mover pra direita esta funcionando");
    }

    public void StopMove()
    {
        moveInput = 0;
    }


}

