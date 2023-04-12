using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public class Main : ContentPage
    {
        public Main()
        {
            StackLayout stackLayout = new StackLayout { };
            Label label = new Label
            {
                Text = "Trips-Traps-Trull",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label label2 = new Label { Text = "Valige välja suurus:", FontSize = 20, Margin = new Thickness(0, 20, 0, 10) };

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(label2);

            for (int i = 3; i < 7; i++)
            {
                Button button = new Button
                {
                    Text = $"{i}x{i}",
                    FontSize = 20,
                    WidthRequest = 200,
                    HeightRequest = 100,
                    BorderWidth = 2,
                    CornerRadius = 10,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    TabIndex = i
                };
                button.Clicked += Button_Clicked;
                stackLayout.Children.Add(button);
            }

            Button themeButton = new Button
            {
                Text = "Muuda teemat",
                FontSize = 20,
                WidthRequest = 200,
                HeightRequest = 100,
                BorderWidth = 2,
                CornerRadius = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            themeButton.Clicked += ThemeButton_Clicked;
            stackLayout.Children.Add(themeButton);

            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new TicTacToe(button.TabIndex));
        }

        private void ThemeButton_Clicked(object sender, EventArgs e)
        {
            string currentTheme = Preferences.Get("theme", "light");
            if (currentTheme == "light")
            {
                Preferences.Set("theme", "dark");
            }
            else
            {
                Preferences.Set("theme", "light");
            }
        }
        
    }


}