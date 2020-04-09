using System.Text;
using UnityEngine;

public class ConsummableItem : InventoryItem
{
    [Header("Consumable Data")]
    [SerializeField] private string m_useText = "Does something, maybe?";
    public override string GetInfoDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(Name).AppendLine();
        builder.Append("<color=green>Use: ").Append(m_useText).Append("</color>").AppendLine();
        builder.Append("Max Stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell Price: ").Append(SellPrice).Append(" Gold");

        return builder.ToString();
    }
}
