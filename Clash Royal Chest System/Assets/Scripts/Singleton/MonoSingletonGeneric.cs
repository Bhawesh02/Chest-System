
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    public T Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = (T)this;
        else
            Destroy(gameObject);
    }
}
