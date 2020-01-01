using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XFGoogleMapsPractice
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                //東京へ移動させる
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(35.6762, 139.6503), Distance.FromKilometers(100)));

                //ピンを立てる
                var pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = "New Place",
                    Address = "Hello Tokyo",
                    Position = new Position(35.6762, 139.6503),//東京
                    Rotation = -33.3f,//ピンを傾けることができる
                    Tag = "",
                    IsDraggable=true,//これだけでピンを長押しすると移動モードになる
                };
                MyMap.Pins.Add(pin);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MyMap_MapLongClicked(object sender, MapLongClickedEventArgs e)
        {
            var pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Long Tapped",
                Address = "Added New Pin",
                Position = e.Point,//長押しした地図上の位置
                Rotation = 33.3f,
                Tag = "",
                IsDraggable = true,
            };
            MyMap.Pins.Add(pin);
        }
    }
}
