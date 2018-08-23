using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Boo.Lang;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    MAIN_MENU = 0,
    SPACE = 1
}

public class GameController : MonoBehaviour
{
    public static GameController current;
    public static Action OnLoad;

    [SerializeField] private TextAsset _playerXmlFile;
    [SerializeField] private TextAsset _upgradesXmlFile;
    [SerializeField] private TextAsset _elementsXmlFile;
    [SerializeField] private TextAsset _boughtXmlFile;
    [SerializeField] private TextAsset _missionXmlFile;

    private void Awake()
    {
        if (current == null)
        {
            var missions = LoadModels<MissionModel>(_missionXmlFile);
            MissionManager.Instance.Init(missions);

            var updates = LoadModels<UpgradeModel>(_upgradesXmlFile);
            UpgradeManager.Instance.Init(updates);

            var elements = LoadModels<ElementModel>(_elementsXmlFile);
            ElementManager.Instance.Init(elements);

            var players = LoadModels<PlayerModel>(_playerXmlFile);
            var bought = LoadModels<BoughtModel>(_boughtXmlFile);
            PlayerController.Instance.Init(players.First(), bought);
            
            current = this;
            
            OnLoad?.Invoke();
        }
    }

    private List<T> LoadModels<T>(TextAsset text)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        return serializer.Deserialize(new StringReader(text.text)) as List<T>;
    }

    public void SwitchScene(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.MAIN_MENU:
                PlayerController.Instance.ResetTempData();
                Cursor.visible = true;
                break;
            case Scenes.SPACE:
                Cursor.visible = false;
                break;
        }

        SceneManager.LoadSceneAsync((int) scene);
    }

    public void SwitchScene(int sceneId)
    {
        SwitchScene((Scenes) sceneId);
    }
}