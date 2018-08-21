using System;

public class MissionController
{
    private readonly MissionModel _model;

    public int Id => _model.Id;
    public int Price => _model.price;
    public string Name => _model.name;
    public string Description => _model.description;
    public Type MissionClass => Type.GetType(_model.missionclass);

    public MissionController(MissionModel model)
    {
        _model = model;
    }
}