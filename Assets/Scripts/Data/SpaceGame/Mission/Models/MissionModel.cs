using System;

[Serializable]
public class MissionModel : IModel
{
    public int id;
    public int price;
    public string name;
    public string description;
    public string missionclass;
    public int Id => id;
}