using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Repository/Skins", fileName = "Skins")]
public class SkinRepository : DefRepository<SkinDef>
{
   
}

[Serializable]
public struct SkinDef : IHaveId
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _info;
    [SerializeField] private ItemWithCount _price;

    public string Id => _id;
    public Sprite Icon => _icon;
    public string Info => _info;
    public ItemWithCount Price => _price;


}
