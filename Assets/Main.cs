using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using System;

public class Main : MonoBehaviour
{
    public int warpY = 203;
    public Button warp;

    private List<string> data = new List<string>() 
    {
        "A0", "A1", "A2" , "A3" , "A4", "A5", "A6", "A7", "A8", "A9",
        "B0", "B1", "B2" , "B3" , "B4", "B5", "B6", "B7", "B8", "B9"
    };

    public ScrollTest sc;

    void Awake()
    {
        sc.Init(data);
        warp.onClick.AddListener(() => sc.container.DOLocalMoveY(warpY, 0));
    }
}
