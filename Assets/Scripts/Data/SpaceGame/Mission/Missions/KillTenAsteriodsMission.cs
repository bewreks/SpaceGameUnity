public class KillTenAsteriodsMission : BaseMission
{
    private int _killed;

    protected override void OnMissionStart()
    {
        _killed = 0;
    }

    protected override void OnRoundStart()
    {
        var asteroidController = CreateAsteroid(new AsteroidModelIniter
        {
            radius = Random(0.3f, 1),
            x = 19.5f,
            y = Random(-5.0f, 5.0f),
            speed = Random(-6, -3)
        });
        asteroidController.OnKill += OnKill;
        Waiting(1);
    }


    public override void UpdateScore(int score)
    {
    }

    public override void OnWaitingEnd()
    {
        Round();
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