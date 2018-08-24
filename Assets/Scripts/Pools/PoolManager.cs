using System;
using System.Collections.Generic;
using UnityEngine;

public enum PoolsEnum
{
    BULLET,
    ASTEROID,
    MEDKIT,
    MISSION_ITEM,
    UPGRADE_ITEM,
    EXPLOSION
}

public static class PoolManager
{
    private static Dictionary<PoolsEnum, PoolPart> _pools;
    private static GameObject _objectsParent;

    [Serializable]
    public class PoolPart
    {
        public string name;
        public PoolsEnum key;
        public PoolObject prefab;
        public ObjectPooling ferula;
        public Transform parent;
    }

    public static void Initialize(PoolPart[] newPools)
    {
        _pools = new Dictionary<PoolsEnum, PoolPart>();
        _objectsParent = new GameObject();
        _objectsParent.name = "Pool";
        
        for (int i = 0; i < newPools.Length; i++)
        {
            if (newPools[i].prefab != null)
            {
                newPools[i].ferula = new ObjectPooling();
                newPools[i].ferula.Initialize(newPools[i].prefab);
            }
            _pools.Add(newPools[i].key, newPools[i]);
        }
    }

    public static void UpdateParent(PoolsEnum key, Transform parent)
    {
        PoolPart part;
        _pools.TryGetValue(key, out part);
        if (part != null)
        {
            part.parent = parent;
        }
    }

    public static GameObject GetObject(PoolsEnum key)
    {
        PoolPart part;
        _pools.TryGetValue(key, out part);
        return part?.ferula.GetObject(part.parent ? part.parent : _objectsParent.transform).gameObject;
    }
}