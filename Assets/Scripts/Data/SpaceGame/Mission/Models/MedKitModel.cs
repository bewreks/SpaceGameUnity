using System;

[Serializable]
public class MedKitModel : IModel
{
    public int id;
    public float heal;
    public float x;
    public float y;
    public float z;

    public int score;

    public int Id => id;
}