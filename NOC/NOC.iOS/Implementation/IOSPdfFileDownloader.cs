﻿using System;
using System.IO;
using Foundation;
using NOC.Interfaces;
using NOC.iOS.Implementation;
using QuickLook;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSPdfFileDownloader))]
namespace NOC.iOS.Implementation
{
    public class IOSPdfFileDownloader : IPdfFileDownloader
    {

        public void downloadLocalyStoredPdfFile(string fileName, byte[] data)
        {
            // Get my downloads path
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Combine with filename
            string fullName = Path.Combine(filePath, fileName);

            // If the file exist on device delete it
            if (File.Exists(fullName))
            {

                // Note: In the second run of this method, the file exists
                File.Delete(fullName);
            }

            // Write bytes on "My documents"
            File.WriteAllBytes(fullName, data);

            FileInfo fi = new FileInfo(fullName);

            QLPreviewController previewController = new QLPreviewController();
            previewController.DataSource = new PDFPreviewControllerDataSource(fi.FullName, fi.Name);

            UINavigationController controller = FindNavigationController();
            if (controller != null)
                controller.PresentViewController(previewController, true, null);

        }


        private UINavigationController FindNavigationController()
        {
            foreach (var window in UIApplication.SharedApplication.Windows)
            {
                if (window.RootViewController.NavigationController != null)
                    return window.RootViewController.NavigationController;
                else
                {
                    UINavigationController val = CheckSubs(window.RootViewController.ChildViewControllers);
                    if (val != null)
                        return val;
                }
            }

            return null;
        }

        private UINavigationController CheckSubs(UIViewController[] controllers)
        {
            foreach (var controller in controllers)
            {
                if (controller.NavigationController != null)
                    return controller.NavigationController;
                else
                {
                    UINavigationController val = CheckSubs(controller.ChildViewControllers);
                    if (val != null)
                        return val;
                }
            }
            return null;
        }
    }


    public class PDFItem : QLPreviewItem
    {
        string title;
        string uri;

        public PDFItem(string title, string uri)
        {
            this.title = title;
            this.uri = uri;
        }

        public override string ItemTitle
        {
            get { return title; }
        }

        public override NSUrl ItemUrl
        {
            get { return NSUrl.FromFilename(uri); }
        }
    }

    public class PDFPreviewControllerDataSource : QLPreviewControllerDataSource
    {
        string url = "";
        string filename = "";

        public PDFPreviewControllerDataSource(string url, string filename)
        {
            this.url = url;
            this.filename = filename;
        }

        //public override QLPreviewItem GetPreviewItem(QLPreviewController controller, int index)
        //{
        //    return new PDFItem(filename, url);
        //}

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return new PDFItem(filename, url);
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }
    }
}
