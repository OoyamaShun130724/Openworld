using UnityEngine;
//アイテムにつける基底クラス
public abstract class ItemObj : ScriptableObject
{
    //アイテムすべてに必要な変数を列挙各アイテム毎に必要な変数は継承先に記載する
    [SerializeField] GameObject _prefab;
    [Tooltip("")] public ItemType _type;
    [Header("値段"), Tooltip("")] public int _cost;
    [TextArea(10, 10)] public string _description;
    [SerializeField] string _itemName;
    public int _itemcount = 0;
    public string ItemName => _itemName;
    //タイプ毎に分けた先で使用時の処理を書くメソッド
    public abstract void UseItem();
}
//処理を分けたいアイテムをタイプ毎に分ける
public enum ItemType
{
    Equipment,//装備
    Consumable,//消費型
    //Passive
}

