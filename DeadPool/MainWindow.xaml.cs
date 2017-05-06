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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;

namespace DeadPool
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromSeconds(3.0);
            t1.Tick += new EventHandler(reloj);
            
            
            t1.Start();
            
        }

        private void reloj(object sender, EventArgs e)
        {
            pgb_Diversion.Value -= 5.0;
            pgb_Energia.Value -= 5.0;
            pgb_Hambre.Value -= 5.0;

            Storyboard hambriento;
            hambriento = (Storyboard)this.Resources["pgb_Hambre"];

            Storyboard diversion;
            diversion = (Storyboard)this.Resources["pgb_Diversion"];
            
            Storyboard cansado;
            cansado = (Storyboard)this.Resources["pgb_Cansado"];

           
            if (pgb_Hambre.Value ==0  || pgb_Diversion.Value ==0  || pgb_Energia.Value < 5) {
           
               
            }

        }

        private void btnComer_Click(object sender, RoutedEventArgs e)
        {
            pgb_Hambre.Value += 20.0;
            Accion_comer();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            pgb_Diversion.Value += 20.0;
        }

        private void btnDormir_Click(object sender, RoutedEventArgs e)
        {
            pgb_Energia.Value += 20.0;
            Accion_Dormir();
        }

        

        

        private void el_cabeza_MouseUp(object sender, MouseButtonEventArgs e)
        {
      
                Mascara_png.Visibility = Visibility.Visible;
        }
        

      

        private void Mascara_png_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mascara_png.Visibility = Visibility.Hidden;
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Storyboard espada;
            espada = (Storyboard)this.Resources["Espada"];
            Storyboard enfadado;
            enfadado = (Storyboard)this.Resources["EspadaEnfado"];
           //espada.Begin();
            enfadado.Begin();
        }
        SoundPlayer Comer;
        private void Accion_comer()
        {
            
            Storyboard comiendo;
            comiendo = (Storyboard)this.Resources["Comiendo"];
            Comer = new SoundPlayer(@"..\..\eat.wav");
            //espada.Begin();
            comiendo.Begin();
            Comer.Play();
            /*try
            {
                Comer = new SoundPlayer(@"C:\Users\Jesus\Documents\DeadPool\DeadPool\eat.wav");
            }
            catch (Exception e) {
                MessageBox.Show("Error: " + e);
            }*/
        }
        SoundPlayer Dormir;
        private void Accion_Dormir()
        {

            Storyboard durmiendo;
            durmiendo = (Storyboard)this.Resources["Dormir"];
            Dormir = new SoundPlayer(@"..\..\snore.wav");
            //espada.Begin();
            durmiendo.Begin();
            Dormir.Play();
            /*try
            {
                Comer = new SoundPlayer(@"C:\Users\Jesus\Documents\DeadPool\DeadPool\eat.wav");
            }
            catch (Exception e) {
                MessageBox.Show("Error: " + e);
            }*/
        }

    }
}
