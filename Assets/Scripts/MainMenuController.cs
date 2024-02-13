using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
}
