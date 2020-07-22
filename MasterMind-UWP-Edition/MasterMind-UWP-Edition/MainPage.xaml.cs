using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MasterMind_UWP_Edition {

    public sealed partial class MainPage : Page {

        //---------------------------- Constructor -------------------------------

        public MainPage() {

            this.InitializeComponent();
        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            DrawGameTitle(args);
            DrawStartButton(args);
            DrawInstructionsButton(args);
            DrawCreditsButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawGameTitle(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 50.0f
            }) {

                args.DrawingSession.DrawText("Master Mind", 250, 150, Colors.DeepPink, format);
            }
        }

        private static void DrawStartButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Start", 250, 300, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 275, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawInstructionsButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Instructions", 250, 400, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 375, 200, 55, Colors.DeepPink);
            }
        }

        private static void DrawCreditsButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 30.0f
            }) {

                args.DrawingSession.DrawText("Credits", 250, 500, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawRectangle(150, 475, 200, 55, Colors.DeepPink);
            }
        }

        //----------------------------- Button Clicks -----------------------------

        private void StartButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(MastermindGamePage));
        }

        private void InstructionsButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(InstructionsPage));
        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(CreditsPage));
        }
    }
}
