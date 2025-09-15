using UnityEngine;
using UnityEngine.UI;

public class SpriteVida : MonoBehaviour
{
    [SerializeField] private Image imagemVida;
    private Animator animator;

    void Start()
    {
        if (imagemVida == null)
        {
            imagemVida = GameObject.Find("ImagemVida").GetComponent<Image>();
        }

        if (animator == null)
        {
            animator = GameObject.Find("ImagemVida").GetComponent<Animator>();
        }
    }


    public void MeiaVida()
    {
        animator.SetTrigger("MeiaVida");
    }

    public void SemVida()
    {
        animator.SetTrigger("SemVida");
    }
}
