using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewA : BaseView<ModelA>
{
    public override void SetModel(ModelA m)
    {
        GetComponentInChildren<Text>().text = m.label;
    }
}

public class ModelA : BaseModel
{
    public string label = "ModelA";
    public override string ToString()
    {
        return string.Format("[ModelA]");
    }
}

public abstract class BaseBaseView : MonoBehaviour
{ }
public abstract class BaseView<T> : BaseBaseView
{
    public abstract void SetModel(T m) ;
}

/// <summary>
/// InterfaceだとInstantiateできない
/// </summary>
public interface IView<T>
{ 
    void SetData(T m);
}

public class BaseModel
{
}
