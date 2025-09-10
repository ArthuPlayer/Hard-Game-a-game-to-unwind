using UnityEngine;

public class QuickShot : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private Transform alvo;
    [SerializeField] private float tempoDestruir;

    private Vida vida;
    private PlayerMovement pMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pMove = GetComponent<PlayerMovement>();

        if (alvo == null)
        {
            alvo = GameObject.Find("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direcao = (alvo.position - Vector3.down) - transform.position;
        transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
        Destroy(gameObject, tempoDestruir);
    }
}
