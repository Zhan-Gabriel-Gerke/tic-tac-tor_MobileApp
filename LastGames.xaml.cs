using Microsoft.Maui.Controls;

namespace tic_tac_tor_MobileApp;

public partial class LastGames : ContentPage
{
    private Grid grid;
    private ScrollView sv;

    public LastGames()
    {
        Title = "Recent Games";

        BackgroundColor = Colors.White; // Устанавливаем фон страницы

        grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star }
            }
        };

        sv = new ScrollView
        {
            Content = grid
        };

        Content = sv;

        LoadData();
    }

    private async void LoadData()
    {
        var data = await FileManager.LoadDataFromFile();

        if (data.Count == 0)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Label label = new Label
            {
                Text = "No records",
                FontSize = 40,
                TextColor = Colors.Black
            };
            grid.Children.Add(label);
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 0);
        }
        else
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            Label labels = new Label
            {
                Text = "Data, Time, Who won, Spent Time",
                FontSize = 20,
                TextColor = Colors.Black
            };
            grid.Children.Add(labels);
            Grid.SetRow(labels, 0);
            Grid.SetColumn(labels, 0);
            for (int i = 1; i < data.Count; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Label label = new Label
                {
                    Text = data[i],
                    FontSize = 20,
                    TextColor = Colors.Black
                };

                grid.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 0);
            }
        }
    }
}
