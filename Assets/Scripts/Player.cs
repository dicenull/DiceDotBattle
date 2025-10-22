using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int Hp = 1;
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] Key forwardKey = Key.W;
    [SerializeField] Key backKey = Key.S;
    [SerializeField] Key leftKey = Key.A;
    [SerializeField] Key rightKey = Key.D;
    [SerializeField] Key shotKey = Key.Space;

    [SerializeField] TextMeshProUGUI hpText;

    const float CoolDown = 2f;
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
            // あえて、打った後も動かせる
            dot.transform.parent = transform;

            dot.GetComponent<Rigidbody>().AddForce(vector * 10f, ForceMode.Impulse);
            Destroy(dot, CoolDown);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Hit();
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
        SceneManager.LoadScene("Result");
    }

    void MoveFromKeyInput()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard[leftKey].isPressed)
        {
            MoveLeft();
        }
        else if (keyboard[rightKey].isPressed)
        {
            MoveRight();
        }
        else if (keyboard[forwardKey].isPressed)
        {
            MoveForward();
        }
        else if (keyboard[backKey].isPressed)
        {
            MoveBack();
        }
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void MoveBack()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }
}
