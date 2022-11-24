using System.Windows.Media.Imaging;

namespace GooseGameWPF
{
    public class IconBuilder
    {
        public BitmapImage? IconImage { get; set; }

        public IconBuilder(BitmapImage BitImg)
        {
            IconImage = BitImg;
        }
    }
}