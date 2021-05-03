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
        private readonly IPicturesFromArchive _picturesFromArchive;

        public TemplateBuilder(ICreatePicture createPicture, IPicturesFromArchive picturesFromArchive)
        {
            _createPicture = createPicture;
            _picturesFromArchive = picturesFromArchive;
        }

        public List<Bitmap> CardTemplate(CardStructure structure, CardType type, Race race, bool extra)
        {
            List<Bitmap> bitmaplist = new List<Bitmap>();

            if (structure == CardStructure.Monster)
            {
                if (race == Race.All)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._class));
                }
                else if (race == Race.Animal)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._animal));
                }
                else if (race == Race.God)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._god));
                }
                else if (race == Race.Human)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._spell));
                }
                else if (race == Race.Monster)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._equipment));
                }
                else if (race == Race.Rock)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._rock));
                }
                else if (race == Race.Soldier)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._soilder));
                }
                else if (race == Race.Vampire)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._action));
                }

                bitmaplist.Add(_picturesFromArchive._boarder);
                bitmaplist.Add(_picturesFromArchive._win);

                if (extra)
                {
                    bitmaplist.Add(_picturesFromArchive._extra);
                }
            }
            else if (structure == CardStructure.Normal)
            {
                if (type == CardType.Action)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._action));
                }
                else if (type == CardType.Bar || type == CardType.Class || type == CardType.Tavern)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._class));
                }
                else if (type == CardType.Blessing)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._animal));
                }
                else if (type == CardType.Companion)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._soilder));
                }
                else if (type == CardType.Disaster || type == CardType.Curse)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._desaster));
                }
                else if (type == CardType.Duell)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._duell));
                }
                else if (type == CardType.Equipment1 || type == CardType.Equipment2 || type == CardType.Equipment3)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._equipment));
                }
                else if (type == CardType.Library || type == CardType.Spell)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._spell));
                }
                else if (type == CardType.Monster1 || type == CardType.Monster2 || type == CardType.Monster3 || type == CardType.Monster4 || type == CardType.Monster5)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive._filter, _picturesFromArchive._spell));
                }

                bitmaplist.Add(_picturesFromArchive._boarder);

                if (extra)
                {
                    bitmaplist.Add(_picturesFromArchive._extra);
                }
            }

            return bitmaplist;
        }
    }
}