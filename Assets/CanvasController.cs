using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private Text[] texts;

    private void Start()
    {
        texts = GetComponentsInChildren<Text>();
    }

    public void InfoUP()
    {

    }
}
