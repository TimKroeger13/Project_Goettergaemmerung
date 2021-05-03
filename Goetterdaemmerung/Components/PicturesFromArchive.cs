using System.Drawing;

namespace Project_Goettergaemmerung.Components
{
    public interface IPicturesFromArchive
    {
        Bitmap Action { get; set; }
        Bitmap Animal { get; set; }
        Bitmap Boarder { get; set; }
        Bitmap Class { get; set; }
        Bitmap Desaster { get; set; }
        Bitmap Dividingline { get; set; }
        Bitmap Duell { get; set; }
        Bitmap Equipment { get; set; }
        Bitmap Extra { get; set; }
        Bitmap Filter { get; set; }
        Bitmap God { get; set; }
        Bitmap Rock { get; set; }
        Bitmap Soilder { get; set; }
        Bitmap Spell { get; set; }
        Bitmap Win { get; set; }
    }

    public class PicturesFromArchive : IPicturesFromArchive
    {
        public Bitmap Action { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\action.png");
        public Bitmap Animal { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\animal.png");
        public Bitmap Boarder { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\boarder.png");
        public Bitmap Class { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\class.png");
        public Bitmap Desaster { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\desaster.png");
        public Bitmap Duell { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\duell.png");
        public Bitmap Equipment { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\equipment.png");
        public Bitmap Extra { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\extra.png");
        public Bitmap Filter { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\filter.png");
        public Bitmap God { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\god.png");
        public Bitmap Soilder { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\soilder.png");
        public Bitmap Spell { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\spell.png");
        public Bitmap Win { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\win.png");
        public Bitmap Rock { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\rock.png");
        public Bitmap Dividingline { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\dividingline.png");
    }
}
