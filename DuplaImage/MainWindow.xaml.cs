using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using HandyControl.Data;
using System.Windows;
using System.Windows.Controls;
using DuplaImage.API;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Documents;
using DuplaImage.Lib;
using DuplaImage.Views;
using HandyControl.Controls;
using static DuplaImage.API.Reference;
using TextBox = System.Windows.Controls.TextBox;

namespace DuplaImage {
    public partial class MainWindow {

        //private static string ImgDir = "C:\\Users\\mrsqu\\Desktop\\Test";
        //private static List<ulong> hashList = new List<ulong>();
        //private static ImageHashes imageHasher = new ImageHashes(new ImageMagickTransformer());
        //private static List<SImage> images = new List<SImage>();

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

        private static readonly ImageHashes ImageHasher = new ImageHashes(new ImageMagickTransformer());

        public MainWindow() {
            InitializeComponent();
        }

        #region Change Skin
        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

        private void ButtonSkins_OnClick(object sender, RoutedEventArgs e) {
            if (e.OriginalSource is Button button && button.Tag is SkinType tag) {
                PopupConfig.IsOpen = false;
                ((App)Application.Current).UpdateSkin(tag);
            }
        }
        #endregion

        private void BrowseButton_Click(object sender, RoutedEventArgs e) {
            switch (((Button)sender).Content) {
                case "Browse":
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Multiselect = true;
                    dialog.Filter = "Image Files |*.jpeg;*.png;*.jpg;";

                    if (dialog.ShowDialog() == true) {
                        foreach (string file in dialog.FileNames) {
                            DirList.Items.Add(file);
                            FileList.Add(file);
                            //Images.Add(new DImage() {
                            //    ImageName = Path.GetFileNameWithoutExtension(file),
                            //    ImageDir = Path.GetDirectoryName(file),
                            //    ImageHash = ImageHasher.CalculateDifferenceHash256(file)
                            //});
                        }
                        ((Button)sender).Content = "Scan";
                    }
                    break;
                case "Scan":
                    popup.PopupElement = new Scanning();
                    popup.ShowDialog();
                    break;
                default:
                    break;
            }
        }
    }
}


/*
 * Todo: Add ability to remove selected items
 * Todo: Localization
 */
