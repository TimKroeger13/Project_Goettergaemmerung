using System.Collections.Generic;
using System.Drawing;
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
            var bitmaplist = new List<Bitmap>();

            if (structure == CardStructure.Monster)
            {
                if (race == Race.All)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Class));
                }
                else if (race == Race.Animal)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Animal));
                }
                else if (race == Race.God)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.God));
                }
                else if (race == Race.Human)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                }
                else if (race == Race.Monster)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Equipment));
                }
                else if (race == Race.Rock)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Rock));
                }
                else if (race == Race.Soldier)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Soilder));
                }
                else if (race == Race.Vampire)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Action));
                }

                bitmaplist.Add(_picturesFromArchive.Boarder);
                bitmaplist.Add(_picturesFromArchive.Win);

                if (extra)
                {
                    bitmaplist.Add(_picturesFromArchive.Extra);
                }
            }
            else if (structure == CardStructure.Normal)
            {
                if (type == CardType.Action)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Action));
                }
                else if (type == CardType.Bar || type == CardType.Class || type == CardType.Tavern)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Class));
                }
                else if (type == CardType.Blessing)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Animal));
                }
                else if (type == CardType.Companion)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Soilder));
                }
                else if (type == CardType.Disaster || type == CardType.Curse)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Desaster));
                }
                else if (type == CardType.Duell)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Duell));
                }
                else if (type == CardType.Equipment1 || type == CardType.Equipment2 || type == CardType.Equipment3)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Equipment));
                }
                else if (type == CardType.Library || type == CardType.Spell)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                }
                else if (type == CardType.Monster1 || type == CardType.Monster2 || type == CardType.Monster3 || type == CardType.Monster4 || type == CardType.Monster5)
                {
                    bitmaplist.Add(_createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                }

                bitmaplist.Add(_picturesFromArchive.Boarder);

                if (extra)
                {
                    bitmaplist.Add(_picturesFromArchive.Extra);
                }
            }

            return bitmaplist;
        }
    }
}
