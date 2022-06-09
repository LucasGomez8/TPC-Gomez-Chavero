using System;
using System.Windows.Forms;

namespace helpers
{
    public static class ImageHelper
    {
        public static void LoadImage(PictureBox pictureBox, string e)
        {
            try
            {
                pictureBox.Load(e);
            }
            catch (Exception)
            {
                pictureBox.Image = Properties.Resources.image_default;
            }
        }
    }
}
