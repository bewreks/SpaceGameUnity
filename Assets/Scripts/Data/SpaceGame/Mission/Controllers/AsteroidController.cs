using System;

public class AsteroidController
{
    private readonly AsteroidModel _model;
    private float _hp;
    private bool _suicide;

    public int Id => _model.id;
    public float Radius => _model.radius;
    public float X => _model.x;
    public float Y => _model.y;
    public float Z => _model.z;
    public float Speed => _model.speed;
    public float AbsSpeed => Math.Abs(_model.speed);
    public float Hp => _hp;
    public int Score => _model.score;
    public float Damage => _model.damage;
    
    public bool IsAlive => _hp >= 0;
    public bool IsSuicide => _suicide;

    public Action<AsteroidController> OnKill;
    
    public AsteroidController(AsteroidModel model)
    {
        _model = model;
        _suicide = false;
        _hp = _model.hp;
    }

    public void DoDamage(float damage)
    {
        _hp -= damage;
        if (!IsAlive)
        {
            OnKill?.Invoke(this);
            OnKill = null;
        }
    }

    public void Suicide()
    {
        _suicide = true;
        DoDamage(Hp);
    }
}