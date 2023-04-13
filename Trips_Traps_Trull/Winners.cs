using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Trips_Traps_Trull
{
    public class Winners : ContentPage
    {
        public Winners()
        {
            string fileName = "Score";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(Path.Combine(folderPath, fileName)))
            {
                string[] winnersArray = File.ReadAllLines(Path.Combine(folderPath, fileName));
                ListView listView = new ListView();
                listView.ItemsSource = winnersArray;

                Label label1 = new Label
                {
                    Text = "X/0: ",
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Margin = 15
                };

                Label label2 = new Label
                {
                    Text = "Aeg:",
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                StackLayout stackLayoutLabels = new StackLayout 
                {
                    Orientation = StackOrientation.Horizontal,
                };
                stackLayoutLabels.Children.Add(label1);
                stackLayoutLabels.Children.Add(label2);

                Content = new StackLayout
                {
                    
                    Children = {
                        stackLayoutLabels,
                        listView
                    }
                };
            }

        }
    }
}
