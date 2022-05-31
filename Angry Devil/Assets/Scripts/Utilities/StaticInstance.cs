using UnityEngine;

/// <summary>
/// Sinlge utility class to make any other class that inherits from this one
/// into a Static Instance. Note that this is not a Singleton as such
/// so if not carefull there will be more than one on the scene.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}