using System;

[Serializable]
public class UpdateModel
{
    public int id;
    public string name;
    public string description;
    public int price;
    public int[] nextupdates;
    public int group;
    public int updatetype;
    public int updatevalue;
}