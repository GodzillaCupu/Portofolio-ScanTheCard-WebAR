using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private float tottalLosses;
    [SerializeField] private int cardRank;
    [SerializeField] private ImageData cardIcon;
    [SerializeField] private ImageData cardBackground;
    [SerializeField] private ImageData cardBorder;

    public string GetCardName() => cardName.ToUpper();
    public string GetCardTottalLosses() => $"Rp. {tottalLosses} TRILLION";
    public string GetYear() => $"2025 EDITION #{cardRank}";

    public Texture2D GetIconTexture() => cardIcon.GetTextureData();
    public Sprite GetIconSprite() => cardIcon.GetSpriteData();
    public Texture2D GetBackgroundTexture() => cardBackground.GetTextureData();
    public Sprite GetBackgroundSprite() => cardBackground.GetSpriteData();
    public Texture2D GetBorderTexture() => cardBorder.GetTextureData();
    public Sprite GetBorderSprite() => cardBorder.GetSpriteData();

    [Serializable]
    public class ImageData
    {
        [SerializeField] private Sprite cardSpirite;
        [SerializeField] private Texture2D cardImage;

        public void GetImageData(Sprite _cardSprite, Texture2D _cardImage)
        {
            if (_cardImage == null || _cardSprite != null)
            {
                _cardImage = cardImage;
                _cardSprite = cardSpirite;
            }

            cardImage = cardImage == null ? cardSpirite.texture : GetTextureData();
            cardSpirite = cardSpirite == null ? Sprite.Create(cardImage, new Rect(0, 0, cardImage.width, cardImage.height), new Vector2(0.5f, 0.5f)) : GetSpriteData();
        }

        public Sprite GetSpriteData() => cardSpirite;

        public Texture2D GetTextureData() => cardImage;
    }

}
