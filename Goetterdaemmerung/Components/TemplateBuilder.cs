using System.Collections.Generic;
using System.Drawing;
using Project_Goettergaemmerung.Components.Model;
using System;

namespace Project_Goettergaemmerung.Components
{
    public interface ITemplateBuilder
    {
        DisposableList<Bitmap> CardTemplate(CardStructure structure, CardType type, Race race, bool extra, string name);
    }

    public class TemplateBuilder : ITemplateBuilder
    {
        private readonly ICreatePicture _createPicture;
        private readonly IPicturesFromArchive _picturesFromArchive;
        private readonly IDrawTextAsBitmap _drawTextAsBitmap;

        public TemplateBuilder(ICreatePicture createPicture, IPicturesFromArchive picturesFromArchive, IDrawTextAsBitmap drawTextAsBitmap)
        {
            _createPicture = createPicture;
            _picturesFromArchive = picturesFromArchive;
            _drawTextAsBitmap = drawTextAsBitmap;
        }

        public DisposableList<Bitmap> CardTemplate(CardStructure structure, CardType type, Race race, bool extra, string name)
        {
            var bitmaplist = new DisposableList<Bitmap>();

            switch (structure)
            {
                case CardStructure.Normal:
                    switch (type)
                    {
                        case CardType.Action:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Action));
                            break;

                        case CardType.Monster1:

                        case CardType.Monster2:

                        case CardType.Monster3:

                        case CardType.Monster4:

                        case CardType.Monster5:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                            break;

                        case CardType.Equipment1:

                        case CardType.Equipment2:

                        case CardType.Equipment3:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Equipment));
                            break;

                        case CardType.Companion:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Soilder));
                            break;

                        case CardType.Library:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                            break;

                        case CardType.Bar:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Class));
                            break;

                        case CardType.Duell:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Duell));
                            break;

                        case CardType.Curse:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Desaster));
                            break;

                        case CardType.Blessing:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Animal));
                            break;

                        case CardType.Disaster:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Desaster));
                            break;

                        case CardType.Class:

                        case CardType.Tavern:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Class));
                            break;

                        case CardType.Spell:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                            break;

                        case CardType.Empty:
                            break;
                    }
                    //bitmaplist.Add(() => _picturesFromArchive.Boarder);
                    bitmaplist.AddSingle(_picturesFromArchive.Boarder);

                    if (extra)
                    {
                        bitmaplist.Add(() => _picturesFromArchive.Extra);
                    }
                    break;

                case CardStructure.Monster:
                    switch (race)
                    {
                        case Race.Human:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Spell));
                            break;

                        case Race.Soldier:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Soilder));
                            break;

                        case Race.Vampire:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Action));
                            break;

                        case Race.Animal:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Animal));
                            break;

                        case Race.God:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.God));
                            break;

                        case Race.Monster:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Equipment));
                            break;

                        case Race.All:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Class));
                            break;

                        case Race.Rock:
                            bitmaplist.Add(() => _createPicture.BlendingMultiply(_picturesFromArchive.Filter, _picturesFromArchive.Rock));
                            break;

                        case Race.Empty:
                            break;
                    }
                    bitmaplist.Add(() =>_picturesFromArchive.Boarder);
                    bitmaplist.Add(() => _picturesFromArchive.Win);

                    if (extra)
                    {
                        bitmaplist.Add(() => _picturesFromArchive.Extra);
                    }
                    break;
            }

            bitmaplist.AddSingle(_drawTextAsBitmap.DrawText(name));

            return bitmaplist;
        }
    }
}
