using System;

public abstract class BaseMission
{
    protected bool _stop = false;
    public bool IsEnd => _stop;
    
    public Action OnMissionEnd { get; set; }
    public Func<AsteroidModelIniter, AsteroidController> CreateAsteroid { set; protected get; }
    public Func<MedkitModelIniter, MedkitController> CreateMedic { set; protected get; }
    public Action<float> Waiting { set; protected get; }
    public Func<float, float, float> Random { set; protected get; }

    public void StartMission()
    {
        OnMissionStart();
        Round();
    }

    public void StopMission()
    {
        _stop = true;
        OnMissionEnd();
    }

    public void Round()
    {
        if (_stop)
        {
            return;
        }
        OnRoundStart();
    }
    
    protected abstract void OnRoundStart();
    protected abstract void OnMissionStart();
    public abstract void UpdateScore(int score);
    public abstract void OnWaitingEnd();
}