using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineEnd : MonoBehaviour //Ÿ�Ӷ��� ����� ����
{
    private Focus _focus;
    private Flicker _flicker;

    private void Awake()
    {
        _focus = GetComponent<Focus>();
        _flicker = GetComponent<Flicker>();
    }

    public void TimeLineend()
    {
        _focus.depthOfField.active = false;
        _focus.enabled = false;

        _flicker.enabled = false;
    }
}
