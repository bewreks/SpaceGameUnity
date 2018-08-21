using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{

    public void Start()
    {
        var missionClass = PlayerController.Instance.CurrentMission?.MissionClass??typeof(DemoMission);
        var instance = Activator.CreateInstance(missionClass);
        var mission = (BaseMission) instance;
        GameEvents.current.SCORE_CHANGED += mission.UpdateScore;
        mission.CreateAsteroid = CreateAsteroid;
        mission.CreateMedic = CreateMedic;
        mission.Waiting = Waiting;
        mission.Random = Random.Range;
        mission.StartCoroutine = StartCoroutine;
        mission.StartMission();
    }

    private YieldInstruction Waiting(float waiting)
    {
        return new WaitForSeconds(waiting);
    }

    private void CreateMedic(float x, float y)
    {
        var asteroid = MedKitPool.current.GetObject();
        var transformPosition = new Vector3(25, y, 1);
        asteroid.transform.position = transformPosition;
        asteroid.transform.rotation = transform.rotation;
        asteroid.SetActive(true);
    }

    private void CreateAsteroid(float radius, float x, float y, float speed)
    {
        var asteroid = AsteroidPool.current.GetObject();
        asteroid.transform.localScale = Vector3.one * radius;
        asteroid.GetComponent<GameObjectMover>().Speed = speed;
        var transformPosition = new Vector3(25, y, 1);
        asteroid.transform.position = transformPosition;
        asteroid.transform.rotation = transform.rotation;
        asteroid.SetActive(true);
    }
}
