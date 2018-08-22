using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    private BaseMission _mission;

    private int _id = 0;
    
    public void Start()
    {
        var missionClass = PlayerController.Instance.CurrentMission?.MissionClass??typeof(DemoMission);
        var instance = Activator.CreateInstance(missionClass);
        _mission = (BaseMission) instance;
        GameEvents.current.SCORE_CHANGED += _mission.UpdateScore;
        _mission.CreateAsteroid = CreateAsteroid;
        _mission.CreateMedic = CreateMedic;
        _mission.Waiting = Waiting;
        _mission.Random = Random.Range;
        _mission.StartMission();
    }

    private void Waiting(float waiting)
    {
        StartCoroutine(CoroutineWaiting(waiting));
    }

    private IEnumerator CoroutineWaiting(float waiting)
    {
        yield return new WaitForSeconds(waiting);
        _mission.OnWaitingEnd();
    }

    private MedkitController CreateMedic(MedkitModelIniter initer)
    {
        var model = new MedKitModel
        {
            id = ++_id,
            heal = 10,
            score = 100,
            x = initer.x,
            y = initer.y,
            z = 1
        };
        var medkitController = new MedkitController(model);
        var medkit = MedKitPool.current.GetObject();
        medkit.GetComponent<MedKit>().SetController(medkitController, transform.rotation);
        return medkitController;
    }

    private AsteroidController CreateAsteroid(AsteroidModelIniter initer)
    {
        var model = new AsteroidModel
        {
            id = ++_id,
            damage = 10,
            hp = 10,
            radius = initer.radius,
            speed = initer.speed,
            x = initer.x,
            y = initer.y,
            z = 1, 
            score = 100
        };

        var asteroidController = new AsteroidController(model);
        var asteroid = AsteroidPool.current.GetObject();
        asteroid.GetComponent<Asteroid>().SetController(asteroidController, transform.rotation);
        return asteroidController;
    }
}
