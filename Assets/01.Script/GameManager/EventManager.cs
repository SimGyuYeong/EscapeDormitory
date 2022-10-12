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


    //event �� ����ϴ� ��ũ��Ʈ��
    //private void OnDisabled()
    //{
    // eventmanager.�����̸�     -=event
    //}

    //�ݴ�� start �� �� += ���ֱ�

}
