namespace AbilitySystem.Scripts.Core
{
    public interface ISetup<T>
    {
        void Setup(T data);
    }
    
    public abstract class SetupData {}
}