using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _dataContainer;
    [SerializeField] private GameObject _shipTab;
    [SerializeField] private GameObject _missionTab;

    private UIMenu _ship;
    private UIMenu _mission;
    
    private UIMenu _currentTab;

    private bool _isShipShowed;
    private bool _isMissionShowed;

    private void Start()
    {
        if (!GameController.current)
        {
            GameController.OnLoad += OnLoad;
        }
        else
        {
            OnLoad();
        }
    }

    private void OnLoad()
    {
        SwitchTab(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SwitchTab(int tabId)
    {
        if (_currentTab)
        {
            _currentTab.Hide(tabId);
        }

        switch (tabId)
        {
            case 0:
                _currentTab = InstantiateIfNeed(ref _mission, _missionTab);
                break;
            case 1:
                _currentTab = InstantiateIfNeed(ref _ship, _shipTab);
                break;
        }

        if (_currentTab)
        {
            _currentTab.Show(tabId);
        }
    }

    private UIMenu InstantiateIfNeed(ref UIMenu tab, GameObject prefab)
    {
        if (tab == null)
        {
            tab = Instantiate(prefab, _dataContainer.transform).GetComponent<UIMenu>();
        }

        return tab;
    }
}