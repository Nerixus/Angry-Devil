using UnityEngine;

/// <summary>
/// Just an utility class to make any other class that inherits from this one into
/// a Singleton.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        base.Awake();
        DontDestroyOnLoad(this);
    }
}
