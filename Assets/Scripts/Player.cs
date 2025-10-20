using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 5.0f;
    [SerializeField] Key forwardKey = Key.W;
    [SerializeField] Key backKey = Key.S;
    [SerializeField] Key leftKey = Key.A;
    [SerializeField] Key rightKey = Key.D;


    void Update()
    {
        MoveFromKeyInput();
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
