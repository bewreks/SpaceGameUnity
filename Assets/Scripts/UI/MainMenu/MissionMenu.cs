using UnityEngine;

public class MissionMenu : UIMenu
{
	[SerializeField] private GameObject _missionsContainer;

	private void RefreshData()
	{
		HideUpdates();
        
		var i = 0;
		foreach (var mission in MissionManager.Instance.GetControllers())
		{
			var item = MissionsPool.current.GetObject();
			var missionUi = item.GetComponent<MissionUI>();
			missionUi.SetController(mission);
			missionUi.OnClick += OnClick;
			missionUi.Show(i++);
		}
	}
	
	private void OnClick(MissionController mission)
	{
		PlayerController.Instance.SelectMission(mission);
		GameController.current.SwitchScene(Scenes.SPACE);
	}

	private void HideUpdates()
	{
		for (int i = 0; i < _missionsContainer.transform.childCount; i++)
		{
			var item = _missionsContainer.transform.GetChild(i).gameObject;
			var missionUi = item.GetComponent<MissionUI>();
			missionUi.Hide();
		}
	}

	protected override void OnShow()
	{
		gameObject.SetActive(true);
		RefreshData();
	}

	protected override void OnHide()
	{
		gameObject.SetActive(false);
	}
}
