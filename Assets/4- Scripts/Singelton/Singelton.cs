using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelton <T> : MonoBehaviour where T : Singelton<T>
{


    private static T instance;

    protected virtual void Awake()
    {
        if(instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = (T) this;
            DontDestroyOnLoad(this.gameObject);
 
        }
    }
    public static T GetInstance()
    {
        return instance;
    }


}
