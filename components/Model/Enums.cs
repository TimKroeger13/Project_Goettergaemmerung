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
    }

    public enum CardType
    {
        [Description("akt")]
        Action,

        [Description("mon1")]
        Monster1,

        Monster2,
        Monster3,
        Monster4,
        Monster5,
        Equipment1,
        Equipment2,
        Equipment3,
        Companion,
        Library,
        GroupAction,
        Duell,
        Curse,
        Blessing,
        Catastrophy,
        Class
    }

    public enum Condition
    {
    }

    public enum Level { }

    public enum Race { }
}
