using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public class TicTacToe : ContentPage
    {
        List<Image> images = new List<Image>();
        static Element[,] elements;
        Button buttonX;
        Button buttonO;
        bool isPlayerX = true;

        public TicTacToe(int boardSize)
        {
            string currentTheme = Preferences.Get("theme", "light");
            int boundsValue = boardSize;
            elements = new Element[boundsValue, boundsValue];
            Grid grid = new Grid();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            buttonX = new Button
            {
                Text = "X",
                FontSize = 24,
                WidthRequest = 100,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                BorderWidth = 2,
                BorderColor = Color.Black,
                Margin = 10
            };
            buttonX.Clicked += ButtonX_Clicked;
            buttonO = new Button
            {
                Text = "O",
                FontSize = 24,
                WidthRequest = 100,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                BorderWidth = 2,
                BorderColor = Color.Black,
                Margin = 10
            };
            buttonO.Clicked += ButtonO_Clicked;
            StackLayout buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    buttonX,
                    new Label { Text = "või", FontSize = 24, FontAttributes = FontAttributes.Bold, VerticalTextAlignment = TextAlignment.Center },
                    buttonO
                }
            };
            grid.Children.Add(buttonStack, 0, boundsValue, boundsValue, boundsValue + 1);

            for (int i = 0; i < boundsValue; i++)
            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int y = 0; y < boundsValue; y++)
                {
                    Frame frame = new Frame { BorderColor = Color.Black, Margin = 2 };
                    Image image = new Image();
                    image.TabIndex = 0;
                    if (currentTheme == "dark")
                    {
                        image.BackgroundColor = Color.DarkGray;
                        frame.BackgroundColor = Color.DarkGray;
                    }
                    image.GestureRecognizers.Add(tapGestureRecognizer);
                    images.Add(image);
                    frame.Content = image;
                    grid.Children.Add(frame, i, y);
                    elements[i, y] = new Element(y, i, image);
                }
            }
            Content = grid;
        }

        private void ButtonX_Clicked(object sender, EventArgs e) => isPlayerX = true;
        private void ButtonO_Clicked(object sender, EventArgs e) => isPlayerX = false;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {           
            Image image = (Image)sender;
            if (isPlayerX && image.TabIndex != 1)
            {
                image.Source = "x.png";
                image.TabIndex = 1;
                for (int y = 0; y < elements.GetLength(0); y++)
                {
                    for (int x = 0; x < elements.GetLength(0); x++)
                    {
                        if (elements[y, x].image == image)
                        {
                            elements[y, x].value = 'x';
                        }
                    }
                }
                isPlayerX = false;
            }
            else if (image.TabIndex != 1 && !isPlayerX)
            {
                image.Source = "o.png";
                image.TabIndex = 1;
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
                isPlayerX = true;
            }
            buttonO.IsEnabled = false;
            buttonX.IsEnabled = false;
            CheckWinner('0');
            CheckWinner('x');
        }

        private async void CheckWinner(char symbol) 
        {
            int length = elements.GetLength(0);            
            string diagonalLr = "";
            string diagonalRl = "";
            for (int i = 0; i < length; i++)
            {
                string vertical = "";
                string horizontal = "";
                diagonalLr += elements[i, i].value;
                diagonalRl += elements[i, length - 1 - i].value;
                for (int j = 0; j < length; j++)
                {
                    vertical += elements[i, j].value;
                    horizontal += elements[j, i].value;
                }

                if (vertical.Count(f => (f == symbol)) == length && vertical.Length == length)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                    var answer = await DisplayAlert("!!!", $"Kas alustada mängu uuesti?", "jah", "ei");
                    if (answer)
                    {
                        ResetGame();
                    }
                }
                else if (horizontal.Count(f => (f == symbol)) == length && horizontal.Length == length)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                    var answer = await DisplayAlert("!!!", $"Kas alustada mängu uuesti?", "jah", "ei");
                    if (answer)
                    {
                        ResetGame();
                    }
                }
                else if (diagonalLr.Count(f => (f == symbol)) == length && diagonalLr.Length == length)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                    var answer = await DisplayAlert("!!!", $"Kas alustada mängu uuesti?", "jah", "ei");
                    if (answer)
                    {
                        ResetGame();
                    }
                }
                else if (diagonalRl.Count(f => (f == symbol)) == length && diagonalRl.Length == length)
                {
                    await DisplayAlert("Palju õnne!", $"Võitjad: {symbol}", "ok");
                    var answer = await DisplayAlert("!!!", $"Kas alustada mängu uuesti?", "jah", "ei");
                    if (answer)
                    {
                        ResetGame();
                    }
                }
            }
        }

        private void ResetGame()
        {
            foreach (var image in images)
            {
                image.Source = null;
                image.TabIndex = 0;
            }

            for (int y = 0; y < elements.GetLength(0); y++)
            {
                for (int x = 0; x < elements.GetLength(0); x++)
                {
                    elements[y, x].value = ' ';
                }
            }
            isPlayerX = true;
            buttonO.IsEnabled = true;
            buttonX.IsEnabled = true;
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