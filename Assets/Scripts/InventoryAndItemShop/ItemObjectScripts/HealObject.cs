using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Object", menuName = "Inventory System/Items/Heal")]
public class HealObject : ItemObj
{
    [SerializeField] int _healValue;
    public override void UseItem()
    {
        var player = FindObjectOfType<Player>();
        if (player._hp < player._maxhp)
        {
            player._hp = Mathf.Min(player._hp + _healValue, player._maxhp);
        }
    }
    private void Awake()
    {
        //_type = ItemType.Consumable;
    }
}
