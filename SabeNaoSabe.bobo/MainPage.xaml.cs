namespace SabeNaoSabe.bobo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCallApi(object sender, EventArgs e)
        {
            var  httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://10.0.2.2:5052/api/Questionario"); 

            var data = await response.Content.ReadAsStringAsync();
        }
    }

}
