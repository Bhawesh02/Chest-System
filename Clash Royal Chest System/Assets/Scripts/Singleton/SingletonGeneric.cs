
public class SingletonGeneric<T>  where T : class,new()
{
    private T instance = null;
    public T Instance { get {
            instance ??= new();
            return instance; } }
    SingletonGeneric() { }

}