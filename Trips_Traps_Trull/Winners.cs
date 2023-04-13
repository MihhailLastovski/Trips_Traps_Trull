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
            string[] winnersArray = File.ReadAllLines(Path.Combine(folderPath, fileName));
            ListView listView = new ListView();
            listView.ItemsSource = winnersArray;
            Content = new StackLayout
            {
                Children = {
                    listView
                }
            };
        }
    }
}