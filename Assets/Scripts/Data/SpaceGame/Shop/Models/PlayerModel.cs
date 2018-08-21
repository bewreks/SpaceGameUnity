using System;

[Serializable]
public class PlayerModel : IModel
{
    public int id;
    public string name;
    public int money;
    public int Id => id;
}