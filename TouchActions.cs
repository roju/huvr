using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCD.System.TouchInjection;
using Leap;

namespace huvr
{
    class TouchActions
    {
        public static List<TouchContact> contacts = new List<TouchContact>();
        public static PointerTouchInfo[] injector;
        public static List<PointerTouchInfo> injectorList = new List<PointerTouchInfo>();
        public static List<Finger> prevFingerList = new List<Finger>();
        public static List<int> prevFingerIDs = new List<int>();

        //public static int numContacts; // dont initialize

        //public static int multFactor = 15; //15
        //public static float touchThreshold = 65f;

        private static int rightClickTimer = 0;


        //public static bool Holding = false;
        //public static bool JustPressed = false;
        //public static bool JustReleased = false;
        //public static bool isTouching = false;

        public static bool[] Holding = { false, false, false, false, false, false, false, false, false, false};
        public static bool[] JustPressed = { false, false, false, false, false, false, false, false, false, false};
        public static bool[] JustReleased = { false, false, false, false, false, false, false, false, false, false};
        public static bool[] isTouching = { false, false, false, false, false, false, false, false, false, false};



        public static void InitializeContacts()
        {

            int numInjectors = 10; // max number of touch points

            if (numInjectors > 0)
            {
                for (int i = 0; i <= numInjectors - 1; i++)
                {
                    injectorList.Add(MakePointerTouchInfo(0, 0, (uint)i));
                }
                injector = injectorList.ToArray();
                injectorList.Clear();
            }
        }



        public static int numActiveContacts()
        {
            return contacts.Count;
        }



