using UnityEngine;

//‘•”õ‚·‚éƒAƒCƒeƒ€
[CreateAssetMenu(fileName = "New Equipment Object",menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObj
{
    [SerializeField] int _offencivePower;
    [SerializeField] int _diffensivePower;
    public void Awake()
    {
        _type = ItemType.Equipment;
    }
    public override void UseItem()
    {
        var player = FindObjectOfType<Player>();
        if (player._equipped)
        {
            _itemcount++;
        }
        else
        {
            player._gunPrefab.SetActive(true);
            player._equipped = true;
            player._offencivePower = Mathf.Min(player._offencivePower + _offencivePower, player._offenciveLimit);
        }
    }
}
