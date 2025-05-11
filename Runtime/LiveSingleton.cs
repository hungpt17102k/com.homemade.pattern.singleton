namespace com.homemade.pattern.singleton
{
    public class LiveSingleton<T> : MonoSingleton<T> where T : MonoSingleton<T>
    {
        protected override void OnInit()
        {
            base.OnInit();

            DontDestroyOnLoad(gameObject);
        }

        protected override void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}