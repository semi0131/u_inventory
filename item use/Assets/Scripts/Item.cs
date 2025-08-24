using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Block,
    Use

}

[System.Serializable]
public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isUsed = false;
        foreach (ItemEffect eft in efts)
        {
            if (eft.ExecuteRole())
            {
                isUsed = true;

                if (eft is PlaceableEft placeableEft)
                {
                    if (PlacementManger.Instance != null)
                    {
                        PlacementManger.Instance.StartPlacement(placeableEft.blockPrefab);
                    }
                }
            }
        }
        return isUsed;
    }
}
