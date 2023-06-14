using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] GameObject _inventoryLis;
    public Dictionary<int, Button> _buttonDic;
    ShopDataBase _sb;
    InventoryButton _ib;
    public void Start()
    {
        _buttonDic = new Dictionary<int, Button>();
        _sb = FindObjectOfType<ShopDataBase>();
        for (int i = 0; i <_sb._itemObjs.Count; i++)
        {
            if (_sb._itemObjs[i]._itemcount != 0)
            {
                var tmpitem = Instantiate(_button);
                tmpitem.transform.SetParent(_inventoryLis.transform);
                _buttonDic.Add(i, tmpitem);
                _ib = tmpitem.GetComponent<InventoryButton>();
                _ib._id = i;
                _ib._dataBase = _sb;
                _ib._inventory = this;
                Text str = tmpitem.GetComponentInChildren<Text>();
                str.text = _sb._itemObjs[i].ItemName + "Å~" + _sb._itemObjs[i]._itemcount;
            }
        }
    }
}

