using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataGroup<TDataType, TItemType> where TItemType : MonoBehaviour, IItemRenderer<TDataType>
{
    protected readonly List<TItemType> CreatedItems = new List<TItemType>();
    private readonly TItemType _prefab;
    private readonly Transform _container;

    public DataGroup(TItemType prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    public virtual void SetData(IList<TDataType> data)
    {
        for (var i = CreatedItems.Count; i < data.Count(); i++)
        {
            var item = Object.Instantiate(_prefab, _container);
            CreatedItems.Add(item);
        }

        for (var i = 0; i < data.Count; i++)
        {
            CreatedItems[i].SetData(data[i], i);
            CreatedItems[i].gameObject.SetActive(true);
        }

        for (var i = data.Count; i < CreatedItems.Count; i++)
        {
            CreatedItems[i].gameObject.SetActive(false);
        }
    }
}

public interface IItemRenderer<TDataType>
{
    void SetData(TDataType data, int index);
}

