using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _dataContainer;
    [SerializeField] private GameObject _shipData;
    [SerializeField] private GameObject _missionData;

    private GameObject _ship;
    private GameObject _mission;

    private bool _isShipShowed;
    private bool _isMissionShowed;

    private void Start()
    {
        ShowShip();
    }

    public void ShowShip()
    {
        if (_isShipShowed)
        {
            return;
        }

        _isShipShowed = true;
        HidePrevious();
        if (_ship == null)
        {
            _ship = Instantiate(_shipData, _dataContainer.transform);
        }

        _ship.GetComponent<ShipMenu>().ShowShip();
        _ship.SetActive(true);
    }

    public void ShowMissions()
    {
        if (_isMissionShowed)
        {
            return;
        }

        _isMissionShowed = true;
        HidePrevious();
        if (_mission == null)
        {
            _mission = Instantiate(_missionData, _dataContainer.transform);
        }

        _mission.GetComponent<MissionMenu>().RefreshData();
        _mission.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void HidePrevious()
    {
        if (_ship != null)
            _ship.SetActive(false);

        if (_mission != null)
            _mission.SetActive(false);
    }
}