//
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace TexturedWindowWithText
{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device MyDevice;
        Microsoft.DirectX.Direct3D.Texture MyTexture;
        Microsoft.DirectX.Direct3D.Font MyFont;

        public Form1()
        {
            InitializeComponent();
            InitDevice();
        }


        public void InitDevice()
        {
            PresentParameters MyWindow = new PresentParameters();
            MyWindow.Windowed = true;
            MyWindow.SwapEffect = SwapEffect.Discard;
            MyDevice = new Device(0, DeviceType.Hardware, this,CreateFlags.HardwareVertexProcessing, MyWindow);

            System.Drawing.Font MyFontStyle = new System.Drawing.Font("Arial", 16f, FontStyle.Regular);
            MyFont = new Microsoft.DirectX.Direct3D.Font(MyDevice, MyFontStyle);

            MyTexture = TextureLoader.FromFile(MyDevice, "C:\\Users\\Inane\\OneDrive\\Desktop\\College\\GP\\painttriangle.png", 400, 400, 1, 0, Format.A8B8G8R8, Pool.Managed, Filter.Point, Filter.Point, Color.Transparent.ToArgb());
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            MyDevice.Clear(ClearFlags.Target, Color.CornflowerBlue, 0, 1);
            MyDevice.BeginScene();


            using (Sprite MySprite = new Sprite(MyDevice))
            {
                MySprite.Begin(SpriteFlags.AlphaBlend);

                MySprite.Draw2D(MyTexture, new Rectangle(0, 0, 0, 0), new SizeF(MyDevice.Viewport.Width, MyDevice.Viewport.Height), new Point(0, 0), 0f, new Point(0, 0), Color.White);

                MyFont.DrawText(MySprite, "Subeen Kalania", new Point(0, 0), Color.Black);
                MySprite.End();

            }


            MyDevice.EndScene();
            MyDevice.Present();

        }

    }
}