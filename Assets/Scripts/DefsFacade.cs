using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
public class DefsFacade : ScriptableObject
{
    [SerializeField] private ItemsRepository _items;
    [SerializeField] private PlayerDef _player;
    [SerializeField] private ThrowableRepository _throwableItems;
    [SerializeField] private PotionRepository _potions;
    [SerializeField] private PerkRepository _perks;
    [SerializeField] private SkinRepository _skins;

    public ItemsRepository Items => _items;
    public ThrowableRepository Throwable => _throwableItems;
    public PotionRepository Potions => _potions;
    public PlayerDef Player => _player;
    public PerkRepository Perks => _perks;
    public SkinRepository Skins => _skins;

    private static DefsFacade _instance;
    public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

    private static DefsFacade LoadDefs()
    {
       return _instance = Resources.Load<DefsFacade>("DefsFacade");
    }
}
