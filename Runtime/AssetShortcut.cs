using System;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "new Shortcut", menuName = "Ligofff/Create asset shortcut")]
public class AssetShortcut : ScriptableObject
{
    [SerializeField]
    private Object obj;
    public Type Type => obj.GetType();
    
    public Object Get => obj;
    public T GetSmart<T> () where T : Object => (T)obj;
}