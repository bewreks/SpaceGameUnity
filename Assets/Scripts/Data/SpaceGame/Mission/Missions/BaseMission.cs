using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMission
{
    public Action<float, float, float, float> CreateAsteroid { set; protected get; }
    public Action<float, float> CreateMedic { set; protected get; }
    public Func<float, float, float> Random { set; protected get; }
    public Func<float, YieldInstruction> Waiting { set; protected get; }
    public Func<IEnumerator, Coroutine> StartCoroutine { set; protected get; }

    public abstract void StartMission();
    public abstract void UpdateScore(int score);
}