using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCD.System.TouchInjection;
using Leap;

namespace huvr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controller controller = new Controller();
            LeapListener listener = new LeapListener();

            controller.AddListener(listener);
            controller.SetPolicyFlags(Controller.PolicyFlag.POLICYBACKGROUNDFRAMES);

            TouchInjector.InitializeTouchInjection(256, TouchFeedback.INDIRECT); //initialize touch injection with num max touch points, indirect feedback to show hover position
            TouchActions.InitializeContacts();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingsWindow());

            controller.RemoveListener(listener);
            controller.Dispose();
        }
    }
}