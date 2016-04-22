using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;

namespace huvr
{
    class LeapListener : Listener
    {
        //public override void OnInit(Controller cntrlr)
        //{
        //    Console.WriteLine("Initialized");
        //}

        //public override void OnConnect(Controller cntrlr)
        //{
        //    Console.WriteLine("Connected");
        //}

        //public override void OnDisconnect(Controller cntrlr)
        //{
        //    Console.WriteLine("Disconnected");
        //}

        //public override void OnExit(Controller cntrlr)
        //{
        //    Console.WriteLine("Exited");
        //}

        private long currentTime;
        private long previousTime;
        private long timeChange;

        public override void OnFrame(Controller cntrlr)
        {
            // Get the current frame.
            Frame currentFrame = cntrlr.Frame();

            currentTime = currentFrame.Timestamp;
            timeChange = currentTime - previousTime;


            if (timeChange > 1000) //0
            {

                Finger finger1 = currentFrame.Fingers[0];

                SettingsWindow.debugText[0] = "X: " + finger1.TipPosition.x.ToString() + "\n" +
                                     "Y: " + finger1.TipPosition.y.ToString() + "\n" +
                                     "Z: " + finger1.TipPosition.z.ToString() + "\n";



                switch (SettingsWindow.runMode)
                {
                    case 0:
                    if (!currentFrame.Fingers.IsEmpty)
                        TouchActions.Run(currentFrame.Fingers);
                        break;
                    case 1:
                        if (!currentFrame.Fingers.IsEmpty)
                        TouchActions.RunOne(currentFrame.Fingers);
                        break;
                    case 2:
                        if (!currentFrame.Fingers.IsEmpty)
                            TouchActions.RunTwo(currentFrame.Fingers);
                        break;
                    case 3:
                        if (!currentFrame.Tools.IsEmpty)
                            TouchActions.RunTool(currentFrame.Tools);
                        break;
                    case 4:
                        if (!currentFrame.Fingers.IsEmpty)
                        TouchActions.RunMouse(currentFrame.Fingers);
                        break;
                }
                    

                previousTime = currentTime;
            }
        }
    }
}
