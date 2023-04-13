using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public class Main : ContentPage
    {
        List<string> buttonsText = new List<string> { "Võitjate nimekiri", "Muuda teemat", "Botiga mängimine" };
        

        public Main()
        {
            StackLayout stackLayout = new StackLayout {};
            Label label = new Label
            {
                Text = "Trips-Traps-Trull",
                FontSize = 30,
                FontAttributes= FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Label label2 = new Label { Text = "Valige välja suurus:", FontSize = 20, Margin = 10 };

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(label2);

            for (int i = 3; i < 7; i++)
            {
                Button button = new Button
                {
                    Text = $"{i}x{i}",
                    FontSize = 16,
                    WidthRequest = 200,
                    HeightRequest = 60,
                    BorderWidth = 3,
                    CornerRadius = 8,
                    BorderColor = Color.Black,
                    BackgroundColor = Color.Coral,
                    FontAttributes = FontAttributes.Bold,
                    Margin = 10,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    TabIndex = i
                };
                button.Clicked += Button_Clicked;
                stackLayout.Children.Add(button);
            }

            for (int i = 0; i < buttonsText.Count(); i++)
            {
                Button button = new Button 
                {
                    Text = buttonsText[i],
                    FontSize = 16,
                    WidthRequest = 200,
                    HeightRequest = 100,
                    BorderWidth = 3,
                    CornerRadius = 8,
                    BorderColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    Margin = 10,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                if (i == 1 && Preferences.Get("theme", "light") == "dark")
                {
                    button.BackgroundColor = Color.DarkGreen;
                }
                else if(i == 2 && Preferences.Get("bot", false))
                {
                    button.BackgroundColor = Color.DarkGreen;
                }
                else
                {
                    button.BackgroundColor = Color.Coral;
                }
                button.Clicked += Button_Clicked1;
                stackLayout.Children.Add(button);
            }         

            Content = stackLayout;
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string currentTheme = Preferences.Get("theme", "light");
            bool bot = Preferences.Get("bot", false);

            if (button.Text == "Võitjate nimekiri")
            {
                await Navigation.PushModalAsync(new Winners());
            }
            else if (button.Text == "Muuda teemat")
            {
                if (currentTheme == "light")
                {
                    Preferences.Set("theme", "dark");
                    button.BackgroundColor = Color.DarkGreen;
                }
                else
                {
                    Preferences.Set("theme", "light");
                    button.BackgroundColor = Color.Coral;
                }
            }
            else if (button.Text == "Botiga mängimine")
            {
                if (bot)
                {
                    Preferences.Set("bot", false);
                    button.BackgroundColor = Color.Coral;
                }
                else
                {
                    Preferences.Set("bot", true);
                    button.BackgroundColor = Color.DarkGreen;
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushModalAsync(new TicTacToe(button.TabIndex));
        }

        
    }


}