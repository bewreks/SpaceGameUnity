public class MissionManager : MainManager<MissionController, MissionModel>
{
    private static MissionManager _instance;
    
    public static MissionManager Instance => _instance ?? (_instance = new MissionManager());
    
    public override MissionController CreateControllerFromModel(MissionModel model)
    {
        var controller = new MissionController(model);
        if (controller.MissionClass == null)
        {
            controller = null;
        }
        return controller;
    }
}