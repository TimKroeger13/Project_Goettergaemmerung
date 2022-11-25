using System.ComponentModel;

namespace Project_Goettergaemmerung.Components.Model;

public enum CardImportType
{
    CSV = 1,
    Sqlite = 2,
    NA = 0
}

public enum PrintType
{
    Print1 = 1,
    Print2 = 2,
    Print3 = 3,
    Print4 = 4
}

public enum SaveFormat
{
    normal = 1,
    tabeltop = 2,
    rebalence = 3
}

public enum CardStructure
{
    Normal = 1,
    Monster = 2
}

public enum CardSubType
{
    [Description("Magie - schwach")]
    Magie1 = 1,

    [Description("Magie - mittel")]
    Magie2 = 2,

    [Description("Magie - stark")]
    Magie3 = 3,

    [Description("Artefakt")]
    Artifact = 4,

    [Description("Merkmal")]
    Attribute = 5,

    [Description("(Ausrüstung-Waffe)")]
    Weapon = 6,

    [Description("(Ausrüstung-Rüstung)")]
    Armor = 7,

    [Description("(Ausrüstung-Helm)")]
    Helmet = 8,

    [Description("(Ausrüstung-Schuhe)")]
    Shoes = 9,

    [Description("Charaktereigenschaft")]
    CharacterTrait = 10,

    [Description("(Klasse)")]
    Class = 11,

    [Description("(apokalypse)")]
    SpellDisaster = 12,

    [Description("(Schnellzauber)")]
    SpellFast = 13,

    [Description("(Zauber)")]
    Spell = 14,

    [Description("(Handel)")]
    Trade = 15,

    [Description("Segen")]
    Blessing = 16,

    [Description("Fluch")]
    Curse = 17,

    [Description("Zwerg")]
    Dwarf = 18,

    [Description("Elf")]
    Elf = 19,

    [Description("Ork")]
    Ork = 20,

    [Description("Homunkulus")]
    Homunculus = 21,

    [Description("Goblin")]
    Goblin = 22,

    [Description("Riese")]
    Giant = 23,

    [Description("Dämon")]
    Demon = 24,

    [Description("Taverne")]
    Tavern = 25,

    [Description("Begleiter")]
    Companion = 26,

    Empty = 0,

    //rest script

    [Description("(Zauber-Hinterhalt)")]
    SpellTrap = 27,

    [Description("(Elixier)")]
    Elixier = 28,

    [Description("(Zauber-Konter)")]
    SpellCounter = 29,

    [Description("(Zauber-Ritual)")]
    SpellNormal = 30,

    [Description("(Zauber-Handel)")]
    SpellTrade = 31,
    [Description("Quest")]
    Quest = 101
}

public enum CardType
{
    [Description("ma1")]
    Magie1 = 1,

    [Description("ma2")]
    Magie2 = 2,

    [Description("ma3")]
    Magie3 = 3,

    [Description("act")]
    Action = 4,

    [Description("mon1")]
    Monster1 = 5,

    [Description("mon2")]
    Monster2 = 6,

    [Description("mon3")]
    Monster3 = 7,

    [Description("mon4")]
    Monster4 = 8,

    [Description("mon5")]
    Monster5 = 9,

    [Description("euq1")]
    Equipment1 = 10,

    [Description("euq2")]
    Equipment2 = 11,

    [Description("euq3")]
    Equipment3 = 12,

    [Description("com")]
    Companion = 13,

    [Description("lib")]
    Library = 14,

    [Description("bar")]
    Bar = 15,

    [Description("due")]
    Duell = 16,

    [Description("cur")]
    Curse = 17,

    [Description("ble")]
    Blessing = 18,

    [Description("dis")]
    Disaster = 19,

    [Description("cla")]
    Class = 20,

    [Description("tav")]
    Tavern = 21,

    [Description("spe")]
    Spell = 22,

    Empty = 0
}

public enum Condition
{
    [Description("(Nur von Priestern nutzbar)")]
    OnlyPrist = 1,

    [Description("(Nicht von Priestern nutzbar)")]
    NotPrist = 2,

    [Description("(Nur von Bodybuildern nutzbar)")]
    OnlyBodybuilder = 3,

    [Description("(Nicht von Bodybuildern nutzbar)")]
    NotBodybuilder = 4,

    [Description("(Nur von Veganern nutzbar)")]
    OnlyVegan = 5,

    [Description("(Nicht von Veganern nutzbar)")]
    NotVegan = 6,

    [Description("(Nur von Lobbyisten nutzbar)")]
    OnlyLobbyist = 7,

    [Description("(Nicht von Lobbyisten nutzbar)")]
    NotLobbyist = 8,

    [Description("(Nur von Bürokraten nutzbar)")]
    OnlyBureaucrat = 9,

    [Description("(Nicht von Bürokraten nutzbar)")]
    NotBureaucrat = 10,

    [Description("(Nur von Vampiren nutzbar)")]
    OnlyVampire = 11,

    [Description("(Nicht von Vampiren nutzbar)")]
    NotVampire = 12,

    [Description("(Nur von Soldaten nutzbar)")]
    OnlySoldier = 13,

    [Description("(Nicht von Soldaten nutzbar)")]
    NotSoldier = 14,

    [Description("(Nur von Bürokraten und Lobbyisten nutzbar)")]
    OnlyBureaucratLobbyist = 15,

    Empty = 0
}

public enum Race
{
    [Description("Mensch")]
    Human = 1,

    [Description("Soldat")]
    Soldier = 2,

    [Description("Vampir")]
    Vampire = 3,

    [Description("Tier")]
    Animal = 4,

    [Description("Gott")]
    God = 5,

    [Description("Ungeheuer")]
    Monster = 6,

    [Description("All")]
    All = 7,

    [Description("Fels")]
    Rock = 8,

    Empty = 0
}

public enum Typography
{
    Regular,
    Bold,
    Italic,
    LineBreak
}