        public static void Run(FingerList Fingers)
        {
            List<Finger> sortedFingers = Fingers.OrderBy(Finger => Finger.TimeVisible).ToList();
            sortedFingers.Reverse();

            List<TouchContact> updatedContacts = new List<TouchContact>();
            List<PointerTouchInfo> toInject = new List<PointerTouchInfo>();

            for (int i = 0; i <= sortedFingers.Count - 1; i++)
            {
                int ID = sortedFingers[i].Id;
                int xPos = (int)(sortedFingers[i].TipPosition.x * Properties.Settings.Default.TouchCursorSpeed) + 1000; //1000
                int yPos = -(int)(sortedFingers[i].TipPosition.y * Properties.Settings.Default.TouchCursorSpeed) + 3300; // speed 15: add 2500
                float zPos = sortedFingers[i].TipPosition.z;

                updatedContacts.Add(new TouchContact(xPos, yPos, zPos, ID));

                int foundIndex = contacts.FindIndex(TouchContact => TouchContact.ID == updatedContacts[i].ID);
                if (foundIndex >= 0) //a matching ID was found
                {
                    //transfer the data to the updated contacts
                    updatedContacts[i].Holding = contacts[foundIndex].Holding;
                    updatedContacts[i].JustPressed = contacts[foundIndex].JustPressed;
                    updatedContacts[i].JustReleased = contacts[foundIndex].JustReleased;
                }
            }
            // sort the contacts by ID so they keep consistent indexes over time
            //contacts = updatedContacts.OrderBy(TouchContact => TouchContact.ID).ToList();
            contacts = updatedContacts;


            for (int i = 0; i <= sortedFingers.Count - 1; i++)
            {
                PointerTouchInfo touchPoint = MakePointerTouchInfo(contacts[i].PosX, contacts[i].PosY, (uint)contacts[i].ID);

                if (i <= injector.Length - 1)
                {
                    //injector[i].PointerInfo.PointerId = (uint)contacts[i].ID;

                    if (contacts[i].PosZ < Properties.Settings.Default.TouchThreshold && contacts[i].Holding == false) // pressed
                    {
                        contacts[i].JustPressed = true;
                        contacts[i].Holding = true;
                    }

                    if (contacts[i].PosZ > Properties.Settings.Default.TouchThreshold && contacts[i].Holding == true) // released
                    {
                        contacts[i].JustReleased = true;
                        contacts[i].Holding = false;
                    }


                    if (contacts[i].JustPressed)
                    {
                        contacts[i].JustPressed = false;
                        touchPoint.PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    }
                    else if (contacts[i].JustReleased)
                    {
                        contacts[i].JustReleased = false;
                        touchPoint.PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
                    }
                    else if (contacts[i].Holding)
                    {
                        touchPoint.PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    }
                    else
                    {
                        touchPoint.PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"
                    }

                    toInject.Add(touchPoint);
                }
            }

            //injector.Length
            bool s = TouchInjector.InjectTouchInput(toInject.Count, toInject.ToArray());


            SettingsWindow.debugText[2] = "contacts: ";
            foreach (TouchContact c in contacts)
                SettingsWindow.debugText[2] += " " + c.ID; //  + " " + c.Holding






            //List<TouchContact> newContacts = new List<TouchContact>();

            ////List<PointerTouchInfo> toFire = new List<PointerTouchInfo>();

            //foreach (Finger finger in Fingers)
            //{

            //    int xPos = (int)(finger.TipPosition.x * multFactor) + 1000; // speed 15: 1000
            //    int yPos = -(int)(finger.TipPosition.y * multFactor) + 2500; // speed 15: add 2500
            //    float zPos = finger.TipPosition.z;

            //    //injectorList.Add(MakePointerTouchInfo(xPos, yPos, (uint)finger.Id));
            //    newContacts.Add(new TouchContact(xPos, yPos, zPos, finger.Id));
            //}

            ////injector = injectorList.ToArray();
            ////injectorList.Clear();


            //List<TouchContact> updatedContacts = new List<TouchContact>();
            //int foundIndex;

            ////todo: combine with foreach finger loop
            ////newContacts.Count - 1
            //for (int i = 0; i <= newContacts.Count - 1; i++)
            //{
            //    updatedContacts.Add(newContacts[i]);

            //    foundIndex = contacts.FindIndex(TouchContact => TouchContact.ID == updatedContacts[i].ID);
            //    if (foundIndex >= 0) //a matching ID was found
            //    {
            //        //transfer the data to the updated contacts
            //        updatedContacts[i].Holding = contacts[foundIndex].Holding;
            //        updatedContacts[i].JustPressed = contacts[foundIndex].JustPressed;
            //        updatedContacts[i].JustReleased = contacts[foundIndex].JustReleased;
            //    }
            //}

            //contacts = updatedContacts;


            ////contacts.Count - 1
            //for (int i = 0; i <= Fingers.Count - 1; i++)
            //{
            //    if (i <= injector.Length - 1)
            //    {
            //        //injector[i].PointerInfo.PointerId = (uint)contacts[i].ID;

            //        if (contacts[i].PosZ < touchThreshold && contacts[i].Holding == false) // pressed
            //        {
            //            contacts[i].JustPressed = true;
            //            contacts[i].Holding = true;
            //        }

            //        if (contacts[i].PosZ > touchThreshold && contacts[i].Holding == true) // released
            //        {
            //            contacts[i].JustReleased = true;
            //            contacts[i].Holding = false;
            //        }


            //        if (contacts[i].JustPressed)
            //        {
            //            contacts[i].JustPressed = false;
            //            injector[i].PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            //        }
            //        else if (contacts[i].JustReleased)
            //        {
            //            contacts[i].JustReleased = false;
            //            injector[i].PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
            //        }
            //        else if (contacts[i].Holding)
            //        {
            //            injector[i].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            //        }
            //        else
            //        {
            //            injector[i].PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"
            //        }

            //        injector[i].PointerInfo.PtPixelLocation.X = (int)(Fingers[i].TipPosition.x * multFactor) + 800; // speed 15: 1000
            //        injector[i].PointerInfo.PtPixelLocation.Y = -(int)(Fingers[i].TipPosition.y * multFactor) + 1800; // speed 15: add 2500
            //    }

            //}

            ////Form1.debugText[3] = "Fingers:  ";
            ////foreach (Finger f in Fingers)
            ////    Form1.debugText[3] += " " + f.Id;

            ////if (released)
            ////    Form1.debugText[3] += "r";

            ////released = false;


            ////injector.Length
            //bool s = TouchInjector.InjectTouchInput(Fingers.Count, injector);

            ////Form1.debugText[1] = "Injector length: " + injector.Length + "  contacts count: " + contacts.Count;




            //Form1.debugText[2] = "contacts: ";
            //foreach (TouchContact c in contacts)
            //    Form1.debugText[2] += " " + c.ID + " " + c.Holding;

            ////Form1.debugText[3] = "";

            ////Form1.debugText[4] = "" + s;
        }



