using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoSingleTon<GameManager>
{
    public TMP_Text bettery;
    private int betteryAmount = 100;
    
    public int BetteryAmount
    {
        get { return betteryAmount; }
        set
        {
            betteryAmount = value;
            bettery.text = BetteryAmount.ToString() + "%";
        }
    }
    WaitForSeconds WaitForSeconds = new WaitForSeconds(5f);

    private void Start()
    {
        StartCoroutine(BetteryDown());
    }

    public IEnumerator BetteryDown()
    {
        while (true)
        {
            
            yield return WaitForSeconds;
            BetteryAmount--;



        }
    }
}
