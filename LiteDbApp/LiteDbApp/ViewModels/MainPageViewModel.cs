namespace LiteDbApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string message;

        public string Message
        {
            get => this.message;
            set => this.SetProperty(ref this.message, value);
        }
    }
}