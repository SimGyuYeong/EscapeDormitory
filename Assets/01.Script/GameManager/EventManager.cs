using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event Action ExampleEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //event invoke    
    }

    //enter 함수

    //event 를 사용하는 스크립트
    //private void OnDisabled()
    //{
    // eventmanager.변수이름     -=event
    //}

    //반대로 start 할 때 += 해주기

}
