using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Description")]
    public int ItemID;
    public string ItemName;
    public string ItemDescription;


    [Header("Item Attributes")]
    public bool isTasty;
    public bool isHard;
    public bool isSoft;
    public bool isShiny;
    public bool isCold;
    public bool isWarm;
    public bool isRound;
    public bool isCubic;
    public bool isPointy;
    public bool isCute;
    public bool isWet;


    // Item info: name, description, then comma-separated attributes
    public string GetTooltip()
    {
        // Item info: each piece appears on its own line.
        // Use \n to separate lines.
        string itemInfo = "";

        // Name on first line (if present)
        if (!string.IsNullOrEmpty(ItemName))
        {
            itemInfo += ItemName + "\n" + "\n";
        }

        // Description on next line (if present)
        if (!string.IsNullOrEmpty(ItemDescription))
        {
            itemInfo += ItemDescription + "\n" + "\n";
        }

        // Attributes: one per line
        if (isTasty)
        {
            itemInfo += "Tasty" + "\n";
        }

        if (isHard)
        {
            itemInfo += "Hard" + "\n";
        }

        if (isSoft)
        {
            itemInfo += "Soft" + "\n";
        }

        if (isShiny)
        {
            itemInfo += "Shiny" + "\n";
        }

        if (isCold)
        {
            itemInfo += "Cold" + "\n";
        }

        if (isWarm)
        {
            itemInfo += "Warm" + "\n";
        }

        if (isPointy)
        {
            itemInfo += "Pointy" + "\n";
        }

        if (isCute)
        {
            itemInfo += "Cute" + "\n";
        }

        if (isRound)
        {
            itemInfo += "Round" + "\n";
        }
        if (isCubic)
        {
            itemInfo += "Cubic" + "\n";
        }
        if (isWet)
        {
            itemInfo += "Wet" + "\n";
        }

        // Remove trailing newline if present
        if (itemInfo.EndsWith("\n"))
        {
            itemInfo = itemInfo.Substring(0, itemInfo.Length - 1);
        }

        return itemInfo;
    }



}
