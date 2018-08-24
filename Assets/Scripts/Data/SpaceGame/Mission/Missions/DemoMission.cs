public class DemoMission : BaseMission
{
    private float _asteriodRate;

    protected override void OnMissionStart()
    {
        _asteriodRate = 1;
    }

    protected override void OnRoundStart()
    {
        var random = (int)Random(0, 4);
        var isMedic = random % 4 == 0;
        if (isMedic)
        {
            CreateMedic(new MedkitModelIniter
            {
                x = 19.5f,
                y = Random(-5.0f, 5.0f),
            });
        }
        else
        {
            CreateAsteroid(new AsteroidModelIniter
            {
                radius = Random(0.3f, 1),
                x = 19.5f,
                y = Random(-5.0f, 5.0f),
                speed= Random(-6, -3)
            });
        }
            
        Waiting(1 / _asteriodRate);
    }

    public override void UpdateScore(int score)
    {
        if (score % 300 == 0)
        {
            _asteriodRate++;
        }
        
        if (score % 500 == 0)
        {
            foreach (var part in PlayerController.Instance.GetParts())
            {
                part.AddTempPower(1);
            }
        }
    }

    public override void OnWaitingEnd()
    {
        Round();
    }
}