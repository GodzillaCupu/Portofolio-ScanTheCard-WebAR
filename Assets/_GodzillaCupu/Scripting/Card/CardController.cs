using System;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [Header("Visual Components"), SerializeField] public CardVisualComponents cardVisualComponents;
    [SerializeField] private CardData currentCardData;

    public CardCollections cardCollections;
    [SerializeField] private List<CardData> cardDatas = new List<CardData>();

    [Serializable]
    public class CardVisualComponents
    {
        [Serializable]
        public enum ShaderType
        {
            ShaderGraph,
            ShaderLab,
        }

        public TextMeshProUGUI cardNameText;
        public TextMeshProUGUI cardLossesText;
        public TextMeshProUGUI cardYearText;
        public Renderer cardIconRenderer;
        public ShaderType shaderType = ShaderType.ShaderLab;
        public Renderer artworkBG_Renderer;
        public Renderer borderBG_Renderer;
        public ImageType imageType;

        [Serializable]
        public enum ImageType { Sprite, Texture }

        public void UpdateCardVisuals(CardData data)
        {
            // Update the text components
            cardNameText.text = data.GetCardName();
            cardLossesText.text = data.GetCardTottalLosses();
            cardYearText.text = data.GetYear();

            // Update the renderers with the textures
            borderBG_Renderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                data.GetBorderTexture() : data.GetBorderSprite().texture;


            if (shaderType == ShaderType.ShaderGraph)
            {
                artworkBG_Renderer.material.SetTexture("_Main_Texture",
                    imageType != ImageType.Sprite ? data.GetBackgroundTexture() : data.GetBackgroundSprite().texture);
                borderBG_Renderer.material.SetTexture("_Main_Texture",
                    imageType != ImageType.Sprite ? data.GetIconTexture() : data.GetIconSprite().texture);
                return;
            }

            artworkBG_Renderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                data.GetBackgroundTexture() : data.GetBackgroundSprite().texture;

            cardIconRenderer.material.mainTexture =
                imageType != ImageType.Sprite ?
                    data.GetIconTexture() : data.GetIconSprite().texture;
        }
    }

    public void OnEnable()
    {
        InitializeCardDatas();
    }

    public void InitializeCard(CardData data)
    {
        currentCardData = data;
        cardVisualComponents.UpdateCardVisuals(currentCardData);
    }

    public void InitializeCardDatas(CardCollections collections)
    {
        cardCollections = collections;
        if (cardCollections.cardDatas != null && cardCollections.cardDatas.Count > 0)
            cardDatas = new List<CardData>(cardCollections.cardDatas);
        else Debug.LogWarning("No card data available in the collections.");

    }
    public void InitializeCardDatas()
    {
        if (cardCollections.cardDatas != null && cardCollections.cardDatas.Count > 0)
            cardDatas = new List<CardData>(cardCollections.cardDatas);
        else
            Debug.LogWarning("No card data available in the collections.");

        InitializeRandomCard();
        UpdateCardVisuals();
    }
    public void InitializeFirstCard()
    {
        if (cardDatas == null || cardDatas.Count == 0)
        {
            Debug.LogWarning("No card data available to initialize.");
            return;
        }
        currentCardData = cardDatas[0];
    }

    public void InitializeRandomCard()
    {
        if (cardDatas == null || cardDatas.Count == 0)
        {
            Debug.LogWarning("No card data available to initialize.");
            return;
        }
        currentCardData = GetRandomizedCardData(cardDatas);
    }

    public void UpdateCardVisuals()
    {
        if (currentCardData != null)
        {
            cardVisualComponents.UpdateCardVisuals(currentCardData);
        }
        else
        {
            Debug.LogWarning("Current card data is null. Cannot update visuals.");
        }
    }
    private CardData GetRandomizedCardData(List<CardData> cardDatas)
    {
        if (cardDatas.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, cardDatas.Count);
        return cardDatas[randomIndex];
    }

    public void SetOrderedCardData(List<CardData> targetDatas)
    {
        List<CardData> originalData = new List<CardData>();
        List<CardData> sortedData = new List<CardData>();

        originalData = targetDatas;

        for (int i = 0; i < originalData.Count; i++)
        {
            int cardRanking = i + 1;
            CardData _data = originalData.Find(x => x.GetCardRank() == cardRanking);
            if (_data != null)
            {
                sortedData.Add(_data);
                cardRanking++;
            }
            else
            {
                Debug.LogWarning($"Card with rank {cardRanking} not found in the original data.");
            }

            Debug.Log($"Card Name: {originalData[i].GetCardName()} | " +
                      $"Card Rank: {originalData[i].GetCardRank()} | ");
        }
        cardDatas = sortedData;
    }
    public bool isTestMode;
}
