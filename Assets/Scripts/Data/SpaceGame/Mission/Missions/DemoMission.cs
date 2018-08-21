using System.Collections;

public class DemoMission : BaseMission
{
    private float _asteriodRate = 1;
    
    public override void StartMission()
    {
        StartCoroutine(Round());
    }

    private IEnumerator Round()
    {
        var isMedic = Random(0, 4) % 4 == 0;
        if (isMedic)
        {
            CreateMedic(25, Random(-5.0f, 5.0f));
        }
        else
        {
            CreateAsteroid(Random(0.3f, 1), 25, Random(-5.0f, 5.0f), Random(-6, -3));
        }
            
        yield return Waiting(1 / _asteriodRate);
        StartCoroutine(Round());
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
}