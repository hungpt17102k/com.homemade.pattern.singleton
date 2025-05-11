using UnityEngine;

namespace com.homemade.pattern.singleton
{
    public class MonoSingleton<T> : MonoEntity where T : MonoBehaviour
    {
        protected static T _instance = null;
        private static bool isInited;

        public static T Instance
        {
            get
            {
                if (_instance == null && !isInited)
                {
                    _instance = FindObjectOfType(typeof(T)) as T;
                    if (_instance == null)
                        _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
                return _instance;
            }
        }

        protected sealed override void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                isInited = true;
                OnInit();
            }
            else
            {
                if (Application.isPlaying)
                {
                    Destroy(gameObject);
                }
                else
                {
                    DestroyImmediate(gameObject);
                }
            }
        }

        protected virtual void OnInit()
        {

        }

        protected override void OnDestroy()
        {
            isInited = false;
        }
    }
}