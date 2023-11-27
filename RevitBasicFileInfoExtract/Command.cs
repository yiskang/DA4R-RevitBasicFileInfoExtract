// (C) Copyright 2023 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software
// in object code form for any purpose and without fee is hereby
// granted, provided that the above copyright notice appears in
// all copies and that both that copyright notice and the limited
// warranty and restricted rights notice below appear in all
// supporting documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK,
// INC. DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL
// BE UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is
// subject to restrictions set forth in FAR 52.227-19 (Commercial
// Computer Software - Restricted Rights) and DFAR 252.227-7013(c)
// (1)(ii)(Rights in Technical Data and Computer Software), as
// applicable.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using DesignAutomationFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RevitBasicFileInfoExtract
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalDBApplication
    {

        public ExternalDBApplicationResult OnStartup(ControlledApplication application)
        {
            DesignAutomationBridge.DesignAutomationReadyEvent += HandleDesignAutomationReadyEvent;
            return ExternalDBApplicationResult.Succeeded;
        }

        public ExternalDBApplicationResult OnShutdown(ControlledApplication application)
        {
            return ExternalDBApplicationResult.Succeeded;
        }

        private void HandleDesignAutomationReadyEvent(object sender, DesignAutomationReadyEventArgs e)
        {
            LogTrace("Design Automation Ready event triggered...");

            e.Succeeded = true;
            e.Succeeded = this.DoTask(e.DesignAutomationData);
        }
        private bool DoTask(DesignAutomationData data)
        {
            if (data == null)
                return false;

            Application app = data.RevitApp;
            if (app == null)
            {
                LogTrace("Error occured");
                LogTrace("Invalid Revit App");
                return false;
            }

            var folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            var filesToBeExtracted = new List<FileInfo>();
            filesToBeExtracted.AddRange(folder.GetFiles("*.rvt", SearchOption.AllDirectories));
            filesToBeExtracted.AddRange(folder.GetFiles("*.rfa", SearchOption.AllDirectories));

            if (filesToBeExtracted.Count <= 0)
            {
                LogTrace("Error occurred");
                LogTrace("No RVT or RFA found");
                return false;
            }

            var extractedResults = new List<BasicFileInfoResult>();

            LogTrace("Extracting basic file info from Revit files ...");
            foreach (var fileInfo in filesToBeExtracted)
            {
                var filename = fileInfo.Name;
                LogTrace($" - Extracting from `{filename}` ...");

                try
                {
                    var basicFileInfo = BasicFileInfo.Extract(filename);
                    var basicFileInfoResult = new BasicFileInfoResult(filename, basicFileInfo);
                    extractedResults.Add(basicFileInfoResult);
                }
                catch (Exception ex)
                {
                    this.PrintError(ex);
                    continue;
                }

                LogTrace(" -- DONE.");
            }
            LogTrace(" - DONE.");

            if (extractedResults.Count <= 0)
            {
                LogTrace("Error occurred");
                LogTrace("Nothing extracted, please see above errors for detail.");
                return false;
            }

            try
            {
                LogTrace($"Producing JSON string result...");
                var result = JsonConvert.SerializeObject(
                    extractedResults,
                    Newtonsoft.Json.Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                LogTrace(" - DONE.");

                LogTrace($"Writting JSON result to `result.json`...");
                using (StreamWriter sw = File.CreateText("result.json"))
                {
                    sw.WriteLine(result);
                    sw.Close();
                }
                LogTrace(" - DONE.");
            }
            catch(Exception ex)
            {
                this.PrintError(ex);
                LogTrace($"Failed to convert results to JSON or producing JSON file...");
                return false;
            }

            return true;
        }

        private void PrintError(Exception ex)
        {
            LogTrace("Error occured");
            LogTrace(ex.Message);

            if (ex.InnerException != null)
                LogTrace(ex.InnerException.Message);
        }

        /// <summary>
        /// This will appear on the Design Automation output
        /// </summary>
        public static void LogTrace(string format, params object[] args)
        {
#if DEBUG
            System.Diagnostics.Trace.WriteLine(string.Format(format, args));
#endif
            System.Console.WriteLine(format, args);
        }
    }
}
