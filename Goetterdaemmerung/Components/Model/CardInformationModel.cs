namespace Project_Goettergaemmerung.Components.Model;

public class CardInformationModel
{
    public long Id { get; set; }
    public CardStructure Structure { get; set; }
    public bool ExtraDeck { get; set; }
    public CardType CardType { get; set; }
    public string? Name { get; set; }
    public CardSubType SubType { get; set; }
    public bool TwoHanded { get; set; }
    public Condition Condition { get; set; }
    public string? Modifiers { get; set; }
    public string? CenterText { get; set; }
    public string? Text { get; set; }
    public string? FlavorText { get; set; }
    public string? Level { get; set; }
    public Race Race { get; set; }
    public string? WinText { get; set; }
    public string? LoseText { get; set; }
    public string? Scrapped { get; set; }
    public int Print1 { get; set; }
    public int Print2 { get; set; }
    public int Print3 { get; set; }
    public int Print4 { get; set; }
}
