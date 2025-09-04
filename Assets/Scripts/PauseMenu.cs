using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private string cenaDeMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(cenaDeMenu);
    }

    public void Retornar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
