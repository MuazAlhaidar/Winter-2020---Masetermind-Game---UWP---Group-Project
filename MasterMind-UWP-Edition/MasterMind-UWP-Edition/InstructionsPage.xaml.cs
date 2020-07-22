using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MasterMind_UWP_Edition {

    public sealed partial class InstructionsPage : Page {

        //---------------------------- Constructor -------------------------------

        public InstructionsPage() {

            this.InitializeComponent();
        }

        //---------------------------- Win2D Stuffs ------------------------------

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {

            args.DrawingSession.DrawRectangle(10, 10, 500, 700, Colors.DeepSkyBlue);

            DrawInstructionsTitle(args);
            DrawInstructions(args);
            DrawReturnButton(args);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {


        }

        private void Canvas_Create_Resources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {


        }

        //---------------------------- Draw Elements -----------------------------

        private static void DrawInstructionsTitle(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Center,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.NoWrap,

                FontSize = 50.0f
            }) {

                args.DrawingSession.DrawText("Instructions", 250, 120, Colors.DeepPink, format);
            }
        }

        private static void DrawInstructions(CanvasAnimatedDrawEventArgs args) {

            using (CanvasTextFormat format = new CanvasTextFormat {

                HorizontalAlignment = CanvasHorizontalAlignment.Justified,
                VerticalAlignment = CanvasVerticalAlignment.Center,

                WordWrapping = CanvasWordWrapping.WholeWord,

                FontSize = 15.0f
            }) {

                args.DrawingSession.DrawText("1.   Click the start button", 80, 200, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("2.   A secret code is created using 4 pegs with a\nrandom combination of 6 colors \n(there could be 2 pegs of the same color)", 80, 250, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("3.   The player attempts to duplicate the exact colors\nand positions of the secret code", 80, 315, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("4.   Click the pegs on the first row to change their \ncolor then click the check button to \nrun the code check", 80, 380, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("5.   {0, 1, 2, 3, or 4} hint pegs will be placed in the hint\npeg holes as follows:", 80, 445, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("A.   Green hint peg indicates that a code peg of the right color\nis placed in the right position (without indication of which \nCode Peg it corresponds to)", 90, 495, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("B.   Yellow hint peg indicates that a code peg is of the right color\nbut wrong position", 90, 550, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("C.   No hint peg indicates a wrong color that does not appear\nin the secret code", 90, 590, Colors.DeepSkyBlue, format);
                args.DrawingSession.DrawText("6.   Steps 3-5 are repeated until the player either has no \nattempts left (10 attempts) or cracks the secret code", 80, 640, Colors.DeepSkyBlue, format);
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
