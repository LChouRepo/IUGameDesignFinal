using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="CoinData")]
public class Coin : ScriptableObject
{
    public int coin=0;
    public bool[] isHave;
    public int[] SceneInt;
    public int currScene = 0;
    public bool isNext;
}
