using UnityEngine;

public class RotateLook : MonoBehaviour
{
    [SerializeField] private Joystick joystick = null;

    private void FixedUpdate()
    {
        transform.Rotate(0, joystick.Horizontal, 0);
    }

}
