using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaFase : MonoBehaviour
{
    [SerializeField] private GameObject efeitoFade;
    [SerializeField] private float tempoDeRolando;
    [SerializeField] private float CouldownTransicao;
    [SerializeField] private string nomeCena;
    [SerializeField] private bool PEstah = false;

    void Start()
    {
        efeitoFade.SetActive(true);

        if (efeitoFade == null)
        {
            efeitoFade = GameObject.Find("EfeitoFade");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PEstah)
        {
            tempoDeRolando += Time.deltaTime;
        }

        if (tempoDeRolando >= CouldownTransicao)
        {
            tempoDeRolando = 0;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PEstah = true;
        }
    }
}
