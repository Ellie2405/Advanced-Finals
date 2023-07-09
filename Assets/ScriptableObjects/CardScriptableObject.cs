using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardScriptableObject", order = 1)]
[System.Serializable]
public class CardScriptableObject : ScriptableObject
{
    public Sprite graphic;
    public string cardName;
    public int numValue;
    public string Description;

}
