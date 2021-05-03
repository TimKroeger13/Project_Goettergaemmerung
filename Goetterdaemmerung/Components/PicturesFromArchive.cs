using System.Drawing;

namespace Project_Goettergaemmerung.Components
{
    public interface IPicturesFromArchive
    {
        Bitmap _action { get; set; }
        Bitmap _animal { get; set; }
        Bitmap _boarder { get; set; }
        Bitmap _class { get; set; }
        Bitmap _desaster { get; set; }
        Bitmap _dividingline { get; set; }
        Bitmap _duell { get; set; }
        Bitmap _equipment { get; set; }
        Bitmap _extra { get; set; }
        Bitmap _filter { get; set; }
        Bitmap _god { get; set; }
        Bitmap _rock { get; set; }
        Bitmap _soilder { get; set; }
        Bitmap _spell { get; set; }
        Bitmap _win { get; set; }
    }

    public class PicturesFromArchive : IPicturesFromArchive
    {
        public Bitmap _action { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\action.png");
        public Bitmap _animal { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\animal.png");
        public Bitmap _boarder { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\boarder.png");
        public Bitmap _class { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\class.png");
        public Bitmap _desaster { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\desaster.png");
        public Bitmap _duell { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\duell.png");
        public Bitmap _equipment { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\equipment.png");
        public Bitmap _extra { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\extra.png");
        public Bitmap _filter { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\filter.png");
        public Bitmap _god { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\god.png");
        public Bitmap _soilder { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\soilder.png");
        public Bitmap _spell { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\spell.png");
        public Bitmap _win { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\win.png");
        public Bitmap _rock { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\rock.png");
        public Bitmap _dividingline { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\dividingline.png");
    }
}
