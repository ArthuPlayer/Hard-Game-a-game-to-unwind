using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeFase : MonoBehaviour
{
    [SerializeField] private GameObject efeitoFade;
    [SerializeField] private float tempoPTransicao;
    [SerializeField] private float CouldownTempo;
    [SerializeField] private bool PEstah = false;
    [SerializeField] private string nomeCena;

    void Start()
    {
        efeitoFade.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PEstah)
        {
            tempoPTransicao += Time.deltaTime;
        }

        if (tempoPTransicao >= CouldownTempo)
        {
            SceneManager.LoadScene(nomeCena);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PEstah = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PEstah = true;
        }
    }
}
