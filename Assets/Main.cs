using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using KappaLab.UI;


public class Main : MonoBehaviour
{
    public int warpY = 203;
    public Button warp;
    public Button resetButton;
    public Button setupButton;

    public ItemA itemAPrefab;
    public ItemB itemBPrefab;

    private List<string> data = new List<string>()
    {
        "A0", "A1", "A2" , "A3" , "A4", "A5", "A6", "A7", "A8", "A9",
        "B0", "B1", "B2" , "B3" , "B4", "B5", "B6", "B7", "B8", "B9"
    };

    private List<ItemA.Model> modelAs = new List<ItemA.Model>();
    private List<ItemB.Model> modelBs = new List<ItemB.Model>();


    public InfinityScrollView sc;

    void Awake()
    {
        int i;
        for (i = 0; i < 10; i++)
        {
            modelAs.Add(new ItemA.Model(i, "A" + i));
            modelBs.Add(new ItemB.Model(i, i));
        }
        for (i = 0; i < 10; i++)
        {
            modelAs.Add(new ItemA.Model(i, "B" + i));
            modelBs.Add(new ItemB.Model(i, i + 10));
        }
        for (i = 0; i < 9; i++)
        {
            modelAs.Add(new ItemA.Model(i, "C" + i));
            modelBs.Add(new ItemB.Model(i, i + 10));
        }

        sc.Setup(modelAs, itemAPrefab);
        //sc.Setup(modelBs, itemBPrefab);
        warp.onClick.AddListener(() => sc.JumpToY(warpY));
        resetButton.onClick.AddListener(() => sc.RemoveAllItems());
        //setupButton.onClick.AddListener(() => sc.Setup(modelAs, itemAPrefab));
        setupButton.onClick.AddListener(() => sc.Setup(modelBs, itemBPrefab,1,8,2,Vector2.zero));
    }
}
