using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ONBOXAppl
{
    /// <summary>
    /// 打开ONBOX主页
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    internal class SiteONBOX : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            System.Diagnostics.Process.Start("http://www.onboxdesign.com.br/");
            return Result.Succeeded;
        }
    }

    /// <summary>
    /// 关于
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    internal class AboutONBOXApp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AboutUI aboutWindow = new AboutUI();
            aboutWindow.ShowDialog();
            return Result.Succeeded;
        }
    }

    /// <summary>
    /// 程序项目文件夹
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    internal class ProjectFolder : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            string version = commandData.Application.Application.VersionNumber;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Autodesk\\Revit\\Addins\\" + version + "\\ONBOX\\"/* "\\ONBOX\\Project Examples"*/;
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                TaskDialog.Show(Properties.Messages.Common_Error, Properties.Messages.SampleProjects_DirNotFound);
            }
            return Result.Succeeded;
        }
    }
}