using System;

[Serializable]
public class UpgradeModel : IModel
{
    public int id;
    public string name;
    public string description;
    public int price;
    public int[] nextupgrades;
    public int group;
    public int upgradetype;
    public int upgradevalue;
    public int Id => id;
}