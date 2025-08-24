using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;

    public override bool ExecuteRole()
    {
        if (PlayerHealth.instance == null)
        {
            Debug.LogWarning("PlayerHealth 없음!");
            return false;
        }

        bool healed = PlayerHealth.instance.Heal(healingPoint);

        if (healed)
        {
            Debug.Log("Player HP + " + healingPoint);
        }
        else
        {
            Debug.Log("이미 HP가 최대치입니다!");
        }

        return healed; 
    }
}
