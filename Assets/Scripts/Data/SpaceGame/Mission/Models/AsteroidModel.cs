using System;

[Serializable]
public class AsteroidModel : IModel
{
    public int id;
    public float radius;
    public float x;
    public float y;
    public float z;
    public float speed;
    public float hp;
    public float damage;
    public int score;

    public int Id => id;
}