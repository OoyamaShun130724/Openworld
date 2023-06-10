using UnityEngine;
using UnityEngine.UI;
//データベースの何番目のアイテムのボタンが押されたか判定する
public class ShopButton : MonoBehaviour
{
    public Inventory _inventory;
    public int _id = -1;
    public int _cost = -1;
    public ShopDataBase _shopDataBase;
    public GenerateShopItemList _gsl;
    InventoryButton _ib;
    [SerializeField] Button _button;
    public void Pay()
    {
        if (_gsl._player._gold >= _cost)
        {
            _gsl._player._gold -= _cost;
            if (_inventory._buttonDic.Count == 0 || !(_inventory._buttonDic.ContainsKey(_id)))
            {                
                var tmpitem = Instantiate(_button);
                tmpitem.transform.SetParent(_gsl._InventoryTarget.transform);
                _inventory._buttonDic.Add(_id, tmpitem);
                _shopDataBase._itemObjs[_id]._itemcount++;
                _ib = tmpitem.GetComponent<InventoryButton>();
                _ib._id = _id;
                _ib._dataBase = _shopDataBase;
                _ib._inventory = _inventory;
                Text str = tmpitem.GetComponentInChildren<Text>();
                str.text = _shopDataBase._itemObjs[_id].ItemName + "×" + _shopDataBase._itemObjs[_id]._itemcount;
            }
            else
            {
                _shopDataBase._itemObjs[_id]._itemcount++;
                Text str = _inventory._buttonDic[_id].GetComponentInChildren<Text>();
                str.text = _shopDataBase._itemObjs[_id].ItemName + "×" + _shopDataBase._itemObjs[_id]._itemcount;
            }

        }
        else
        {

        }
    }
}
