using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effect/Add To Inventory Effect")]
public class ItemChestEft : ItemEffect
{
    public Item itemToAdd;

    public override bool ExecuteRole()
    {
        if (Inventory.instance != null && itemToAdd != null)
        {
            return Inventory.instance.AddItem(itemToAdd);
        }

        Debug.LogError("Inventory 인스턴스 또는 추가할 아이템이 설정되지 않았습니다.");
        return false;
    }
}