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
        public TicTacToe()
        {
            Grid grid = new Grid();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            for (int i = 0; i < 3; i++)
            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});
                for (int y = 0; y < 3; y++)
                {
                    Frame frame = new Frame { BorderColor = Color.Black };
                    Image image = new Image();
                    image.TabIndex = 0;
                    image.GestureRecognizers.Add(tapGestureRecognizer);
                    images.Add(image);
                    frame.Content = image;
                    grid.Children.Add(frame, i, y);

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
            }
            else if (image.TabIndex != 1 && mode == 1)
            {
                image.Source = "o.png";
                image.TabIndex = 1;
                mode = 0;
            }

            

        }

        private void GetResult() 
        {
            int checkItems = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i != 2 && item.TabIndex != 0)
                {

                }
            }
        }
    }
}