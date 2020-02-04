using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frame
{
    public string GameObjectName { get; }
    public float PositionX { get; }
    public float PositionY { get; }
    public float PositionZ { get; }
    public float ScaleX { get; }
    public float ScaleY { get; }
    public float ScaleZ { get; }
    public float RotationX { get; }
    public float RotationY { get; }
    public float RotationZ { get; }
    public float RotationW { get; }
    public List<AnimationRecord> AnimationRecords { get; }

    public Frame(GameObject gameObject, Vector3 position, Vector3 scale, Quaternion rotation, List<AnimationRecord> animationRecords)
    {
        GameObjectName = GetGameObjectPath(gameObject);
        PositionX = position.x;
        PositionY = position.y;
        PositionZ = position.z;
        ScaleX = scale.x;
        ScaleY = scale.y;
        ScaleZ = scale.z;
        RotationX = rotation.x;
        RotationY = rotation.y;
        RotationZ = rotation.z;
        RotationW = rotation.w;
        AnimationRecords = animationRecords;
    }

    static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;

        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }

        return path;
    }
}
