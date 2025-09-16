using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float tempoDestruir;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right * velocidade * Time.deltaTime);
        Destroy(gameObject, tempoDestruir);
    }
}
