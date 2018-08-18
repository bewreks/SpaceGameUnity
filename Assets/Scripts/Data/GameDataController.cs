using System.IO;
using System.Xml.Serialization;
using Boo.Lang;
using UnityEngine;

public class GameDataController : MonoBehaviour
{

	public static GameDataController current;

	[SerializeField] private TextAsset _playerXmlFile;
	[SerializeField] private TextAsset _updatesXmlFile;
	[SerializeField] private TextAsset _elementsXmlFile;
	[SerializeField] private TextAsset _boughtXmlFile;

	private void Awake()
	{
		if (current == null)
		{
			current = this;
			var serializer = new XmlSerializer(typeof(List<UpdateModel>));
			var updates = serializer.Deserialize(new StringReader(_updatesXmlFile.text)) as List<UpdateModel>;
			UpdateManager.Init(updates);
			
			serializer = new XmlSerializer(typeof(List<ElementModel>));
			var elements = serializer.Deserialize(new StringReader(_elementsXmlFile.text)) as List<ElementModel>;
			ElementManager.Init(elements);
			
			serializer = new XmlSerializer(typeof(PlayerModel));
			var player = serializer.Deserialize(new StringReader(_playerXmlFile.text)) as PlayerModel;
			serializer = new XmlSerializer(typeof(List<BoughtModel>));
			var bought = serializer.Deserialize(new StringReader(_boughtXmlFile.text)) as List<BoughtModel>;
			PlayerController.Instance.Init(player, bought);
		}
	}
}
