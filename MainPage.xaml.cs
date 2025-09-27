namespace tic_tac_tor_MobileApp
{
    public partial class MainPage : ContentPage
    {
        public List<ContentPage> pagesE = new List<ContentPage>() { new PlayPage(), new LastGames(), new Rules() };
        public List<string> textsE = new List<string>() { "Play", "Last Games", "Rules" };
        ScrollView sv;
        Grid grid;
        public MainPage()
        {
            Title = "Home page Tic-Tac_Tor";
            grid = new Grid
            {
                RowSpacing = 5,//distance between rows
                ColumnSpacing = 5,//distance between columns
                Padding = new Thickness(20)
            };
            for (int i = 0; i < pagesE.Count; i++)
            {
                Button btn = new Button
                {
                    Text = textsE[i],
                    FontSize = 20,
                    BackgroundColor = Color.FromRgb(200, 200, 100),
                    TextColor = Colors.Black,
                    ZIndex = i
                };
                grid.Add(btn, 0, i);
                btn.Clicked += Btn_Clicked;
            }
            sv = new ScrollView
            {
                Content = grid
            };
            Content = sv;
        }
        private async void Btn_Clicked(object? sender, EventArgs e)
        {
            Button butn = (Button)sender;
            await Navigation.PushAsync(pagesE[butn.ZIndex]);
        }
    }
}
