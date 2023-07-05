using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//�A�C�e���V���b�v�ɕ��ԃA�C�e���̔z��
public class ShopDataBase : MonoBehaviour
{
    [Header("������A�C�e�����i�[���郊�X�g")] public List<ItemObj> _itemObjs = new List<ItemObj>();
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

