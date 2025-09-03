using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{    
    public void MudarFase(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
