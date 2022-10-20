using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Shooter> _weapons;

    private int _currentWeaponIndex = 1;

    private UIHandler _uiHandler;

    private void Start()
    {
        GetUIHandler();
        GetWeapons();
    }

    private void Shoot()
    {
        _weapons[_currentWeaponIndex].Shoot(transform.forward);
    }

    private void StopShooting()
    {
        _weapons[_currentWeaponIndex].StopShooting();
    }

    private void SwitchWeapons()
    {
        _currentWeaponIndex = 1 - _currentWeaponIndex;

        if (_uiHandler)
            _uiHandler.SetupCurrentWeapon(_weapons[_currentWeaponIndex].RepresentationImage);
    }

    private void GetUIHandler()
    {
        _uiHandler = FindObjectOfType<UIHandler>();

        if (_uiHandler)
        {
            _uiHandler.OnShootingButtonPressed.AddListener(Shoot);
            _uiHandler.OnShootingButtonReleased.AddListener(StopShooting);
            _uiHandler.OnSwitchWeaponPressed.AddListener(SwitchWeapons);
        }
    }

    private void GetWeapons()
    {
        _weapons = new List<Shooter>();
        _weapons.AddRange(GetComponentsInChildren<Shooter>());
        SwitchWeapons();
    }
}
