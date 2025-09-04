using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private float raio;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float tempoDeAtirar;
    [SerializeField] private float tempoMaximo;
    [SerializeField] private GameObject tiroPrefab;
    [SerializeField] private bool Boss;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        tempoDeAtirar += Time.deltaTime;
        Atirar();
    }

    public void Atirar()
    {
        if (tempoDeAtirar > tempoMaximo && EstahNoAlcance())
        {
            tempoDeAtirar = 0;
            Instantiate(tiroPrefab, transform.position, transform.rotation);

            if (!Boss)
            {
                animator.SetTrigger("Shooting");
            }
        }
    }

    private bool EstahNoAlcance()
    {
        bool estahAlcance = Physics2D.OverlapCircle(transform.position, raio, playerMask);
        return estahAlcance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
