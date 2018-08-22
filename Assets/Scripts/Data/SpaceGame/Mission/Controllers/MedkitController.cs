using System;

public class MedkitController
{
    private readonly MedKitModel _model;
    private bool _pickedUp;

    public int Id => _model.id;
    public float Heal => _model.heal;
    public float X => _model.x;
    public float Y => _model.y;
    public float Z => _model.z;
    public int Score => _model.score;
    public bool IsAlive => !_pickedUp;
    
    public Action<MedkitController> OnPickup { get; set; }

    public MedkitController(MedKitModel model)
    {
        _model = model;
        _pickedUp = false;
    }

    public void Pickup()
    {
        _pickedUp = true;
        if (!IsAlive)
        {
            OnPickup?.Invoke(this);
            OnPickup = null;
        }
    }
}