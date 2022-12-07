using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SceneChanger()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
