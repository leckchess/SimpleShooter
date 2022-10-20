using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Button _switchWeaponsButton;
    [SerializeField] private Button _fireWeaponButton;

    [HideInInspector] public UnityEvent OnShootingButtonPressed;
    [HideInInspector] public UnityEvent OnShootingButtonReleased;
    [HideInInspector] public UnityEvent OnSwitchWeaponPressed;

    private void Start()
    {
        _switchWeaponsButton.onClick.AddListener(() => { OnSwitchWeaponPressed.Invoke(); });

        EventTrigger trigger = _fireWeaponButton.gameObject.AddComponent<EventTrigger>();

        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => OnShootingButtonPressed.Invoke());
        trigger.triggers.Add(pointerDown);

        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => OnShootingButtonReleased.Invoke());
        trigger.triggers.Add(pointerUp);
    }

    public void SetupCurrentWeapon(Texture2D weaponImage)
    {
        _switchWeaponsButton.transform.Find("WeaponImage").GetComponent<RawImage>().texture = weaponImage;
    }
}
