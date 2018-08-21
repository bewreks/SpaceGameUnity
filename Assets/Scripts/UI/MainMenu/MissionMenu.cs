using UnityEngine;

public class MissionMenu : MonoBehaviour
{
	[SerializeField] private GameObject _missionsContainer;

	private void Start()
	{
		RefreshData();
	}

	public void RefreshData()
	{
		HideUpdates();
        
		var i = 0;
		foreach (var upgrade in MissionManager.Instance.GetControllers())
		{
			var item = MissionsPool.current.GetObject();
			var updateUi = item.GetComponent<MissionUI>();
			updateUi.SetMissionData(upgrade);
			updateUi.OnClick += OnClick;
			var transform = item.GetComponent<RectTransform>();
			transform.anchoredPosition = new Vector2(0, i++ * -transform.sizeDelta.y);
			item.SetActive(true);
		}
	}
	
	private void OnClick(MissionController mission)
	{
		PlayerController.Instance.SelectMission(mission);
		GameDataController.current.SwitchScene(Scenes.SPACE);
	}

	private void HideUpdates()
	{
		for (int i = 0; i < _missionsContainer.transform.childCount; i++)
		{
			var item = _missionsContainer.transform.GetChild(i).gameObject;
			var missionUi = item.GetComponent<MissionUI>();
			missionUi.OnClick = null;
			item.SetActive(false);
		}
	}
}