        public static void RunTwo(FingerList Fingers)
        {
            List<Finger> sortedFingers = Fingers.OrderBy(Finger => Finger.TimeVisible).ToList();
            sortedFingers.Reverse();
            //List<Finger> sortedFingers = Fingers.ToList(); //temp

            int max = 2;

            int numFingers = sortedFingers.Count;
            if (sortedFingers.Count >= max )
                numFingers = max;

            //numFingers - 1
            for (int i = 0; i <= numFingers - 1; i++)
            {
                if (sortedFingers[i].TipPosition.z < Properties.Settings.Default.TouchThreshold)
                    isTouching[i] = true;
                else
                    isTouching[i] = false;

                if (isTouching[i] == true && Holding[i] == false) // pressed
                {
                    JustPressed[i] = true;
                    Holding[i] = true;
                }

                if (isTouching[i] == false && Holding[i] == true) // released
                {
                    JustReleased[i] = true;
                    Holding[i] = false;
                }


                if (JustPressed[i])
                {
                    JustPressed[i] = false;
                    injector[i].PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    //MouseSimulator.ClickLeftMouseButton();
                    bool s0 = TouchInjector.InjectTouchInput(numFingers, injector);
                    injector[i].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                }

                if (JustReleased[i])
                {
                    JustReleased[i] = false;
                    injector[i].PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
                    bool s1 = TouchInjector.InjectTouchInput(numFingers, injector);
                }

                if (Holding[i] == false)
                    injector[i].PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"

                //* Properties.Settings.Default.TouchCursorSpeed

                injector[i].PointerInfo.PtPixelLocation.X = (int)(sortedFingers[i].TipPosition.x * 10) + 1000; // 1000, 900
                injector[i].PointerInfo.PtPixelLocation.Y = -(int)(sortedFingers[i].TipPosition.y * 10) + 1500; // speed 15: add 2500, 700
            }

            //Fingers.Count
            bool s = TouchInjector.InjectTouchInput(numFingers, injector);
            //MouseSimulator.MoveCursor(injector[0].PointerInfo.PtPixelLocation.X, injector[0].PointerInfo.PtPixelLocation.Y);
            //MouseSimulator.MoveCursor(1920 / 2, 1180 / 2);


            //MouseSimulator.MoveCursor(MouseSimulator.mousePos.X + (int)(sortedFingers[0].TipVelocity.x * 0.5), MouseSimulator.mousePos.Y - (int)(sortedFingers[0].TipVelocity.y * 0.5));

            SettingsWindow.debugText[4] = "Finger IDs: ";
            foreach (Finger f in sortedFingers)
                SettingsWindow.debugText[4] += " " + f.Id;





            //List<PointerTouchInfo> toInject = new List<PointerTouchInfo>();

            //int numFingers = Fingers.Count;
            //if (Fingers.Count > 1)
            //    numFingers = 1;

            ////Fingers.Count - 1
            //for (int i = 0; i <= numFingers; i++)
            //{
            //    int ID = Fingers[i].Id;
            //    int xPos = (int)(Fingers[i].TipPosition.x * multFactor) + 1000;
            //    int yPos = -(int)(Fingers[i].TipPosition.y * multFactor) + 2500; // speed 15: add 2500

            //    PointerTouchInfo touchPoint = MakePointerTouchInfo(xPos, yPos, (uint)ID);

            //    if (Fingers[i].TipPosition.z < touchThreshold)
            //        isTouching[i] = true;
            //    else
            //        isTouching[i] = false;

            //    if (isTouching[i] == true && Holding[i] == false) // pressed
            //    {
            //        JustPressed[i] = true;
            //        Holding[i] = true;
            //    }

            //    if (isTouching[i] == false && Holding[i] == true) // released
            //    {
            //        JustReleased[i] = true;
            //        Holding[i] = false;
            //    }


            //    if (JustPressed[i])
            //    {
            //        JustPressed[i] = false;
            //        touchPoint.PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            //    }
            //    else if (JustReleased[i])
            //    {
            //        JustReleased[i] = false;
            //        touchPoint.PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
            //    }
            //    else if (Holding[i])
            //        touchPoint.PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            //    else
            //        touchPoint.PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"

            //    toInject.Add(touchPoint);
            //}
            //bool s = TouchInjector.InjectTouchInput(toInject.Count, toInject.ToArray());
        }





