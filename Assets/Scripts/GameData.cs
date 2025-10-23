using UnityEngine;

public class GameData : MonoBehaviour
{
    public static float FieldRadius = 14f;
    public static GameData Instance { get; private set; }

    public bool IsWin1P { get; private set; } = false;

    GameData()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetLoser(PlayerType type)
    {
        IsWin1P = type != PlayerType.Player1;
    }
}
