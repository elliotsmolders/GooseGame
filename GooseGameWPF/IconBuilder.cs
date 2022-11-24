using System.Windows.Media.Imaging;

namespace GooseGameWPF
{
    public class IconBuilder
    {
        public BitmapImage? IconImage { get; set; }
        public string IconDescription { get; set; }

        public IconBuilder(BitmapImage BitImg,string description)
        {
            IconImage = BitImg;
            IconDescription = description;

        }
    }
}