using UnityEngine;

//��������A�C�e��
[CreateAssetMenu(fileName = "New Equipment Object",menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObj
{
    [SerializeField] int _offencivePower;
    [SerializeField] int _diffensivePower;
    [SerializeField] string _equipmentitemName;
    public void Awake()
    {
        _type = ItemType.Equipment;
    }
    public override void UseItem()
    {
        Debug.Log("ninnikumasimasi");
    }
}