        public static void RunMouse(FingerList Fingers)
        {
            List<Finger> sortedFingers = Fingers.OrderBy(Finger => Finger.TimeVisible).ToList();
            sortedFingers.Reverse();

            float speed = Properties.Settings.Default.MouseCursorSpeed;
            int max = 1;

            int numFingers = sortedFingers.Count;
            if (sortedFingers.Count >= max)
                numFingers = max;

            //numFingers - 1
            for (int i = 0; i <= numFingers - 1; i++)
            {
                if (sortedFingers[i].TipPosition.z < Properties.Settings.Default.TouchThreshold)
                    isTouching[i] = true;
                else
                    isTouching[i] = false;

                if (isTouching[i] == true && Holding[i] == false) // pressed
                {
                    JustPressed[i] = true;
                    Holding[i] = true;
                }

                if (isTouching[i] == false && Holding[i] == true) // released
                {
                    JustReleased[i] = true;
                    Holding[i] = false;
                }


                if (JustPressed[i])
                {
                    JustPressed[i] = false;
                    //MouseSimulator.ClickLeftMouseButton();
                    MouseSimulator.LeftMouseDown();
                }

                if (JustReleased[i])
                {
                    JustReleased[i] = false;
                    MouseSimulator.LeftMouseUp();
                }

                if (sortedFingers.Count > 1 && sortedFingers[1].TipPosition.z < Properties.Settings.Default.TouchThreshold)
                {
                    if (rightClickTimer <= 0)
                    {
                        MouseSimulator.ClickRightMouseButton();
                        rightClickTimer = 50;
                    }
                }
                if (rightClickTimer > 0)
                    rightClickTimer--;
                    
                //if (Holding[i] == false)
                
                injector[i].PointerInfo.PtPixelLocation.X = (int)(sortedFingers[i].TipPosition.x * Properties.Settings.Default.TouchCursorSpeed) + 1000; // 1000, 900
                injector[i].PointerInfo.PtPixelLocation.Y = -(int)(sortedFingers[i].TipPosition.y * Properties.Settings.Default.TouchCursorSpeed) + 2500; // speed 15: add 2500, 700
                
            }

            MouseSimulator.getCoords();

            if (sortedFingers[0].TipPosition.z < Properties.Settings.Default.TouchThreshold + 30)
                MouseSimulator.MoveCursor(MouseSimulator.mousePos.X + (int)(sortedFingers[0].TipVelocity.x * speed), MouseSimulator.mousePos.Y - (int)(sortedFingers[0].TipVelocity.y * speed));

            SettingsWindow.debugText[1] = "Screen Coords:\n" + "X:" + MouseSimulator.mousePos.X + "  Y: " + MouseSimulator.mousePos.Y;

            SettingsWindow.debugText[2] = "RCT: " + rightClickTimer;

            SettingsWindow.debugText[4] = "Finger IDs: ";
            foreach (Finger f in sortedFingers)
                SettingsWindow.debugText[4] += " " + f.Id;
        }





        //FingerList
        public static void RunOne(FingerList Fingers)
        {
            List<Finger> sortedFingers = Fingers.OrderBy(Finger => Finger.TimeVisible).ToList();
            sortedFingers.Reverse();
            //List<Finger> sortedFingers = Fingers.ToList(); //temp

            int max = 1;
            float X, Y = 0;
            int speed = Properties.Settings.Default.TouchCursorSpeed;

            int numFingers = sortedFingers.Count;
            if (sortedFingers.Count >= max)
                numFingers = max;

            //numFingers - 1
            for (int i = 0; i <= numFingers - 1; i++)
            {
                if (sortedFingers[i].TipPosition.z < Properties.Settings.Default.TouchThreshold)
                    isTouching[i] = true;
                else
                    isTouching[i] = false;

                if (isTouching[i] == true && Holding[i] == false) // pressed
                {
                    JustPressed[i] = true;
                    Holding[i] = true;
                }

                if (isTouching[i] == false && Holding[i] == true) // released
                {
                    JustReleased[i] = true;
                    Holding[i] = false;
                }

                if (JustPressed[i])
                {
                    JustPressed[i] = false;
                    injector[i].PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                    //MouseSimulator.ClickLeftMouseButton();
                    bool s0 = TouchInjector.InjectTouchInput(numFingers, injector);
                    injector[i].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                }

                if (JustReleased[i])
                {
                    JustReleased[i] = false;
                    injector[i].PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
                    bool s1 = TouchInjector.InjectTouchInput(numFingers, injector);
                }

                if (Holding[i] == false)
                    injector[i].PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"

                X = sortedFingers[i].StabilizedTipPosition.x;
                Y = sortedFingers[i].StabilizedTipPosition.y;

                //X = sortedFingers[i].TipPosition.x;
                //Y = sortedFingers[i].TipPosition.y;

                //if (sortedFingers[i].TipVelocity.z > -20)

                injector[i].PointerInfo.PtPixelLocation.X = (int)(X * speed) + 1000; // 1000
                injector[i].PointerInfo.PtPixelLocation.Y = -(int)(Y * speed) + 2700; // speed 15: add 2500
            }

            bool s = TouchInjector.InjectTouchInput(numFingers, injector);

            SettingsWindow.debugText[1] ="Screen Coords:\n" + "X: " + injector[0].PointerInfo.PtPixelLocation.X + "Y: " + injector[0].PointerInfo.PtPixelLocation.Y;

            SettingsWindow.debugText[2] = "Z Velocity: " + sortedFingers[0].TipVelocity.z;

            SettingsWindow.debugText[4] = "Finger IDs:  ";
            foreach (Finger f in sortedFingers)
                SettingsWindow.debugText[4] += " " + f.Id;
        }



