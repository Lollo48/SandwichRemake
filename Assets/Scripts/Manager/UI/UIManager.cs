using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static event Action<int> NewLevel;
    int index = 0;


    public void NextLevel()
    {
        
        if(index == 0)
            NewLevel.Invoke(index);
        else 
            NewLevel.Invoke(index + 1);

        index += 1;

    }








}
