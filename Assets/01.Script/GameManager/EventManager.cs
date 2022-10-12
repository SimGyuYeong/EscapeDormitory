using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManager;

    public UnityEvent INFOUP;

    public event Action InfoUpAction;
    

    private void Awake()    
    {
        if (eventManager == null)
        {
            eventManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void InfoUP()
    {
        INFOUP?.Invoke();
    }


    //event 를 사용하는 스크립트는
    //private void OnDisabled()
    //{
    // eventmanager.변수이름     -=event
    //}

    //반대로 start 할 때 += 해주기

}
