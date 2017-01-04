using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewB : BaseView<ModelB>
{
    public override void SetModel(ModelB m)
    {
        GetComponentInChildren<Text>().text = m.age.ToString();
    }
}
public class ModelB : BaseModel
{
    public int age = 18;
}