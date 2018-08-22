public class KillTenAsteriodsMission : BaseMission
{
    private int _killed;
    
    protected override void OnMissionStart()
    {
        _killed = 0;
    }

    protected override void OnRoundStart()
    {
        var asteroidController = CreateAsteroid(new AsteroidModelIniter());
        asteroidController.OnKill += OnKill;
        Waiting(1);
    }


    public override void UpdateScore(int score)
    {
    }

    public override void OnWaitingEnd()
    {
        if (_stop)
        {
            return;
        }
        var asteroidController = CreateAsteroid(new AsteroidModelIniter());
        asteroidController.OnKill += OnKill;
        Waiting(1);
    }

    private void OnKill(AsteroidController obj)
    {
        _killed++;
        if (_killed == 10) 
        {
            StopMission();
        }
    }
}