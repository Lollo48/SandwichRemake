using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action OnNextLevel;
    
    public static Action OnLoadNextLevel;

    public static Action OnFinishGame;

    public static Action OnUndo;

    public static Action OnRestartLevel;
}
