public class UpgradeManager : MainManager<UpgradeController, UpgradeModel>
{
    private static UpgradeManager _instance;

    public static UpgradeManager Instance => _instance ?? (_instance = new UpgradeManager());

    public override UpgradeController CreateControllerFromModel(UpgradeModel model)
    {
        return new UpgradeController(model);
    }
}