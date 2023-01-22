using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    public readonly static LocalizationManager I;

    private StringPersistentProperty _localeKey = new StringPersistentProperty("en", "localization/current");
    private Dictionary<string, string> _localization;

    public string LocaleKey => _localeKey.Value;

    public event Action OnLocaleChanged;

    static LocalizationManager()
    {
        I = new LocalizationManager();
    }

    public LocalizationManager()
    {
        LoadLocale(_localeKey.Value);
    }

    private void LoadLocale(string localeToLoad)
    {
        var def = Resources.Load<LocalDef>($"Locales/{localeToLoad}");
        _localization = def.GetData();
        _localeKey.Value = localeToLoad;
        OnLocaleChanged?.Invoke();
    }

    public string Localize(string key)
    {
        return _localization.TryGetValue(key, out var value) ? value : $"%%%{key}%%%";
    }

    internal void SetLocale(string localeKey)
    {
        LoadLocale(localeKey);
    }
}

