using System.Drawing;
using Project_Goettergaemmerung.Properties;
using Project_Goettergaemmerung.Components;

namespace Project_Goettergaemmerung.Components;

public interface IPicturesFromArchive
{
    Bitmap Action();

    Bitmap Animal();

    Bitmap Boarder();

    Bitmap Class();

    Bitmap Desaster();

    Bitmap Dividingline();

    Bitmap Duell();

    Bitmap Equipment();

    Bitmap Extra();

    Bitmap Filter();

    Bitmap God();

    Bitmap Rock();

    Bitmap Scrapped();

    Bitmap Soilder();

    Bitmap Spell();

    Bitmap Win();
}

public class PicturesFromArchive : IPicturesFromArchive
{
    public Bitmap Action()
    {
        var newBitmap = new Bitmap(Resources.action);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Animal()
    {
        var newBitmap = new Bitmap(Resources.animal);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Boarder()
    {
        var newBitmap = new Bitmap(Resources.boarder);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Class()
    {
        var newBitmap = new Bitmap(Resources._class);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Desaster()
    {
        var newBitmap = new Bitmap(Resources.desaster);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Duell()
    {
        var newBitmap = new Bitmap(Resources.duell);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Equipment()
    {
        var newBitmap = new Bitmap(Resources.equipment);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Extra()
    {
        var newBitmap = new Bitmap(Resources.extra);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Filter()
    {
        var newBitmap = new Bitmap(Resources.filter);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap God()
    {
        var newBitmap = new Bitmap(Resources.god);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Soilder()
    {
        var newBitmap = new Bitmap(Resources.soilder);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Spell()
    {
        var newBitmap = new Bitmap(Resources.spell);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Win()
    {
        var newBitmap = new Bitmap(Resources.win);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Rock()
    {
        var newBitmap = new Bitmap(Resources.rock);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Dividingline()
    {
        var newBitmap = new Bitmap(Resources.dividingline);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }

    public Bitmap Scrapped()
    {
        var newBitmap = new Bitmap(Resources.scrapped);
        newBitmap.SetResolution(120, 120);
        return newBitmap;
    }
}
