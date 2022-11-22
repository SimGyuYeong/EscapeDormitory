using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Focus : MonoBehaviour //포커스를 맞췄다, 풀었다 하는 스크립트
{
    [SerializeField] private float focalLengthValue = 10f; 
    [SerializeField] private float _waitTime = 1.1f;
    [SerializeField] private float _apertureValue = 2.5f;
    [SerializeField] private GameObject Monster;
    

    private bool _isApertureUp = false;
    private bool _isFocuson = false;
    private bool _isFocusoff = false;

    [HideInInspector] public PostProcessVolume postProcess;
    [HideInInspector] public DepthOfField depthOfField;

    private void Awake()
    {
        postProcess = GetComponent<PostProcessVolume>();
        postProcess.sharedProfile.TryGetSettings<DepthOfField>(out depthOfField);
    }

    private void Start()
    {
        Monster.SetActive(false);
        depthOfField.aperture.value = 0.1f;
        depthOfField.focalLength.value = 300f;
        StartCoroutine(ApertureChangeSetting());
    }

    private IEnumerator ApertureChangeSetting()
    {
        while (true)
        {
            _isApertureUp = true;
            yield return new WaitForSeconds(_waitTime);
            _isApertureUp = false;
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private void Update()
    {
        ApertureChange();
        focusON(_isFocuson);
    }

    private void ApertureChange() //포커스 관련
    {
        if (_isApertureUp)
            depthOfField.aperture.value += _apertureValue * Time.deltaTime;
        else
            depthOfField.aperture.value -= _apertureValue * Time.deltaTime;
    }

    public void focusON(bool isfocus)
    {
        
        if(isfocus == true)
        {
            Debug.Log("초점 맞춰짐");
            depthOfField.focalLength.value -= focalLengthValue * Time.deltaTime;
            _isFocuson = true;
        }
    }
    public void focusOFF(bool isfocus)
    {
        
        if(isfocus == true)
        {
            Debug.Log("초점 풀려짐");
            depthOfField.focalLength.value += focalLengthValue * Time.deltaTime;
            _isFocusoff = true;
        }
        
    }

    public void MonsterOn()
    {
        Monster.SetActive(true);
    }
}
