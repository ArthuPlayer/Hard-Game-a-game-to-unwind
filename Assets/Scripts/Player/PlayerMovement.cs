using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float moveInput  = 1;

    private PauseMenu pauseMenu;
    private Vida vida;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
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

