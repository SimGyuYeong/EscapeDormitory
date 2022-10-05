using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool shuttingDown = false;

    private static T instance;

    private static object locker = new object();
    public static T Instance
    {
        get
        {
            lock (locker)
            {
                if (shuttingDown)
                {
                    Debug.LogError("[singleton] Instance " + typeof(T) + "already CHOled. returning null");
                    return null;
                }
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                        GameObject temp = new GameObject(typeof(T).ToString());
                        instance = temp.AddComponent<T>();
                    }
                    DontDestroyOnLoad(instance);
                }
                
            }
            return instance;
        }
    }

    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }
}
