using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PrismMauiApp.Controls;

public partial class CustomBarView : ContentView, IDisposable
{
	public CustomBarView()
	{
		InitializeComponent();
	}

    public void Dispose()
    {
        this?.Dispose();
    }
    
    public delegate void TapDelegate();
    private static List<ViewItem> _items;
    private int number;

    public static readonly BindableProperty ItemsSourceProperty =
    BindableProperty.Create(
        nameof(ItemsSource),
        typeof(IList),
        typeof(CustomBarView),
        propertyChanged: OnItemsSourceModified);

    public IList ItemsSource
    {
        get
        {
            return (IList)GetValue(ItemsSourceProperty);
        }
        set
        {
            SetValue(ItemsSourceProperty, value);
        }
    }

    public static readonly BindableProperty ItemSelectedProperty =
        BindableProperty.Create(nameof(ItemSelected), typeof(ICommand), typeof(CustomBarView), null,propertyChanged: OnItemSelectedModified);

    public ICommand ItemSelected
    {
        get
        {
            return (ICommand)GetValue(ItemSelectedProperty);
        }
        set
        {
            SetValue(ItemSelectedProperty, value);
        }
    }

    public static readonly BindableProperty BarBackgroundColorProperty =
        BindableProperty.Create(nameof(BarBackgroundColor), typeof(Color), typeof(CustomBarView), default(Color));

    public Color BarBackgroundColor
    {
        get
        {
            return (Color)GetValue(BarBackgroundColorProperty);
        }
        set
        {
            SetValue(BarBackgroundColorProperty, value);
        }
    }

    public static readonly BindableProperty BarDetailBackgroundColorProperty =
        BindableProperty.Create(nameof(BarDetailBackgroundColor), typeof(Color), typeof(CustomBarView), default(Color));

    public Color BarDetailBackgroundColor
    {
        get
        {
            return (Color)GetValue(BarDetailBackgroundColorProperty);
        }
        set
        {
            SetValue(BarDetailBackgroundColorProperty, value);
        }
    }

    private static void OnItemsSourceModified(object sender, object oldValue, object newValue)
    {
        if (!(sender is CustomBarView initialsView))
            return;

        var source = (IList)newValue;
        if (source != null)
        {
            var list = source.Cast<ViewItem>().ToList();
            _items = list;
            initialsView.SetItemsSourceValue(list);
        }

    }
    private static void OnItemSelectedModified(object sender, object oldValue, object newValue)
    {
        if (!(sender is CustomBarView initialsView))
            return;

        if (_items != null)
        {
            initialsView.SetItemSelectedValue(_items);
        }

    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        GetViewForScreen();
    }
    private void GetViewForScreen()
    {
      
    }
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

      
    }
    public event EventHandler Clicked;
    private void SetItemsSourceValue(List<ViewItem> items)
    {
        _items = items;
    }
    private void SetItemSelectedValue(List<ViewItem> items)
    {
        foreach (var item in items)
        {
            BottomTabItem tabItem = new BottomTabItem { IconImageSource = item.ImageSource, Index = items.IndexOf(item), TabItemSelected = ItemSelected };
            HorizontalStackLayout.Add(tabItem);
        }

    }

}

public class ViewItem
{
    public string Title { get; set; }
    public string ImageSource { get; set; }

}
