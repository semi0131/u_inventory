using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effect/Placeable Effect")]
public class PlaceableEft : ItemEffect
{
    public GameObject blockPrefab;

    public override bool ExecuteRole()
    {
        Debug.Log("블록 배치 모드에 진입했습니다. 원하는 위치를 클릭하세요.");
        return true; 
    }
}
