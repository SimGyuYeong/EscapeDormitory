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

    //enter �Լ�

    //event �� ����ϴ� ��ũ��Ʈ
    //private void OnDisabled()
    //{
    // eventmanager.�����̸�     -=event
    //}

    //�ݴ�� start �� �� += ���ֱ�

}
