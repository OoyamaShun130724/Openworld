using UnityEngine;

//�g�����Ƃŏ�����������A�C�e��
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemObj
{
    [SerializeField] int _healValue;
    [SerializeField] int _powerUpATKValue;
    [SerializeField] int _powerUpDFNValue;
    private void Awake()
    {
        _type = ItemType.Consumable;
    }
    public override void UseItem()
    {
        Debug.Log("banana");
    }
}
