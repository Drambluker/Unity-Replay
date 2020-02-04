using UnityEngine;

[System.Serializable]
public class AnimationRecord
{
    public string Name { get; }
    public float Float { get; }
    public int Int { get; }
    public bool Bool { get; }
    public AnimatorControllerParameterType Type { get; }

    public AnimationRecord(string name, float value, AnimatorControllerParameterType type)
    {
        Name = name;
        Float = value;
        Type = type;
    }

    public AnimationRecord(string name, int value, AnimatorControllerParameterType type)
    {
        Name = name;
        Int = value;
        Type = type;
    }

    public AnimationRecord(string name, bool value, AnimatorControllerParameterType type)
    {
        Name = name;
        Bool = value;
        Type = type;
    }
}
