using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/Cards/Data")]
public class CardData : ScriptableObject
{
    [SerializeField] private string ID;
    [SerializeField] private float lossAmount;
    [SerializeField] private int rank;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite artworkBackground;
    [SerializeField] private Sprite borderBackground;

    //Text Data
    public int GetCardRank() => rank;
    public string GetCardName() => ID.ToUpper();
    public string GetCardTottalLosses() => $"Rp. {lossAmount} TRILLION";
    public string GetYear() => $"2025 EDITION #{rank}";

    //Image Data
    public Sprite GetIcon() => icon;
    public Sprite GetBorderBackground() => borderBackground
    ;
    public Sprite GetArtworkBackground() => artworkBackground;

}