        public static void RunTool(ToolList Tools)
        {

            //List<Finger> sortedFingers = Fingers.OrderBy(Finger => Finger.Id).ToList();
            List<Tool> sortedTools = Tools.ToList(); //temp

            if (sortedTools[0].TipPosition.z < Properties.Settings.Default.TouchThreshold)
                isTouching[0] = true;
            else
                isTouching[0] = false;


            if (isTouching[0] == true && Holding[0] == false) // pressed
            {
                JustPressed[0] = true;
                Holding[0] = true;
            }

            if (isTouching[0] == false && Holding[0] == true) // released
            {
                JustReleased[0] = true;
                Holding[0] = false;
            }


            if (JustPressed[0])
            {
                JustPressed[0] = false;
                TouchDown(0, 1);
            }

            if (JustReleased[0])
            {
                JustReleased[0] = false;
                Release(0, 1);
            }

            if (Holding[0] == false)
                SetHover(0);

            if (!Holding[0]) // temp for game
            {
                injector[0].PointerInfo.PtPixelLocation.X = (int)(sortedTools[0].TipPosition.x * Properties.Settings.Default.TouchCursorSpeed) + 1000;
                injector[0].PointerInfo.PtPixelLocation.Y = -(int)(sortedTools[0].TipPosition.y * Properties.Settings.Default.TouchCursorSpeed) + 2500; // speed 15: add 2500
            }

            //injector.Length
            bool s = TouchInjector.InjectTouchInput(1, injector);
        }



        public static void SetHover(int index)
        {
            injector[index].PointerInfo.PointerFlags = PointerFlags.INRANGE | PointerFlags.UPDATE; //set to "hover mode"
        }

        public static void TouchDown(int index, int numFingers)
        {
            injector[index].PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
            //injector.Length, 1
            bool s0 = TouchInjector.InjectTouchInput(numFingers, injector);
            injector[index].PointerInfo.PointerFlags = PointerFlags.UPDATE | PointerFlags.INRANGE | PointerFlags.INCONTACT;
        }



        public static void Release(int index, int numFingers)
        {
            injector[index].PointerInfo.PointerFlags = PointerFlags.UP | PointerFlags.INRANGE;
            //injector.Length, 1
            bool s1 = TouchInjector.InjectTouchInput(numFingers, injector);
        }

        public static void RightClick()
        {
            MouseSimulator.ClickRightMouseButton();
        }

        public static PointerTouchInfo MakePointerTouchInfo(int x, int y, uint id, int radius = 1, uint orientation = 90, uint pressure = 32000) //radius unused
        {
            PointerTouchInfo contact = new PointerTouchInfo();
            contact.PointerInfo.pointerType = PointerInputType.TOUCH;
            contact.TouchFlags = TouchFlags.NONE;
            contact.Orientation = orientation;
            contact.Pressure = pressure;
            contact.TouchMasks = TouchMask.CONTACTAREA | TouchMask.ORIENTATION | TouchMask.PRESSURE;
            contact.PointerInfo.PtPixelLocation.X = x;
            contact.PointerInfo.PtPixelLocation.Y = y;
            contact.PointerInfo.PointerId = id;
            //contact.ContactArea.left = x - radius;
            //contact.ContactArea.right = x + radius;
            //contact.ContactArea.top = y - radius;
            //contact.ContactArea.bottom = y + radius;
            return contact;
        }

        //[StructLayout(LayoutKind.Sequential)]
        //public struct POINT
        //{
        //    public int X;
        //    public int Y;

        //    public static implicit operator Point(POINT point)
        //    {
        //        return new Point(point.X, point.Y);
        //    }
        //}

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool GetCursorPos(out POINT lpPoint);
        //static POINT mousePos;

        //private static void getCoords()
        //{
        //    bool s = GetCursorPos(out mousePos);
        //    /*
        //    if (GetCursorPos(out mousePos))
        //    {
        //        strCoords = Convert.ToString(mousePos.X) + " : " + Convert.ToString(mousePos.Y);
        //        lblCoords.Text = strCoords;
        //    }
        //     */
        //}
    }
}
