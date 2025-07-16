using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardDataHandler
{
    public CardData currentCard;
    public CardCollections collections;
    [SerializeField] private List<CardData> cards = new List<CardData>();

    public void IntializedDataCollections(CardCollections collections)
    {
        if (collections.data == null && collections.data.Count < 0)
        {
            Debug.LogWarning("No card data available in the collections.");
            return;
        }

        this.collections = this.collections == null ? collections : this.collections;
        cards = SortData(this.collections.data);
    }

    public void InitializeData()
    {
        IntializedDataCollections(collections);
        RandomCardToCurrentData();
    }

    public void FirstCardToCurrentData()
    {
        if (collections.data == null && collections.data.Count <= 0)
        {
            Debug.LogWarning("No card data available to set as first card.");
            return;
        }

        cards = new List<CardData>(collections.data);
    }

    public void RandomCardToCurrentData()
    {
        if (cards == null && cards.Count <= 0)
        {
            Debug.LogWarning("No card data available to initialize.");
            return;
        }
        currentCard = GetRandomizedCardData(cards);
    }

    private CardData GetRandomizedCardData(List<CardData> data)
    {
        if (data.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, data.Count);
        return data[randomIndex];
    }

    public List<CardData> SortData(List<CardData> targetData)
    {
        List<CardData> originalData = new List<CardData>(targetData);
        List<CardData> sortedData = new List<CardData>();

        for (int i = 0; i < originalData.Count; i++)
        {
            int cardRanking = i + 1;
            CardData data = originalData.Find(x => x.GetCardRank() == cardRanking);
            if (data != null)
            {
                sortedData.Add(data);
                cardRanking++;
            }
            else
            {
                Debug.LogWarning($"Card with rank {cardRanking} not found in the original data.");
            }
        }
        return sortedData;
    }
}
