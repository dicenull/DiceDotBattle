using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    bool spawned = false;

    void Update()
    {
        CheckSpawn();
    }

    void CheckSpawn()
    {
        if (spawned)
        {
            return;
        }

        var randomPos = Random.insideUnitCircle * GameData.FieldRadius;
        var ball = Instantiate(ballPrefab, new Vector3(randomPos.x, .5f, randomPos.y), Quaternion.identity);
        ball.AddComponent<Ball>().OnDestroyed += () => { spawned = false; };

        spawned = true;
    }
}

public class Ball : MonoBehaviour
{
    public System.Action OnDestroyed;

    void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }
}