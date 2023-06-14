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
        var _player = FindObjectOfType<Player>();
        
    }
}
