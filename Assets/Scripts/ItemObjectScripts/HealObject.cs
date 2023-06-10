using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Object", menuName = "Inventory System/Items/Heal")]
public class HealObject : ItemObj
{
    [SerializeField] int _healValue;
    public override void UseItem()
    {
        var _player = FindObjectOfType<Player>();
        if (_player._hp < _player._maxhp)
        {
            _player._hp = Mathf.Min(_player._hp + _healValue, _player._maxhp);
        }
    }
    private void Awake()
    {
        _type = ItemType.Consumable;
    }
}
