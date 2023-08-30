#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Text bestScoreText;


    public void StartGame()
    {
        PlayerDataHandler.Instance.SaveBestScore(0, playerNameInput.text);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Start()
    {
        playerNameInput.text = PlayerDataHandler.Instance.CurrentPlayer;
        bestScoreText.text = $"Best Score: {PlayerDataHandler.Instance.BestPlayerName} : {PlayerDataHandler.Instance.BestPlayerScore}";
    }
}
