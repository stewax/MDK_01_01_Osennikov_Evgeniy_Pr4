using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chess_Osennikov.Classes;

namespace Chess_Osennikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public static MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            //White
            Pawns.Add(new Classes.Pawn(0, 1, false));
            Pawns.Add(new Classes.Pawn(1, 1, false));
            Pawns.Add(new Classes.Pawn(2, 1, false));
            Pawns.Add(new Classes.Pawn(3, 1, false));
            Pawns.Add(new Classes.Pawn(4, 1, false));
            Pawns.Add(new Classes.Pawn(5, 1, false));
            Pawns.Add(new Classes.Pawn(6, 1, false));
            Pawns.Add(new Classes.Pawn(7, 1, false));
            //Black
            Pawns.Add(new Classes.Pawn(0, 6, true));
            Pawns.Add(new Classes.Pawn(1, 6, true));
            Pawns.Add(new Classes.Pawn(2, 6, true));
            Pawns.Add(new Classes.Pawn(3, 6, true));
            Pawns.Add(new Classes.Pawn(4, 6, true));
            Pawns.Add(new Classes.Pawn(5, 6, true));
            Pawns.Add(new Classes.Pawn(6, 6, true));
            Pawns.Add(new Classes.Pawn(7, 6, true));

            CreateFigure();
        }

        public void CreateFigure()
        {
            foreach (Classes.Pawn Pawn in Pawns)
            {
                Pawn.Figure = new Grid()
                {
                    Width = 50,
                    Height = 50
                };
                if(Pawn.Black)
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-a502\Desktop\Chess_Osennikov\Chess_Osennikov\Images\Pawn (black).png")));
                else
                    Pawn.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\student-a502\Desktop\Chess_Osennikov\Chess_Osennikov\Images\Pawn.png")));
                Grid.SetColumn(Pawn.Figure, Pawn.X);
                Grid.SetRow(Pawn.Figure, Pawn.Y);
                Pawn.Figure.MouseDown += Pawn.SelectFigure;
                gameBoard.Children.Add(Pawn.Figure);
            }
        }

        public void OnSelect(Classes.Pawn SelectPawn)
        {
            foreach (Classes.Pawn Pawn in Pawns)
                if (Pawn != SelectPawn)
                    if (Pawn.Select)
                        Pawn.SelectFigure(null, null);
        }

        private void SelectTile(object sender, MouseButtonEventArgs e)
        {
            Grid Tile = sender as Grid;
            int X = Grid.GetColumn(Tile);
            int Y = Grid.GetRow(Tile);
            Classes.Pawn SelectPawn = Pawns.Find(x => x.Select == true);
            if (SelectPawn != null)
            {
                SelectPawn.Transform(X, Y);
            }
        }
    }
}
