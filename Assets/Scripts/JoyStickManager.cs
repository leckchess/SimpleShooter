using UnityEngine;
using UnityEngine.UI;

public class JoyStickManager : MonoBehaviour
{
    private Image imageJoystickBG;
    private Image imageJoystick;

    private void Start()
    {
        imageJoystickBG = transform.Find("JoyStickBG").GetComponent<Image>();
        imageJoystick = transform.Find("JoyStick").GetComponent<Image>();
    }
}
