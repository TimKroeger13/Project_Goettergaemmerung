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
        private Bitmap BitmapTemplate = new Bitmap(700, 1000);

        public Bitmap Action
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\action.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Action = value; }
        }
        public Bitmap Animal
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\animal.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Animal = value; }
        }
        public Bitmap Boarder
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\boarder.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Boarder = value; }
        }
        public Bitmap Class
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\class.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Class = value; }
        }
        public Bitmap Desaster
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\desaster.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Desaster = value; }
        }
        public Bitmap Duell
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\duell.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Duell = value; }
        }
        public Bitmap Equipment
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\equipment.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Equipment = value; }
        }
        public Bitmap Extra
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\extra.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Extra = value; }
        }
        public Bitmap Filter
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\filter.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Filter = value; }
        }
        public Bitmap God
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\god.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { God = value; }
        }
        public Bitmap Soilder
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\soilder.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Soilder = value; }
        }
        public Bitmap Spell
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\spell.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Spell = value; }
        }
        public Bitmap Win
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\win.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Win = value; }
        }
        public Bitmap Rock
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\rock.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Rock = value; }
        }
        public Bitmap Dividingline
        {
            get
            {
                var NewBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\dividingline.png");
                NewBitmap.SetResolution(BitmapTemplate.HorizontalResolution, BitmapTemplate.VerticalResolution);
                return NewBitmap
                ;
            }
            set { Dividingline = value; }
        }

    }
}
