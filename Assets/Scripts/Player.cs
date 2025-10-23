using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum PlayerType
{
    Player1,
    Player2
}

public class Player : MonoBehaviour
{
    [SerializeField] PlayerType playerType = PlayerType.Player1;
    [SerializeField] private int Hp = 1;
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] Key forwardKey = Key.W;
    [SerializeField] Key backKey = Key.S;
    [SerializeField] Key leftKey = Key.A;
    [SerializeField] Key rightKey = Key.D;
    [SerializeField] Key shotKey = Key.Space;
    [SerializeField] private int ballSize = 0;

    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI ballSizeText;

    const float CoolDown = 1f;
    float? lastShotTime = null;

    void Update()
    {
        MoveFromKeyInput();
        ShotDot();
    }

    void ShotDot()
    {
        if (Keyboard.current == null) return;
        if (Keyboard.current[shotKey].wasPressedThisFrame)
        {
            CheckShot();
        }
    }

    void CheckShot()
    {
        if (lastShotTime.HasValue && Time.time - lastShotTime.Value < CoolDown)
        {
            return;
        }

        lastShotTime = Time.time;
        // 4方向に打つ
        for (int i = 0; i < 4; i++)
        {
            var vector = Quaternion.Euler(0, i * 90f, 0) * transform.forward;
            var dot = Instantiate(Resources.Load<GameObject>("Prefabs/Dot"), transform.position + vector * 2f, Quaternion.identity);
            dot.transform.localScale = Vector3.one * 0.3f + Vector3.one * ballSize * 0.1f;
            // あえて、打った後も動かせる
            dot.transform.parent = transform;

            dot.GetComponent<Rigidbody>().AddForce(vector * 20f, ForceMode.Impulse);
            Destroy(dot, CoolDown);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            HitBall(other);
        }

        if (other.tag == "Dot")
        {
            Hit();
        }
    }


    void HitBall(Collider collider)
    {
        Destroy(collider.gameObject);
        ballSize++;
        ballSizeText.text = $"ShotSize: {ballSize}";
    }

    void Hit()
    {
        if (Hp <= 0) return;

        Hp--;
        hpText.text = $"HP: {Hp}";

        if (Hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameData.Instance?.SetLoser(playerType);

        SceneManager.LoadScene("Result");
    }

    void MoveFromKeyInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard[leftKey].isPressed)
        {
            Move(Vector3.left);
        }
        else if (keyboard[rightKey].isPressed)
        {
            Move(Vector3.right);
        }
        else if (keyboard[forwardKey].isPressed)
        {
            Move(Vector3.forward);
        }
        else if (keyboard[backKey].isPressed)
        {
            Move(Vector3.back);
        }
    }

    void Move(Vector3 vector)
    {
        var movement = vector * Speed * Time.deltaTime;
        var newPosition = transform.position + movement;

        if (newPosition.magnitude > GameData.FieldRadius)
        {
            return;
        }

        transform.Translate(movement);
    }
}

