using System.ComponentModel;

namespace Project_Goettergaemmerung.Components.Model
{
    public enum CardStructure
    {
        Normal,
        Monster
    }

    public enum CardSubType
    {
        [Description("Artifact")]
        Artifact,

        [Description("(Ausrüstung-Waffe)")]
        Weapon,

        [Description("(Ausrüstung-Rüstung)")]
        Armor,

        [Description("(Ausrüstung-Helm)")]
        Helmet,

        [Description("(Ausrüstung-Schuhe)")]
        Shoes,

        [Description("Charaktereigenschaft")]
        CharacterTrait,

        [Description("(Klasse)")]
        Class,

        [Description("(Zauber-Falle)")]
        SpellTrap,

        [Description("(Zauber-Katastrophe)")]
        SpellDisaster,

        [Description("(Zauber-Schnell)")]
        SpellFast,

        [Description("(Zauber-Normal)")]
        SpellNormal,

        [Description("(Zauber-Konter)")]
        SpellCounter,

        [Description("(Zauber-Handel)")]
        SpellTrade,

        [Description("Segen")]
        Blessing,

        [Description("Fluch")]
        Curse,

        [Description("Zwerg")]
        Dwarf,

        [Description("Oger")]
        Ogre,

        [Description("Homunkulus")]
        Homunculus,

        [Description("Goblin")]
        Goblin,

        [Description("Riese")]
        Giant,

        [Description("Dämon")]
        Demon,

        [Description("Taverne")]
        Tavern,

        [Description("Begleiter")]
        Companion,

        Empty
    }

    public enum CardType
    {
        [Description("act")]
        Action,

        [Description("mon1")]
        Monster1,

        [Description("mon2")]
        Monster2,

        [Description("mon3")]
        Monster3,

        [Description("mon4")]
        Monster4,

        [Description("mon5")]
        Monster5,

        [Description("euq1")]
        Equipment1,

        [Description("euq2")]
        Equipment2,

        [Description("euq3")]
        Equipment3,

        [Description("com")]
        Companion,

        [Description("lib")]
        Library,

        [Description("bar")]
        Bar,

        [Description("due")]
        Duell,

        [Description("cur")]
        Curse,

        [Description("ble")]
        Blessing,

        [Description("dis")]
        Disaster,

        [Description("cla")]
        Class,

        [Description("tav")]
        Tavern,

        [Description("spe")]
        Spell,

        Empty
    }

    public enum Condition
    {
        [Description("(Nur von Priestern nutzbar)")]
        OnlyPrist,

        [Description("(Nicht von Priestern nutzbar)")]
        NotPrist,

        [Description("(Nur von Bodybuildern nutzbar)")]
        OnlyBodybuilder,

        [Description("(Nicht von Bodybuildern nutzbar)")]
        NotBodybuilder,

        [Description("(Nur von Veganern nutzbar)")]
        OnlyVegan,

        [Description("(Nicht von Veganern nutzbar)")]
        NotVegan,

        [Description("(Nur von Lobbyisten nutzbar)")]
        OnlyLobbyist,

        [Description("(Nicht von Lobbyisten nutzbar)")]
        NotLobbyist,

        [Description("(Nur von Bürokraten nutzbar)")]
        OnlyBureaucrat,

        [Description("(Nicht von Bürokraten nutzbar)")]
        NotBureaucrat,

        [Description("(Nur von Vampiren nutzbar)")]
        OnlyVampire,

        [Description("(Nicht von Vampiren nutzbar)")]
        NotVampire,

        [Description("(Nur von Soldaten nutzbar)")]
        OnlySoldier,

        [Description("(Nicht von Soldaten nutzbar)")]
        NotSoldier,

        [Description("(Nur von Bürokraten und Lobbyisten nutzbar)")]
        OnlyBureaucratLobbyist,

        Empty
    }

    public enum Race
    {
        [Description("Mensch")]
        Human,

        [Description("Soldat")]
        Soldier,

        [Description("Vampir")]
        Vampire,

        [Description("Tier")]
        Animal,

        [Description("Gott")]
        God,

        [Description("Ungeheuer")]
        Monster,

        [Description("All")]
        All,

        [Description("Fels")]
        Rock,

        Empty
    }

    public enum Typography
    {
        Regular,
        Bold,
        Italic,
        LineBreak
    }
}
