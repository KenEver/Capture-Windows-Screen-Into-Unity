using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.IO;
using UnityEngine.UI;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class recorder : MonoBehaviour 
{
    public float timeRemaining = 1;
    Texture2D t;
    int fps=0;
    Bitmap captureBitmap = new Bitmap(1920, 1080);
    MemoryStream msFinger = new MemoryStream();
    bool screemWaittingForLoad=false;
    // Start is called before the first frame update    

    private void UpdateScreen() {
        //if (!screemWaittingForLoad) 
        { 
            Rectangle captureRectangle = System.Windows.Forms.Screen.AllScreens[0].Bounds;
            System.Drawing.Graphics captureGraphics = System.Drawing.Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(0, 0, 0, 0, captureRectangle.Size);
            msFinger = new MemoryStream();
            captureBitmap.Save(msFinger, captureBitmap.RawFormat);
            screemWaittingForLoad = true;
        }

    }

    void Start()
    {
        t = new Texture2D(1920, 1080);

        UpdateScreen();
        new Thread(() =>
        {
            while (true) 
            {
                UpdateScreen();
            }
        }).Start();
    }
    // Update is called once per frame

    void FiexedUpdate()
    {

    }

    void Update()
    {
        if (screemWaittingForLoad) {
            t.LoadImage(msFinger.ToArray());
            GetComponent<RawImage>().texture = t;
            screemWaittingForLoad = false;
        }
        
        /*if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            fps++;
        }
        else
        {
            Debug.Log(fps);
            fps = 0;
            timeRemaining = 1;
        }*/
    }

    [Flags]
    public enum MouseEventFlags
    {
        LeftDown = 0x00000002,
        LeftUp = 0x00000004,
        MiddleDown = 0x00000020,
        MiddleUp = 0x00000040,
        Move = 0x00000001,
        Absolute = 0x00008000,
        RightDown = 0x00000008,
        RightUp = 0x00000010
    }

    [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out MousePoint lpMousePoint);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    public static void SetCursorPosition(int x, int y)
    {
        SetCursorPos(x, y);
    }

    public static void SetCursorPosition(MousePoint point)
    {
        SetCursorPos(point.X, point.Y);
    }

    public static MousePoint GetCursorPosition()
    {
        MousePoint currentMousePoint;
        var gotPoint = GetCursorPos(out currentMousePoint);
        if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
        return currentMousePoint;
    }

    public static void MouseEvent(MouseEventFlags value)
    {
        MousePoint position = GetCursorPosition();

        mouse_event
            ((int)value,
             position.X,
             position.Y,
             0,
             0)
            ;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
