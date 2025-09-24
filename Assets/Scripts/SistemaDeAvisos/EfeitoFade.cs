using UnityEngine;

public class EfeitoFade : MonoBehaviour
{
    [SerializeField] private float tempoDestruir;

    // Update is called once per frame
    void Update()
    {
        tempoDestruir += Time.deltaTime;

        if (tempoDestruir >= 0.4f)
            Destroy(this.gameObject);
    }
}
