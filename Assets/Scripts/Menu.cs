using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Vector3 localCheckPoint;


    
    public void MudarFase(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
