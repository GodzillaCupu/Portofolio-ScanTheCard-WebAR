using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collections", menuName = "Scriptable Objects/Cards/Collections")]
public class CardCollections : ScriptableObject
{
    public List<CardData> data;
    public Collections collections;

    [Serializable]
    public enum CardRarity
    {
        Normal,
        Special,
        Rare,
        Legendary
    }

    [Serializable]
    public enum Collections
    {
        IndonesiaCoruptionsLegues,
        BlackJack,
        Parpol_AllStars,
    }
}
