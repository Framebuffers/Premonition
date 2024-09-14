//using Godot;

//namespace Premonition.Camera
//{
//}
//    //public partial class Reticle1 : Reticle
//    //{
//        //private readonly Line2D[] reticleLines = new Line2D[4];

//        //private readonly bool animatedReticle = true;
//        //private readonly float reticleSpeed = 0.5f;
//        //private readonly float reticleSpread = 4.0f;

//        ////private readonly int dotSize = 1;
//        //private Color dotColor = Colors.White;

//        //private Color lineColor = Colors.White;
//        //private readonly int lineWidth = 2;
//        ////private readonly int lineLength = 10;
//        ////private readonly int lineDistance = 5;
//        //private readonly int capMode = 0;

//        ////public override void _Process(double delta)
//        ////{
//        ////    if (Visible)
//        ////    {
//        ////        //updateReticleSettings();
//        ////        if (animatedReticle)
//        ////        {
//        ////            animateReticleLines();
//        ////        }
//        ////    }
//        ////}

//        //private void animateReticleLines()
//        //{
//        //    Vector3 velocity = character.GetRealVelocity();
//        //    Vector3 origin = Vector3.Zero;
//        //    Vector2 pos = Vector2.Zero;
//        //    float speed = origin.DistanceTo(velocity);

//        //    reticleLines[0].Position = reticleLines[0].Position.Lerp(pos + new Vector2(0, -speed * reticleSpread), reticleSpeed);
//        //    reticleLines[1].Position = reticleLines[1].Position.Lerp(pos + new Vector2(-speed * reticleSpread, 0), reticleSpeed);
//        //    reticleLines[2].Position = reticleLines[2].Position.Lerp(pos + new Vector2(speed * reticleSpread, 0), reticleSpeed);
//        //    reticleLines[3].Position = reticleLines[3].Position.Lerp(pos + new Vector2(0, speed * reticleSpread), reticleSpeed);
//        //}

//        //private void updateReticleSettings()
//        //{
//        //    Vector2 newScale = new Vector2(dot.Scale.X, dot.Scale.Y);
//        //    dot.Scale = newScale;

//        //    //Lines
//        //    foreach (Line2D line in reticleLines)
//        //    {
//        //        line.DefaultColor = lineColor;
//        //        line.Width = lineWidth;
//        //        line.BeginCapMode = capMode == 0 ? Line2D.LineCapMode.None : Line2D.LineCapMode.Round;
//        //        line.EndCapMode = capMode == 0 ? Line2D.LineCapMode.None : Line2D.LineCapMode.Round;
//        //    }
//        //}
////    }
////}

