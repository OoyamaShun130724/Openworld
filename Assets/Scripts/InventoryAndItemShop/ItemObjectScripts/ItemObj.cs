using UnityEngine;
using UnityEngine.UI;
//アイテムにつける基底クラス
public abstract class ItemObj : ScriptableObject
{
    //アイテムすべてに必要な変数を列挙各アイテム毎に必要な変数は継承先に記載する
    [Header("アイテムのプレハブ"),SerializeField] public Sprite _sprite;
    [Header("アイテムのタイプ")] public ItemType _type;
    [Header("値段")] public int _cost;
    [TextArea(10, 10)] public string _description;
    [SerializeField] string _itemName;
    public int _itemcount = 0;
    public string ItemName => _itemName;
    //タイプ毎に分けた先で使用時の処理を書くメソッド
    public abstract void UseItem();
}
//処理を分けたいアイテムをタイプ毎に分けて追加していく
public enum ItemType
{
    Equipment,//装備
    Consumable,//消費型
    Heal,//回復
    PowerUP,//パワーアップアイテム
    Damage,
}

