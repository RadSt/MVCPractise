using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WebApp.Tools
{
    /// <summary>
    /// Captcha generating class
    /// </summary>
    public class CaptchaImage
    {
        public const string CaptchaValueKey = "CaptchaImageText";

        private string _text;
        private int _width;
        private int _height;
        private string _familyName;
        private Bitmap _image;
        // For generating random numbers.
        Random _random = new Random();

        public CaptchaImage(string text, int width, int height)
        {
            _text = text;
            SetDimensions(width, height);
            GenerateImage();
        }

        public CaptchaImage(string text, int width, int height, string familyName)
        {
            _text = text;
            SetDimensions(width, height);
            SetFamilyName(familyName);
            GenerateImage();
        }

        public Bitmap Image
        {
            get { return _image;  }
        }
        public string Text
        {
            get { return _text; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        // ====================================================================
        // This member overrides Object.Finalize.
        // ====================================================================
        ~CaptchaImage()
        {
            Dispose(false);
        }
        // ====================================================================
        // Releases all resources used by this object.
        // ====================================================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        // ====================================================================
        // Custom Dispose method to clean up unmanaged resources.
        // ====================================================================
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of the bitmap
                Image.Dispose();
            }
        }

        // ====================================================================
        // Sets the image aWidth and aHeight.
        // ====================================================================
        private void SetDimensions(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width,
                    "Argument width must be greater than zero");

            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height,
                    "Argument height must be greater than zero");
            _width = width;
            _height = height;
        }

        // ====================================================================
        // Sets the font used for the image text.
        // ====================================================================
        private void SetFamilyName(string familyName)
        {
            // If the named font is not installed, default to a system font.
            try
            {
                Font font = new Font(familyName, 12F);
                _familyName = familyName;
                font.Dispose();
            }
            catch (Exception)
            {

                _familyName = FontFamily.GenericSerif.Name;
            }
        }

        // ====================================================================
        // Creates the bitmap image.
        // ====================================================================
        private void GenerateImage()
        {
            // Create a new 32 - bit bitmap image.
            Bitmap bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectangle = new Rectangle(0, 0, _width, _height);

            // Fill in the background.
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            graphics.FillRectangle(hatchBrush, rectangle);

            // Set up the text font.
            SizeF size;
            float fontSize = rectangle.Height + 1;
            Font font;

            // Adjust the font size until the text fits within the image.
            do
            {
                fontSize--;
                font = new Font(_familyName, fontSize, FontStyle.Bold);
                size = graphics.MeasureString(_text, font);
            } while (size.Width > rectangle.Width);

            // Set up the text format.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddString(_text, font.FontFamily, (int)font.Style, font.Size, rectangle, stringFormat);
            float v = 4F;
            PointF[] points =
            {
                new PointF(_random.Next(rectangle.Width)/v, _random.Next(rectangle.Height)/v),
                new PointF(rectangle.Width - _random.Next(rectangle.Width)/v, _random.Next(rectangle.Height)/v),
                new PointF(_random.Next(rectangle.Width)/v, rectangle.Height - _random.Next(rectangle.Height)/v),
                new PointF(rectangle.Width - _random.Next(rectangle.Width)/v, rectangle.Height - _random.Next(rectangle.Height))  
            };

            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            graphicsPath.Warp(points, rectangle, matrix, WarpMode.Perspective, 0F);

            // Draw the text.
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
            graphics.FillPath(hatchBrush, graphicsPath);

            // Add some random noise.
            int m = Math.Max(rectangle.Width, rectangle.Height);
            for (int i = 0; i < (int)(rectangle.Width * rectangle.Height / 30F); i++)
            {
                int x = _random.Next(rectangle.Width);
                int y = _random.Next(rectangle.Height);
                int w = _random.Next(m/50);
                int h = _random.Next(m/50);
                graphics.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up
            font.Dispose();
            hatchBrush.Dispose();
            graphics.Dispose();

            // Set the image.
            _image = bitmap;
        }
    }
}