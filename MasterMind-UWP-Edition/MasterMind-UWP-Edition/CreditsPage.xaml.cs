using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MasterMind_UWP_Edition {

    public sealed partial class CreditsPage : Page {

        //---------------------------- Constructor -------------------------------

        public CreditsPage() {

            this.InitializeComponent();
        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            DrawCreditsTitle(args);
            DrawCredits(args);
            DrawReturnButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawCreditsTitle(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 50.0f
            }) {

                args.DrawingSession.DrawText("Credits", 250, 120, Colors.DeepPink, format);
            }
        }

        private static void DrawCredits(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Justified,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.WholeWord,

                FontSize = 15.0f
            }) {

                args.DrawingSession.DrawText("Music:   Sath Button/ Gaming Sound Fx", 80, 200, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("Assets:   Google Images", 80, 250, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("Class:  CIS 297", 80, 315, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("Team 12.   Muaz,  Zak,  John", 80, 380, Colors.DeepSkyBlue, format);
            }
        }

        private static void DrawReturnButton(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 20.0f
            }) {

                args.DrawingSession.DrawText("Return", 400, 660, Colors.DeepSkyBlue, format);
            }
        }

        //----------------------------- Click Events ------------------------------

        private void ReturnButton_Click(object sender, RoutedEventArgs e) {

            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
