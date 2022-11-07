using Ninject;
using PrismMauiApp.Controls;
using PrismMauiApp.Interface;
using PrismMauiApp.Model;
using PrismMauiApp.Moduls;
using System.Collections.ObjectModel;

namespace PrismMauiApp.ViewModels;

public class MainPageViewModel : ViewModelToolbarBase
{
    private ISemanticScreenReader _screenReader { get; }
 
    private int _count;
    private ObservableCollection<Word> _words;
    public ObservableCollection<Word> Words
    {
        get
        {

            return _words;
        }
        set
        {
            if (_words != value)
            {
                SetProperty(ref _words, value);
            }
        }
    }

    public MainPageViewModel(ISemanticScreenReader screenReader) : base(screenReader)
    {
        _screenReader = screenReader;
        CountCommand = new DelegateCommand(OnCountCommandExecuted);
        this.ToolbarItems = new List<ViewItem>
            {
                new ViewItem {Title="StorePage", ImageSource="prism.png"  },
                  new ViewItem { Title = "BasketPage", ImageSource = "prism.png" },
                  new ViewItem {Title="MainPage", ImageSource="prism.png" },
                  new ViewItem { Title = "OrderHistoryPage", ImageSource = "prism.png" },
                    new ViewItem {Title="UserDataPage", ImageSource="prism.png" }
            };


        GetDataFromDB();
    }

    public string Title => "Main Page";

    private string _text = "Click me";
    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand CountCommand { get; }

    private async void OnCountCommandExecuted()
    {
        _count++;
        if (_count == 1)
            Text = "Clicked 1 time";
        else if (_count > 1)
            Text = $"Clicked {_count} times";

        _screenReader.Announce(Text);

        var list = await App.AppModuls.DBServiceManager.ProductService.GetAll();
    }
    private async void GetDataFromDB()
    {
        var list = await App.AppModuls.DBServiceManager.ProductService.GetAll();
        Words = new ObservableCollection<Word>(list);
        Words.Add(new Word { Name = "test2", Translate = "тест2" });
        Words.Add(new Word { Name = "test3", Translate = "тест3" });
        Words.Add(new Word { Name = "test4", Translate = "тест4" });
        Words.Add(new Word { Name = "test5", Translate = "тест5" });
        //await App.AppModuls.DBServiceManager.ProductService.Create(new Word {Name = "test", Descriptions= "testdesc" });
        //await App.AppModuls.DBServiceManager.ProductService.Save();
    }

    protected override void ToolbarItemClicked(object parameter)
    {
        //var index = ToolbarItems.IndexOf(parameter as ViewItem);
        //if (index != SelectedIndex)
        //    switch (index)
        //    {
        //        case 0: NavigateAsync("StorePage"); break;
        //        case 1: NavigateAsync("BasketPage"); break;
        //        case 2: NavigateAsync("MainPage"); break;
        //        case 3: NavigateAsync("OrderHistoryPage"); break;
        //        case 4: NavigateAsync("UserDataPage"); break;
        //        default: break;
        //    }
    }

    Word selectedMonkey;
    public Word SelectedMonkey
    {
        get
        {
            return selectedMonkey;
        }
        set
        {
            if (selectedMonkey != value)
            {
                selectedMonkey = value;
            }
        }
    }
}
