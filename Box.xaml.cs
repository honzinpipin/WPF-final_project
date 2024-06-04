using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2A_projekt_WPF
{
    /// <summary>
    /// Interaction logic for Box.xaml
    /// </summary>
    public partial class Box : UserControl
    {


        public Box()
        {
            InitializeComponent();
            ColorIndex = -1; 
        }

        public int ColorIndex { get; set; }


        //při Submitu se zvětší o 1
        public static int YIndex = 0;


      

        public void ChangeColor()
        {
            Brush color = Brushes.Red;

            //0 - red, 1 - green, 2 - blue, 3 - yellow, 4 - gray, 5 - Pink, 6 - aqua
            switch (ColorIndex)
            {
                case 0:
                    color = Brushes.Red;
                    break;
                case 1:
                    color = Brushes.Green;
                    break;

                case 2:
                    color = Brushes.Blue;
                    break;
                case 3: 
                    color = Brushes.Yellow;
                    break;
                case 4:
                    color = Brushes.Gray;
                    break;
                case 5:
                    color = Brushes.Pink;
                    break;
                case 6:
                    color = Brushes.Aqua;
                    break;

                
            }

            Rect.Fill = color;
        }

            public void AddIndex()
            {
                if (ColorIndex == 6)
                {
                    ColorIndex = 0;
                }
                else
                {
                    ColorIndex++;
                }

            
            }

    }
}
