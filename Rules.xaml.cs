namespace tic_tac_tor_MobileApp;

public partial class Rules : ContentPage
{
    ScrollView sv;
    Grid grid;
    public Rules()
	{
        grid = new Grid
        {
            RowSpacing = 5,//distance between rows
            ColumnSpacing = 5,//distance between columns
            Padding = new Thickness(20)
        };
        var image = new Image
        {
            Source = "cat.jpg",
            Aspect = Aspect.AspectFit
        };
        var label = new Label
        {
            Text = "Rules of Tic Tac Toe:\n\n" +
                   "1. The game is played on a 3x3 grid.\n" +
                   "2. Players take turns placing their symbol (X or O) in an empty cell.\n" +
                   "3. The first player to get three of their symbols in a row (horizontally, vertically, or diagonally) wins the game.\n" +
                   "4. If all cells are filled and no player has three in a row, the game ends in a draw.\n\n" +
                   "Enjoy playing Tic Tac Toe!",
            FontSize = 18,
            TextColor = Colors.Black
        };
        grid.Add(image, 0, 0);
        grid.Add(label, 0, 1);

        sv = new ScrollView
        {
            Content = grid
        };
        Content = sv;
    }
}