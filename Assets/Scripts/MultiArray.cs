using System;

public class MultiArray<T>
{
    public T[] values;

    public MultiArray(int size)
    {
        values = new T[size];
    }

    public int Length { get { return values.Length; } }

    public T this[int index]
    {
        get { return values[index]; }
        set { values[index] = value; }
    }
}

[Serializable]
public class MultiFloat : MultiArray<float>
{
    public MultiFloat(int size) : base(size) { }
}