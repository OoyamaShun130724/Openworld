using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//アイテムショップに並ぶアイテムの配列
public class ShopDataBase : MonoBehaviour
{
    [Header("作ったアイテムを格納するリスト")] public List<ItemObj> _itemObjs = new List<ItemObj>();
    [SerializeField] public Text _discription;
    [SerializeField] public Image _image;
    [SerializeField] public Text _playerGold;
    private void Start()
    {
        _image.enabled = false;
    }
    public void UpdateGold()
    {
        _playerGold.text = FindObjectOfType<Player>()._gold.ToString() + "G";
    }
}

