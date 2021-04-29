using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components
{
    public interface ITemplateBuilder
    {
        List<Bitmap> CardTemplate(CardStructure structure, CardType type, Race race, bool extra);
    }

    public class TemplateBuilder : ITemplateBuilder
    {
        private readonly ICreatePicture _createPicture;

        public TemplateBuilder(ICreatePicture createPicture)
        {
            _createPicture = createPicture;
        }

        private Bitmap _action = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\action.png");
        private Bitmap _animal = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\animal.png");
        private Bitmap _boarder = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\boarder.png");
        private Bitmap _class = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\class.png");
        private Bitmap _desaster = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\desaster.png");
        private Bitmap _duell = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\duell.png");
        private Bitmap _equipment = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\equipment.png");
        private Bitmap _extra = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\extra.png");
        private Bitmap _filter = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\filter.png");
        private Bitmap _god = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\god.png");
        private Bitmap _soilder = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\soilder.png");
        private Bitmap _spell = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\spell.png");
        private Bitmap _win = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\win.png");
        private Bitmap _rock = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\rock.png");
        //private Bitmap _dividingline = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\dividingline.png");

        public List<Bitmap> CardTemplate(CardStructure structure, CardType type, Race race, bool extra)
        {
            List<Bitmap> bitmaplist = new List<Bitmap>();

            if (structure == CardStructure.Monster)
            {
                if (race == Race.All)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _class));
                }
                else if (race == Race.Animal)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _animal));
                }
                else if (race == Race.God)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _god));
                }
                else if (race == Race.Human)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _spell));
                }
                else if (race == Race.Monster)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _equipment));
                }
                else if (race == Race.Rock)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _rock));
                }
                else if (race == Race.Soldier)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _soilder));
                }
                else if (race == Race.Vampire)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _action));
                }

                bitmaplist.Add(_boarder);
                bitmaplist.Add(_win);

                if (extra)
                {
                    bitmaplist.Add(_extra);
                }
            }
            else if (structure == CardStructure.Normal)
            {
                if (type == CardType.Action)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _action));
                }
                else if (type == CardType.Bar || type == CardType.Class || type == CardType.Tavern)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _class));
                }
                else if (type == CardType.Blessing)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _animal));
                }
                else if (type == CardType.Companion)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _soilder));
                }
                else if (type == CardType.Disaster || type == CardType.Curse)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _desaster));
                }
                else if (type == CardType.Duell)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _duell));
                }
                else if (type == CardType.Equipment1 || type == CardType.Equipment2 || type == CardType.Equipment3)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _equipment));
                }
                else if (type == CardType.Library || type == CardType.Spell)
                {
                    bitmaplist.Add(_createPicture.BledingMultiply(_filter, _spell));
                }

                bitmaplist.Add(_boarder);

                if (extra)
                {
                    bitmaplist.Add(_extra);
                }
            }

            return bitmaplist;
        }
    }
}
