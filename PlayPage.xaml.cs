namespace tic_tac_tor_MobileApp;

using System.Linq;
using System.Threading.Tasks;
using System.Timers;
public partial class PlayPage : ContentPage
{
    public Grid grid, buttonsGrid, mainGreed;
    public BoxView boxView;
    public Button start, restart, whoFirst;
    public Label timeLabel, whosTurn;
    public bool isRunning = false, whoStart; //true - X | false - O
    private Timer _timer;
    public PlayPage()
    {
        {
            mainGreed = new Grid
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.FromRgb(120, 30, 50),
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }, //кнопки
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) } //поле
                },
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }

            };

            BackgroundColor = Color.FromRgb(120, 30, 50);
            grid = new Microsoft.Maui.Controls.Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(90) },
                new RowDefinition { Height = new GridLength(90) },
                new RowDefinition { Height = new GridLength(90) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(90) },
                new ColumnDefinition { Width = new GridLength(90) },
                new ColumnDefinition { Width = new GridLength(90) }
            }
            };
            for (int rida = 0; rida < 3; rida++)
            {
                for (int veerg = 0; veerg < 3; veerg++)
                {
                    boxView = new BoxView
                    {
                        Color = Colors.AliceBlue,
                        Margin = 5
                    };
                    grid.Add(boxView, veerg, rida);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    boxView.GestureRecognizers.Add(tap);
                }
            }
            buttonsGrid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(50) },
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(115) },
                new ColumnDefinition { Width = new GridLength(180) },
                new ColumnDefinition { Width = new GridLength(115) }
            },
                Margin = new Thickness(0, 20, 0, 0)
            };

            start = new Button
            {
                Text = "Start",
                FontSize = 20,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black
            };
            restart = new Button
            {
                Text = "Restart",
                FontSize = 20,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black
            };
            whoFirst = new Button
            {
                Text = "Who starts?",
                FontSize = 20,
                BackgroundColor = Color.FromRgb(200, 200, 100),
                TextColor = Colors.Black
            };

            whoFirst.Clicked += whoFirst_Clicked;
            restart.Clicked += restartGame_Clicked;
            start.Clicked += startGame_Clicked;

            whosTurn = new Label
            {
                Text = "It's random turn now",
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Colors.White,
                Margin = new Thickness(0, 30, 0, 30)
            };

            timeLabel = new Label
            {
                Text = "Time: 00:00",
                FontSize = 40,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Colors.White,
                Margin = new Thickness(0, 50, 0, 20)
            };
            buttonsGrid.Add(start, 0, 0);
            buttonsGrid.Add(restart, 2, 0);
            buttonsGrid.Add(whoFirst, 1, 0);

            mainGreed.Add(buttonsGrid, 0, 0);
            mainGreed.Add(whosTurn, 0, 1);
            mainGreed.Add(grid, 0, 2);
            mainGreed.Add(timeLabel, 0, 3);
            Content = mainGreed;
        }
    }

    private void Tap_Tapped(object? sender, TappedEventArgs e)
    {
        if (isRunning)
        {
            var box = (BoxView)sender;
            var r = Microsoft.Maui.Controls.Grid.GetRow(box);
            var v = Microsoft.Maui.Controls.Grid.GetColumn(box);

            grid.Children.Remove(box);

            var letter = new Label
            {
            };
        }
        else
        {
            DisplayAlert("Info", "Start the game", "OK");
        }
        
        
    }

    private async void whoFirst_Clicked(object sender, EventArgs e)
    {
        bool userChoce = await DisplayAlert(
            "Who is the first?",
            "Who is the first?",
            "X",
            "O"
            );
        whoStart = userChoce;

        if (whoStart)
        {
            whoFirst.Text = "X's turn";
        }else
        {
            whoFirst.Text = "O's turn";
        }
    }

    private void startGame_Clicked(object sender, EventArgs e)
    {
        //
        StartStopwatch(timeLabel);
        buttonsGrid.Children.Remove(start);
        isRunning = true;
    }

    private async void restartGame_Clicked(object sender, EventArgs e)
    {
        // Создаём новый экземпляр PlayPage
        var newPage = new PlayPage();

        // Вставляем перед текущей страницей
        Navigation.InsertPageBefore(newPage, this);

        // Убираем текущую страницу
        await Navigation.PopAsync();
    }

    private void StartStopwatch(Label label)
    {
        int secondsElapsed = 0;

        Timer timer = new Timer(1000);
        timer.Elapsed += (s, e) =>
        {
            secondsElapsed++;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TimeSpan time = TimeSpan.FromSeconds(secondsElapsed);
                label.Text = time.ToString(@"hh\:mm\:ss");
            });
        };
        timer.AutoReset = true;
        timer.Start();
    }

}