using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCollections", menuName = "Scriptable Objects/Cards/Collections")]
public class CardCollections : ScriptableObject
{
    public CardColections collections;
    public List<CardData> cardDatas;

    [Serializable]
    public enum CardRarity
    {
        Normal,
        Special,
        Rare,
        Legendary
    }

    [Serializable]
    public enum CardColections
    {
        IndonesiaCoruptionsLegues,
        BlackJack,
        Parpol_AllStars,
    }
}
