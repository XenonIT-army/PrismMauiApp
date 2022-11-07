using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMauiApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        public INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }
        private bool _isNavigating = true;
        //private InternetConnectionDialogPage page;
        protected bool _isConnected;
        public bool isStartNavigate;
        protected bool IsNavigating
        {
            get => _isNavigating;
            set => SetProperty(ref _isNavigating, value);
        }
        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }
        public ViewModelBase(ISemanticScreenReader screenReader)
        {
            IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            //if (!IsConnected)
            //{
            //    GetInternetConncetionView();
            //}
        }

        protected ViewModelBase(ISemanticScreenReader screenReader,INavigationService navigationService) : this(screenReader)
        {
            NavigationService = navigationService;
        }

        protected ViewModelBase(ISemanticScreenReader screenReader, INavigationService navigationService, IEventAggregator eventAggregator) : this(screenReader,navigationService)
        {
            EventAggregator = eventAggregator;
        }

        protected ViewModelBase(ISemanticScreenReader screenReader, INavigationService navigationService, IPageDialogService pageDialogService) : this(screenReader, navigationService)
        {
            PageDialogService = pageDialogService;
        }

        protected ViewModelBase(ISemanticScreenReader screenReader, INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService) : this(screenReader, navigationService, eventAggregator)
        {
            PageDialogService = pageDialogService;
        }

        public void Destroy()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            //Device.StartTimer(TimeSpan.FromSeconds(0.1), (Func<bool>)(() =>
            //{
            //    try
            //    {
            //        isStartNavigate = true;
            //        return false;
            //    }
            //    catch
            //    {
            //        return true;
            //    }
            //}));
            IsNavigating = false;
        }

        protected Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = false)
        {
            //if (_isNavigating)
            //    return Task.CompletedTask;
            isStartNavigate = false;
            IsNavigating = true;
            try { NavigationService.NavigateAsync(name, parameters); IsNavigating = false; return Task.CompletedTask; }
            catch { return Task.CompletedTask; }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var isConnected = e.NetworkAccess;

            if (isConnected == NetworkAccess.Internet)
            {
                //if (!App.IsLoadingData)
                //{
                //    App.UpdateData();
                //}
                IsConnected = true;
                //RemoveInternetConnectionView();
            }
            else
            {
                //GetInternetConncetionView();
                IsConnected = false;
            }

        }
        //private async void GetInternetConncetionView()
        //{
        //    page = new InternetConnectionDialogPage();
        //    await PopupNavigation.Instance.PushAsync(page);
        //}
        //private async void RemoveInternetConnectionView()
        //{
        //    if (page != null)
        //        await PopupNavigation.Instance.RemovePageAsync(page);
        //}
    }

    public abstract class ViewModelToolbarBase : ViewModelBase
    {
        private DelegateCommand<object> _itemSelectionChangedCommand;
        private IList _toolbarItems;
        private int _selectedIndex;

        public IList ToolbarItems
        {
            get => _toolbarItems;
            set => SetProperty(ref _toolbarItems, value);
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }
        //protected IDialogService DialogService { get; private set; }

        public DelegateCommand<object> ItemSelectionChangedCommand =>
            _itemSelectionChangedCommand ?? (_itemSelectionChangedCommand = new DelegateCommand<object>((parameter) => ToolbarItemClicked(parameter)));


        protected ViewModelToolbarBase(ISemanticScreenReader screenReader) :
            base(screenReader)
        {
        }

        protected ViewModelToolbarBase(ISemanticScreenReader screenReader,INavigationService navigationService, IPageDialogService pageDialogService) :
            base(screenReader, navigationService, pageDialogService)
        {
        }

        //protected ViewModelToolbarBase(INavigationService navigationService, IPageDialogService pageDialogService, IDialogService dialogService) :
        //    base(navigationService, pageDialogService)
        //{
        //    DialogService = dialogService;
        //}

        protected ViewModelToolbarBase(ISemanticScreenReader screenReader,INavigationService navigationService, IEventAggregator eventAggregator, IPageDialogService pageDialogService) :
            base(screenReader, navigationService, eventAggregator, pageDialogService)
        {
        }

        protected abstract void ToolbarItemClicked(object parameter);
    }
}
