using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        bool IsWin1P = GameData.Instance.IsWin1P;
        resultText.text = IsWin1P ? "Player 1 Win!" : "Player 2 Win!";
    }
}
