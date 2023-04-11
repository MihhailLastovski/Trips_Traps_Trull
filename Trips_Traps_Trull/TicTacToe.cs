using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public class TicTacToe : ContentPage
    {
        List<Image> images = new List<Image>();
        static  
        Element[,] elements;

        public TicTacToe(int boardSize)
        {
            int boundsValue = boardSize;
            elements = new Element[boundsValue, boundsValue];
            Grid grid = new Grid();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            for (int i = 0; i < boundsValue; i++)
            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int y = 0; y < boundsValue; y++)
                {
                    Frame frame = new Frame { BorderColor = Color.Black };
                    Image image = new Image();
                    image.TabIndex = 0;
                    image.GestureRecognizers.Add(tapGestureRecognizer);
                    images.Add(image);
                    frame.Content = image;
                    grid.Children.Add(frame, i, y);
                    elements[i, y] = new Element(y, i, image);

                }
            }
            Content = grid;
        }

        int mode = 0;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            if (image.TabIndex != 1 && mode == 0)
            {
                image.Source = "x.png";
                image.TabIndex = 1;
                mode = 1;
                for (int y = 0; y < elements.GetLength(0); y++)
                {
                    for (int x = 0; x < elements.GetLength(0); x++)
                    {
                        if (elements[y,x].image == image)
                        {
                            elements[y, x].value = 'x';                        
                        }
                    }
                }
            }
            else if (image.TabIndex != 1 && mode == 1)
            {
                image.Source = "o.png";
                image.TabIndex = 1;
                mode = 0;
                for (int y = 0; y < elements.GetLength(0); y++)
                {
                    for (int x = 0; x < elements.GetLength(0); x++)
                    {
                        if (elements[y, x].image == image)
                        {
                            elements[y, x].value = '0';
                        }
                    }
                }
            }
            CheckWinner('0');
            CheckWinner('x');


        }

        private async void CheckWinner(char symbol) 
        {
            int x = elements.GetLength(0);
            int y = elements.GetLength(1);
            
            string diagonalLr = "";
            string diagonalRl = "";
            for (int i = 0; i < y; i++)
            {
                string vertical = "";
                string horizontal = "";
                diagonalLr += elements[i, i].value;
                diagonalRl += elements[i, y - 1 - i].value;
                for (int j = 0; j < x; j++)
                {
                    vertical += elements[i, j].value;
                    horizontal += elements[j, i].value;
                }

                if (vertical.Count(f => (f == symbol)) == x && vertical.Length == y)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                }
                if (horizontal.Count(f => (f == symbol)) == x && horizontal.Length == y)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                }
                if (diagonalLr.Count(f => (f == symbol)) == x && diagonalLr.Length == y)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                }
                if (diagonalRl.Count(f => (f == symbol)) == x && diagonalRl.Length == y)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                }
            }
        }

        public class Element
        {
            public int x;
            public int y;
            public Image image;
            public char value = ' ';

            public Element(int x, int y, Image image) 
            {
                this.x = x;
                this.y = y;
                this.image = image;
            }
            
        }

    }
}