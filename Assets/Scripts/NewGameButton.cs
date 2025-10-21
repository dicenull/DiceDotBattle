using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
