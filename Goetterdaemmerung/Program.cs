using Microsoft.Extensions.DependencyInjection;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using Project_Goettergaemmerung.Components.DrawText;

namespace Project_Goettergaemmerung;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();
        services.AddTransient<ICardInformationGetterFactory, CardInformationGetterFactory>();
        services.AddTransient<ICardPrinter, CardPrinter>();
        services.AddTransient<ICreatePicture, CreatePicture<Bitmap>>();
        services.AddSingleton<IUserData, UserData>();
        services.AddSingleton<ITemplateBuilder, TemplateBuilder>();
        services.AddSingleton<IPicturesFromArchive, PicturesFromArchive>();
        services.AddSingleton<IDisposableList<Bitmap>, DisposableList<Bitmap>>();
        services.AddTransient<ISplitStringInTypography, SplitStringInTypography>();
        services.AddTransient<IDrawStringWithTopograpy, DrawStringWithTopograpy>();
        services.AddTransient<IMeassureStringWithTopograpy, MeassureStringWithTopograpy>();
        services.AddTransient<IDrawNormalCards, DrawNormalCards>();
        services.AddTransient<IMeassureDrawNormalCards, MeassureDrawNormalCards>();
        services.AddTransient<IResizeFont, ResizeFont>();
        services.AddTransient<IDrawText, DrawText>();
        services.AddTransient<IDrawBoxWithTopograpy, DrawBoxWithTopograpy>();
        services.AddTransient<IMeassureBoxWithTopograpy, MeassureBoxWithTopograpy>();
        services.AddTransient<IDrawMonsterCards, DrawMonsterCards>();
        services.AddTransient<IResizeMonterFont, ResizeMonterFont>();
        services.AddTransient<IMeassureDrawMonsterCards, MeassureDrawMonsterCards>();
        services.AddTransient<ISaveImage, SaveImage>();
        services.AddTransient<ICheckIfPrintIsZero, CheckIfPrintIsZero>();

        services.AddSingleton<Form1>();
        using var provider = services.BuildServiceProvider();
        using var mainForm = provider.GetRequiredService<Form1>();
        Application.ThreadException += Application_ThreadException;
        Application.Run(mainForm);
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);
    }
}
