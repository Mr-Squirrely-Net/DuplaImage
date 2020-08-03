using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DuplaImage.API;
using HandyControl.Controls;
using static DuplaImage.API.Reference;
using Path = System.IO.Path;

namespace DuplaImage.Views {
    /// <summary>
    /// Interaction logic for Scanning.xaml
    /// </summary>
    public partial class Scanning : Page {

        //static void Main(string[] args) {
        //    foreach (string image in Directory.EnumerateFiles(ImgDir)) {
        //        images.Add(new SImage() {
        //            ImageName = Path.GetFileName(image),
        //            ImageDir = image,
        //            ImageHash = imageHasher.CalculateDifferenceHash64(image)
        //        });
        //    }

        //    foreach (SImage sImage in images) {
        //        sImage.IsSimilarTo(images);
        //        foreach (SImage image in sImage.SimilarTo) {
        //            Console.WriteLine($"{sImage.ImageName} is similar to:");
        //            Console.WriteLine(image.ImageName);
        //        }
        //    }
        //}

        private ThreadStart scannerThreadStart;
        private Thread scannerThread;
        
        public Scanning() {
            InitializeComponent();
            StartScanning();
        }

        private void StartScanning() {
            scannerThreadStart = ScanningStart;
            scannerThreadStart += () => {
                popup.Dispatcher.Invoke(() => {
                    popup.Close();
                    Growl.SuccessGlobal("Done analyzing photos");
                });
            };
            scannerThread = new Thread(scannerThreadStart);
            scannerThread.Start();
        }

        public void ScanningStart() {

            foreach (string file in FileList) {
                Images.Add(new DImage() {
                    ImageName = Path.GetFileNameWithoutExtension(file),
                    ImageDir = Path.GetDirectoryName(file),
                    ImageHash = Helper.ImageHasher.CalculateDifferenceHash64(file)
                });
            }

            foreach (DImage dImage in Images) {
                Debug.WriteLine($"Working on {dImage.ImageName}");
                dImage.IsSimilarTo(Images);
                foreach (DImage image in dImage.SimilarTo) {
                    Debug.WriteLine($"Is similar to {image.ImageName}");
                }
            }
        }

    }
}
