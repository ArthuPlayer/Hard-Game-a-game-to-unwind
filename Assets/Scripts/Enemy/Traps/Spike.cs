using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GameObject.Find("Player").GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
