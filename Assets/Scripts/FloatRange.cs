using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    [field: SerializeField] public float Min { get; private set; }
    [field: SerializeField] public float Max { get; private set; }
    public float Value => Random.Range(Min, Max);
}

[System.Serializable]
public struct IntRange
{
    [field: SerializeField] public int Min { get; private set; }
    [field: SerializeField] public int Max { get; private set; }
    public int Value => Random.Range(Min, Max);
}