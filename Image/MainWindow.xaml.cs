using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Image
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            
            InitializeComponent();
     Import();
            listViev.ItemsSource = netuEntities3.Got().Image3.ToList();
            
        }
        //DESKTOP-NMR8DSE
        string imgLocation = "";
        private void add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if ((bool)dialog.ShowDialog())
            {
                imgLocation = dialog.FileName;
                images.Source = new BitmapImage(new Uri(dialog.FileName,UriKind.Absolute));
          //   byte [] img = null;
          //      FileStream fs = new FileStream(imgLocation,FileMode.Open,FileAccess.Read);
          //      BinaryReader br = new BinaryReader(fs);
            //    img = br.ReadBytes((int)fs.Length);

             //   netuEntities1.Got().Image2.Add((Image2)img);
         /*   Image2 image2 = new Image2 {Imagest=img };
         netuEntities1.Got().Image2.Add(image2);
                netuEntities1.Got().SaveChanges();*/

            }
             
             
              /*  Uri uri = new Uri("http://...");
                var bit = new BitmapImage(uri);
                images.Source =bit;*/
             
            
        }
        void Import()
        {
            var fileData = File.ReadAllLines(@"F:\СмолАПО\4курс\Зимняя сессия\МДК01.01\Точтосделал\Team3.txt");
            var image = Directory.GetFiles(@"F:\СмолАПО\4курс\Зимняя сессия\МДК01.01\TP09_2018_2D_NBA\Ресурсы\Сессия 1\data\Teams");

            foreach (var line in fileData)
            {
                var dan = line.Split('\t');

                /*       var tempTour = new Image3
                        {


                          imgt= Encoding.UTF8.GetBytes(dan[0])



                        };*/
                foreach (var a in image)
                {
                    print.Content += a + " ";
                }
                foreach (var touch  in dan[0].Replace("\"","").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)   )
                {
                    //     var currentType = netuEntities3.Got().Image3.ToList().FirstOrDefault(p => p.Id == Convert.ToInt32(touch));
                    //   netuEntities3.Got().Image3.Add(currentType);
              //      print.Content = $"{touch} {touch.ToString()}";
                    netuEntities3.Got().Image3.Add(new Image3{imgt = File.ReadAllBytes(image.FirstOrDefault(p=> p.Contains((touch.Length==1 ?  "0":"")+touch.ToString())))});
                }
        //      netuEntities3.Got().Image3.Add(tempTour);

                netuEntities3.Got().SaveChanges();
            }
        }
        private void add2_Click(object sender, RoutedEventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            //   netuEntities1.Got().Image2.Add((Image2)img);
     
        netuEntities3.Got().Image3.Add(new Image3 { imgt = img });
            netuEntities3.Got().SaveChanges();
          //  MessageBox.Show(img.ToString());
        }
    }
}
