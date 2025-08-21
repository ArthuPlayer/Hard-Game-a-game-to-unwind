using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Jump : MonoBehaviour
{
    [SerializeField] private float forcaPulo = 7;
    [SerializeField] private GameObject camadaPiso;
    [SerializeField] private float raio;
    [SerializeField] private LayerMask chao;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Pulo()
    {
        if (EstaNoPiso())
        {
            rb.AddForce(Vector2.up * forcaPulo);
            Debug.Log("O butao de pulo esta funcionando");
        }
    }

    private bool EstaNoPiso()
    {
        bool estahNoPiso = Physics2D.OverlapCircle(camadaPiso.transform.position, raio, chao);
        return estahNoPiso;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(camadaPiso.transform.position, raio);
    }
}
