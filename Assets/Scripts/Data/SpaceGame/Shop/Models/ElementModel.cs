using System;

[Serializable]
public class ElementModel : IModel
{
    public int id;
    public string name;
    public string description;
    public int[] upgrades;
    public int Id => id;
}