using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//データベースの何番目のアイテムのボタンが押されたか判定する
public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory _inventory;
    public int _id = -1;
    public int _cost = -1;
    public ShopDataBase _dataBase;
    public GenerateShopItemList _gsl;
    public Player _player;
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
                _dataBase._itemObjs[_id]._itemcount++;
                _ib = tmpitem.GetComponent<InventoryButton>();
                _ib._id = _id;
                _ib._dataBase = _dataBase;
                _ib._inventory = _inventory;
                Text str = tmpitem.GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "×" + _dataBase._itemObjs[_id]._itemcount;
            }
            else
            {
                _dataBase._itemObjs[_id]._itemcount++;
                Text str = _inventory._buttonDic[_id].GetComponentInChildren<Text>();
                str.text = _dataBase._itemObjs[_id].ItemName + "×" + _dataBase._itemObjs[_id]._itemcount;
            }

        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _dataBase._discription.text = _dataBase._itemObjs[_id]._description;
        _dataBase._image.enabled = true;
        _dataBase._image.sprite = _dataBase._itemObjs[_id]._image;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _dataBase._discription.text = "";
        _dataBase._image.enabled = false;
    }
}
