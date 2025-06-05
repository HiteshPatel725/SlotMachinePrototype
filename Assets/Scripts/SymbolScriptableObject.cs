using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Slot Machine/Create Symbol")]
public class SymbolScriptableObject : ScriptableObject
{
    public string symbolName;
    public Sprite icon;
    public bool isSpecial;
}
