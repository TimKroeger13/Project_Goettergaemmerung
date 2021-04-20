using System;
using System.Drawing;

namespace Project_Goettergaemmerung.Components.Model
{
    public class CardInformationModel
    {
        public CardStructure Structure { get; set; }
        public int Count { get; set; }
        public bool ExtraDeck { get; set; }
        public CardType CardType { get; set; }
        public string Name { get; set; }
        public CardSubType SubType { get; set; }
        public bool TwoHanded { get; set; }
        public Condition Condition { get; set; }
        public string Modifiers { get; set; }
        public string Text { get; set; }
        public string FlavorText { get; set; }
        public Level Level { get; set; }
        public Race Race { get; set; }
        public string WinText { get; set; }
        public string LoseText { get; set; }
    }
}
