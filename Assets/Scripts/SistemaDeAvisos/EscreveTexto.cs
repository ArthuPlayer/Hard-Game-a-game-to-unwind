using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EscreveTexto : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject imagem;
    [SerializeField] private string[] mensagens;  // Array de mensagens
    [SerializeField] private float velocidadeDigitacao = 0.05f;
    [SerializeField] private float tempoDestruir = 3;
    [SerializeField] private Color corDoTexto = Color.white;
    [SerializeField] private GameObject butaoRestart;

    private bool escrevendo = false;
    private int indiceMensagem = 0; // Qual mensagem está sendo exibida

    void Start()
    {
        imagem.SetActive(false);

        if (texto != null)
        {
            texto.text = "";
            texto.color = corDoTexto;
        }

        if (imagem == null)
        {
            Destroy(imagem);
        }
    }

    void Awake()
    {

        //butaoRestart.SetActive(false);
    }

    void Update()
    {
        if (texto.text != "")
        {
            escrevendo = true;
            imagem.SetActive(true);
        }
        else
        {
            escrevendo = false;
            imagem.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !escrevendo && indiceMensagem == 0)
        {
            //imagem.SetActive(true);
            StartCoroutine(DigitarTexto());
        }
    }

    private IEnumerator DigitarTexto()
    {
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
        indiceMensagem++;
        escrevendo = false;
    }
}
