using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tiroPrefab;
    [SerializeField] private Transform miraPrefab;
    [SerializeField] private float tempoTiro;
    [SerializeField] private float couldownTiro;

    void Update()
    {
        tempoTiro += Time.deltaTime;
    }

    public void TiroPlayer()
    {
        if (tempoTiro >= couldownTiro)
        {
            Instantiate(tiroPrefab, miraPrefab.position, transform.rotation);
        }
    }
}
