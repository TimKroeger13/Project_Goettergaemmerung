﻿using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface IDrawText
{
    Bitmap DrawTextASBitmap(CardStructure structure, string? name, CardSubType subType, bool twoHanded, Condition condition, string? modifiers, string? center, string? text, string? flavorText, string? scrapped,
        string? lvl, string? winText, string? loseText, Race race);
}

public class DrawText : IDrawText
{
    private readonly IDrawNormalCards _drawNormalCards;
    private readonly IDrawMonsterCards _drawMonsterCards;

    public DrawText(IDrawNormalCards drawNormalCards, IDrawMonsterCards drawMonsterCards)
    {
        _drawNormalCards = drawNormalCards;
        _drawMonsterCards = drawMonsterCards;
    }

    public Bitmap DrawTextASBitmap(CardStructure structure, string? name, CardSubType subType, bool twoHanded, Condition condition,
        string? modifiers, string? center, string? text, string? flavorText, string? scrapped,
        string? lvl, string? winText, string? loseText, Race race)
    {
        var placeholder = new Bitmap(1400, 2000);
        switch (structure)
        {
            case CardStructure.Normal:
                return _drawNormalCards.DrawTextForNormalCards(name, subType, twoHanded, condition,
        modifiers, center, text, flavorText, scrapped);

            case CardStructure.Monster:
                return _drawMonsterCards.DrawTextForMonsterCards(name, lvl, race, winText, loseText, text, flavorText);

            default:
                break;
        }

        return placeholder;
    }
}
