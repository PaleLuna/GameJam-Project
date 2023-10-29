using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "DefaultItemDescription", menuName = "Configs/Items/Stats")]
public class ItemDescription : ScriptableObject
{
    [FormerlySerializedAs("_name")]
    [Header("String properties")]
    [SerializeField] private string _itemName;

    [Header("Graphic properties")]
    [SerializeField] private Sprite _icon;

    public string itemName => _itemName;
    public Sprite icon => _icon;
}