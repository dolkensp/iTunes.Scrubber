namespace iTunes.Scrubber.BaseClasses
{
    public abstract class SingletonBase<T> where T : class, new()
    {
        private static T _instance;
        public static T Instance
        {
            get { _instance = _instance ?? new T(); return _instance; }
            // set { _instance = value; }
        }
    }
}
