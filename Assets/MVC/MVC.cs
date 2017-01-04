using UnityEngine;
using System.Collections;

public class MVC : MonoBehaviour
{
    public ViewA v;
    public ViewB vb;
    public BaseBaseView vb2;

    void Awake()
    {
        SetUp<ModelA>(new ModelA(), v);
        //SetUp<ModelB>(new ModelB(), vb);
    }

    void SetUp<T>(T model, BaseView<T> prefab) where T : BaseModel
    { 
        BaseView<T> i = Instantiate(prefab, transform, false) as BaseView<T>;
        i.SetModel(model);
    }
}