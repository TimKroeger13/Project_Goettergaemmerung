using System.Drawing;
using Project_Goettergaemmerung.Properties;
using Project_Goettergaemmerung.Components;

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
        Bitmap Scrapped { get; set; }
    }

    public class PicturesFromArchive : IPicturesFromArchive
    {
        private readonly IDisposeBitmaps<Bitmap> _disposeBitmaps;

        public PicturesFromArchive(IDisposeBitmaps<Bitmap> disposeBitmaps)
        {
            _disposeBitmaps = disposeBitmaps;
        }

        public Bitmap Action
        {
            get
            {
                var newBitmap = new Bitmap(Resources.action);
                _disposeBitmaps.DisposibelArchiveList(ref newBitmap);
                //_disposeBitmaps.Dispose();
                newBitmap.SetResolution(120, 120);
                return newBitmap
                ;
            }

            set { Action = value; }
        }

        public Bitmap Animal
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.animal);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Animal = value; }
        }

        public Bitmap Boarder
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.boarder);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Boarder = value; }
        }

        public Bitmap Class
        {
            get
            {
                var NewBitmap = new Bitmap(Resources._class);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Class = value; }
        }

        public Bitmap Desaster
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.desaster);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Desaster = value; }
        }

        public Bitmap Duell
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.duell);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Duell = value; }
        }

        public Bitmap Equipment
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.equipment);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Equipment = value; }
        }

        public Bitmap Extra
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.extra);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Extra = value; }
        }

        public Bitmap Filter
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.filter);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Filter = value; }
        }

        public Bitmap God
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.god);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { God = value; }
        }

        public Bitmap Soilder
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.soilder);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Soilder = value; }
        }

        public Bitmap Spell
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.spell);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Spell = value; }
        }

        public Bitmap Win
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.win);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Win = value; }
        }

        public Bitmap Rock
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.rock);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Rock = value; }
        }

        public Bitmap Dividingline
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.dividingline);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Dividingline = value; }
        }

        public Bitmap Scrapped
        {
            get
            {
                var NewBitmap = new Bitmap(Resources.scrapped);
                NewBitmap.SetResolution(120, 120);
                return NewBitmap
                ;
            }
            set { Scrapped = value; }
        }
    }
}
