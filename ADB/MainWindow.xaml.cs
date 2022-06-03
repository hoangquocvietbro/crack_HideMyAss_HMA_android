using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ADB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region data
        Bitmap OK_btn_Bitmap;
        Bitmap AppClone_btn_Bitmap;
        Bitmap HMA_Bitmap;
        Bitmap Lauch_Bitmap;
        Bitmap Import_Bitmap;
        Bitmap Search_Bitmap;


        #endregion
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            OK_btn_Bitmap = (Bitmap)Bitmap.FromFile("Data//ok.png");
            AppClone_btn_Bitmap = (Bitmap)Bitmap.FromFile("Data//appclone.png");
            HMA_Bitmap = (Bitmap)Bitmap.FromFile("Data//hma.png");
            Lauch_Bitmap = (Bitmap)Bitmap.FromFile("Data//launch.png");
            Import_Bitmap = (Bitmap)Bitmap.FromFile("Data//import.png");
            Search_Bitmap = (Bitmap)Bitmap.FromFile("Data//search.png");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtDevices.Text = "";
            MessageBox.Show("Auto đang chạy hãy chờ có thông báo thành công", "Thông báo", MessageBoxButton.OK);
            Task t = new Task(()=> {
                isStop = false;
                Auto();
            });
            t.Start();
        }

        bool isStop = false;
        void Auto()
        {
            // lấy ra danh sách devices id để dùng
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
         
          

                // chạy từng device để điều khiển theo kịch bản bên trong
                foreach (var deviceID in devices)
            {
                
                // tạo ra một luồng xử lý riêng biệt để xử lý cho device này
                Task t = new Task(()=> {
                    // lặp kịch bản quài quài
                    while (true)
                    {
                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell input keyevent 25");
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " install \"App Cloner_2.13.1.apk\"");
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " install \"HMA VPN_5.57.6298.apk\"");
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell am start -n com.applisto.appcloner/com.applisto.appcloner.activity.MainActivity");
                        Delay(10);
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell am start -n com.applisto.appcloner/com.applisto.appcloner.activity.MainActivity");
                        #endregion
                        Delay(10);
                        #region

                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        var screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        var okButtonPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, OK_btn_Bitmap);
                        if (okButtonPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, okButtonPosition.Value.X, okButtonPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        
                        if (okButtonPosition != null)
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.7, 22.0);
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        var IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, AppClone_btn_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, HMA_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, Lauch_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell am start -n com.applisto.appcloner/com.applisto.appcloner.activity.MainActivity");
                        Delay(10);
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell am start -n com.applisto.appcloner/com.applisto.appcloner.activity.MainActivity");
                        #endregion
                        Delay(30);

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, HMA_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, Import_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, OK_btn_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        screenShoot = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        IMGPosition = KAutoHelper.ImageScanOpenCV.FindOutPoint(screenShoot, Search_Bitmap);
                        if (IMGPosition != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, IMGPosition.Value.X, IMGPosition.Value.Y);
                        }
                        Delay(1);
                        #endregion
                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.InputText(deviceID,"hma vpn2022");
                        Delay(1);
                        #endregion

                        #region
                        if (isStop)
                        {
                            isStop = false;
                            return;
                        }
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 37.2, 14.3);
                        Delay(1);
                        #endregion


                        MessageBox.Show("Crack Thành Công", "Thông báo", MessageBoxButton.OK);
                        return;
                    }
                });
                t.Start();
            }
        }

        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }
    }
}
