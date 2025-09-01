using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private float raio;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float tempoDeAtirar;
    [SerializeField] private GameObject tiroPrefab;

    // Update is called once per frame
    void Update()
    {
        tempoDeAtirar += Time.deltaTime;
        
        if (tempoDeAtirar > 3 && EstahNoAlcance())
        {
            tempoDeAtirar = 0;
            Instantiate(tiroPrefab, transform.position, transform.rotation);
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
