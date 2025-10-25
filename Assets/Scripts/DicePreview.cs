using UnityEngine;

public class DicePreview : MonoBehaviour
{
    void Update()
    {
        RotationPreview();
    }

    void RotationPreview()
    {
        transform.Rotate(new Vector3(-1, 0, 0));
    }
}
