using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Media.Playback;
using Windows.Media.Core;

namespace MasterMind_UWP_Edition {

    public sealed partial class MastermindGamePage : Page {

        Mastermind mastermind;

        MediaPlayer songPlayer;

        //---------------------------- Constructor -------------------------------

        public MastermindGamePage() {

            this.InitializeComponent();

            songPlayer = new MediaPlayer();

            mastermind = new Mastermind();

            Window.Current.CoreWindow.PointerPressed += Canvas_Click;
        }

        //---------------------------- Music Functions ---------------------------

        private async void PlayLosingMusic() {

            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Price is Right Losing Horn.mp3");

            songPlayer.AutoPlay = false;
            songPlayer.Source = MediaSource.CreateFromStorageFile(file);

            songPlayer.Play();
        }

        private async void PlayWinningMusic() {

            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("I can't believe you done this.mp3");

            songPlayer.AutoPlay = false;
            songPlayer.Source = MediaSource.CreateFromStorageFile(file);

            songPlayer.Play();
        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            mastermind.DrawMastermind(args.DrawingSession);
            DrawCheckButton(args);
            DrawReturnButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawCheckButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Check", 400, 600, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(300, 575, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawReturnButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Return", 400, 660, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(300, 635, 200, 55, Colors.DeepPink);
            }
        }

        //----------------------------- Click Events ------------------------------

        private void CheckButton_Click(object sender, RoutedEventArgs e) {

            if (mastermind.CurrentRow < 10) {

                mastermind.CurrentRow++;

                if (mastermind.IsCorrect()) {

                    SecretCodeCoverRectangle.Opacity = 0.0;
                }
            }

            if (!mastermind.PlayerWon && mastermind.CurrentRow > 9) {

                mastermind.PlayerLoses();

                PlayLosingMusic();
            }
            else if (mastermind.PlayerWon) {

                mastermind.PlayerWins();

                PlayWinningMusic();
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(MainPage));
        }

        private void Canvas_Click(CoreWindow sender, PointerEventArgs args) {

            if (mastermind.CurrentRow < 10) {

                for (int column = 0; column < mastermind.Pegs[mastermind.CurrentRow].Count; column++) {

                    if (mastermind.Pegs[mastermind.CurrentRow][column].IsClickWithinBounds(args.CurrentPoint.Position.X, args.CurrentPoint.Position.Y)) {

                        mastermind.Pegs[mastermind.CurrentRow][column].Color = mastermind.NextColor(mastermind.Pegs[mastermind.CurrentRow][column].Color);
                    }
                }
            }
        }
    }
}
