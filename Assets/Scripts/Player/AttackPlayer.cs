using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tiroPrefab;
    [SerializeField] private Transform miraPrefab;
    [SerializeField] private float tempoTiro;
    [SerializeField] private float couldownTiro;

    void Start()
    {
        tempoTiro = couldownTiro;
    }
    void Update()
    {
        tempoTiro += Time.deltaTime;

        if (transform.localScale.x == -1)
        {
            tiroPrefab.GetComponent<Transform>();
            tiroPrefab.transform.localScale = transform.localScale;
        }

        if (transform.localScale.x == 1)
        {
            tiroPrefab.GetComponent<Transform>();
            tiroPrefab.transform.localScale = transform.localScale;
        }
    }

    public void TiroPlayer()
    {
        if (tempoTiro >= couldownTiro)
        {           
            tempoTiro = 0;
            Instantiate(tiroPrefab, miraPrefab.position, transform.rotation);
        }
    }



}
