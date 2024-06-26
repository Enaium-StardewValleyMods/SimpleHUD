﻿using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using EnaiumToolKit.Framework.Utils;
using StardewValley;

namespace SimpleHUD.Framework.Screen;

public class SettingColorScreen : ScreenGui
{
    private readonly Action<ColorUtils.NameType> _select;

    public SettingColorScreen(Action<ColorUtils.NameType> select)
    {
        _select = select;
    }

    protected override void Init()
    {
        base.Init();

        foreach (var variable in ColorUtils.Instance.Colors)
        {
            AddElement(new ColorButton($"{Get("setting.textColor")}:{variable.Name}",
                Get("setting.textColor"))
            {
                Color = ColorUtils.Instance.Get(variable.Name),
                OnLeftClicked = () =>
                {
                    _select(variable.Name);
                    Game1.exitActiveMenu();
                }
            });
        }
    }


    public string Get(string key)
    {
        return ModEntry.GetInstance().Helper.Translation.Get(key);
    }
}