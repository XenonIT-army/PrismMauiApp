using System.Windows.Input;

namespace PrismMauiApp.Controls;

public partial class BottomTabItem : ContentView
{
    public int Index { get; set; }

    public ICommand TabItemSelected { get; set; }
    public BottomTabItem()
	{
		InitializeComponent();

    }

    public static readonly BindableProperty IconImageSourceProperty =
       BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(BottomTabItem), null, propertyChanged: OnItemsSourceModified);

    public ImageSource IconImageSource
    {
        get
        {
            return (ImageSource)GetValue(IconImageSourceProperty);
        }
        set
        {
            SetValue(IconImageSourceProperty, value);
        }
    }

    private static void OnItemsSourceModified(object sender, object oldValue, object newValue)
    {
        if (!(sender is BottomTabItem initialsView))
            return;

        if (initialsView != null)
        {
            initialsView.SetValue();
        }
    }
    private void SetValue()
    {
        ImageButton.Source = IconImageSource;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (TabItemSelected != null)
            TabItemSelected.Execute(Index);
    }
}
