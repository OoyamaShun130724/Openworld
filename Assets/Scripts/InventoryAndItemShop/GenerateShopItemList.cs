using UnityEngine;
using UnityEngine.UI;

public class GenerateShopItemList : MonoBehaviour
{
    [SerializeField]public Inventory _inventory;
    ShopDataBase _dataBase;
    [SerializeField] Button _button;
    [SerializeField] GameObject _shopDataLis;
    [SerializeField] public GameObject _InventoryTarget;
    [SerializeField] public Player _player;
    ShopButton _sb;
   
    private void OnEnable()
    {
        _dataBase = GameObject.FindObjectOfType<ShopDataBase>();
        _dataBase._playerGold.text = _player._gold.ToString() + "G";
    }
    public void Start()
    {
        _inventory = GameObject.FindObjectOfType<Inventory>();
        _player = GameObject.FindObjectOfType<Player>();
        GenerateShopItemButton();
    }
    public void GenerateShopItemButton()
    {
        for (int i = 0; i < _dataBase._itemObjs.Count; i++)
        {
            var tmpitem = Instantiate(_button);
            tmpitem.transform.SetParent(_shopDataLis.transform);
            Text str = tmpitem.GetComponentInChildren<Text>();
            str.text = _dataBase._itemObjs[i].ItemName;
            _sb = tmpitem.GetComponent<ShopButton>();
            _sb._dataBase = _dataBase;
            _sb._id = i;            
            _sb._cost = _dataBase._itemObjs[i]._cost;
            _sb._gsl = this;
            _sb._inventory =_inventory;
            _sb._player = _player;
        }
    }
}
