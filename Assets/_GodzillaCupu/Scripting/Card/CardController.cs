using System;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [Header("Visual Components"), SerializeField] private CardVisualComponents cardVisualComponents;
    [SerializeField] private CardData cardData;

    [Serializable]
    public class CardVisualComponents
    {
        public TextMeshProUGUI cardNameText;
        public TextMeshProUGUI cardLossesText;
        public TextMeshProUGUI cardYearText;
        public Renderer cardIconRenderer;
        public Renderer cardBackgroundRenderer;
        public Renderer cardBorderBGRenderer;
        public  ImageType imageType;

        [Serializable]
        public enum ImageType { Sprite, Texture }

        public void UpdateCardVisuals(CardData data)
        {
            // Update the text components
            cardNameText.text = data.GetCardName();
            cardLossesText.text = data.GetCardTottalLosses();
            cardYearText.text = data.GetYear();

            // Update the renderers with the textures
            cardBorderBGRenderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                data.GetBorderTexture() : data.GetBorderSprite().texture;

            cardBackgroundRenderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                data.GetBackgroundTexture() : data.GetBackgroundSprite().texture;

            cardIconRenderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                    data.GetIconTexture() : data.GetIconSprite().texture;


        }
    }

    public void Start()
    {
        InitializeCard();
    }

    public void InitializeCard(CardData data)
    {
        cardData = data;
        cardVisualComponents.UpdateCardVisuals(cardData);
    }
    private void InitializeCard() => cardVisualComponents.UpdateCardVisuals(cardData);
}
