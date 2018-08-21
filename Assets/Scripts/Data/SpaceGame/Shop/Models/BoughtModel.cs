using System;

[Serializable]
public class BoughtModel : IModel
{
    public int id;
    public int playerid;
    public int elementid;
    public int[] upgrades;
    public int elementtype;
    public int Id => id;
}