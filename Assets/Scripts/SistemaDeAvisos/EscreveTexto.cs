using System.Collections;
using TMPro;
using UnityEngine;

public class EscreveTexto : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject Imagem;
    [SerializeField] private string[] mensagens;  // Array de mensagens
    [SerializeField] private float velocidadeDigitacao = 0.05f;
    [SerializeField] private float tempoDestruir = 3;
    [SerializeField] private Color corDoTexto = Color.white;

    private bool escrevendo = false;
    private int indiceMensagem = 0; // Qual mensagem está sendo exibida

    void Start()
    {
        Imagem.SetActive(false);

        if (texto != null)
        {
            texto.text = "";
            texto.color = corDoTexto;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !escrevendo && indiceMensagem < mensagens.Length)
        {
            StartCoroutine(DigitarTexto());
        }
    }

    private IEnumerator DigitarTexto()
    {
        Imagem.SetActive(true);
        escrevendo = true;
        texto.text = "";

        string mensagemAtual = mensagens[indiceMensagem];

        foreach (char letra in mensagemAtual)
        {
            texto.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }

        yield return new WaitForSeconds(tempoDestruir);
        texto.text = "";
        Imagem.SetActive(false);
        indiceMensagem++;
        escrevendo = false;
    }
}
