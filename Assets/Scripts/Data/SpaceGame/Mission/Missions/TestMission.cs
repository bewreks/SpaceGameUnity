public class TestMission : BaseMission
{

    protected override void OnMissionStart()
    {
        
    }
    
    protected override void OnRoundStart()
    {
        if (Random(0, 1) > 0.5f)
        {
            var asteroidController = CreateAsteroid(new AsteroidModelIniter());
            asteroidController.OnKill += OnKill;
        }
        else
        {
            var medkitController = CreateMedic(new MedkitModelIniter());
            medkitController.OnPickup += OnPickup;
        }
    }

    private void OnPickup(MedkitController obj)
    {
        Round();
    }

    private void OnKill(AsteroidController asteroid)
    {
        Round();
    }

    public override void UpdateScore(int score)
    {
    }

    public override void OnWaitingEnd()
    {
    }
}