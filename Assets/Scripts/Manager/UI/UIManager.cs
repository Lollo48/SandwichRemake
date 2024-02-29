using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static event Action OnTryUndo;
    public GameObject WinPanel;
    public Button UndoButton;


    private void Awake()
    {
        WinPanel.SetActive(false);
        UndoButton.onClick.AddListener( ()=> OnTryUndo?.Invoke());
    }

    private void OnEnable()
    {
        GameManager.OnNextLevel += ActivateNextLevelPanel;
    }



    private void ActivateNextLevelPanel()
    {
        WinPanel.SetActive(true);
    }

    public void OnNextLevel()
    {
        GameManager.OnLoadNextLevel.Invoke();
        WinPanel.SetActive(false);
    }


    private void OnDisable()
    {
        GameManager.OnNextLevel -= ActivateNextLevelPanel;

    }
}
