using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;

namespace RevitBasicFileInfoExtract
{
    /// <summary>
    /// A container class of storing data extrated from `Autodesk.Revit.DB.BasicFileInfo`
    /// </summary>
    class BasicFileInfoResult
    {
        public BasicFileInfoResult(string filename, BasicFileInfo fileInfo)
        {
            this.Filename = filename;
            this.AllLocalChangesSavedToCentral = fileInfo.AllLocalChangesSavedToCentral;
            this.CentralPath = fileInfo.CentralPath;
            this.Format = fileInfo.Format;
            this.IsCentral = fileInfo.IsCentral;
            this.IsCreatedLocal = fileInfo.IsCreatedLocal;
            this.IsInProgress = fileInfo.IsInProgress;
            this.IsLocal = fileInfo.IsLocal;
            this.IsSavedInCurrentVersion = fileInfo.IsSavedInCurrentVersion;
            this.IsSavedInLaterVersion = fileInfo.IsSavedInLaterVersion;
            this.IsValidObject = fileInfo.IsValidObject;
            this.IsWorkshared = fileInfo.IsWorkshared;
            this.LanguageWhenSaved = fileInfo.LanguageWhenSaved;
            this.LatestCentralEpisodeGUID = fileInfo.LatestCentralEpisodeGUID;
            this.LatestCentralVersion = fileInfo.LatestCentralVersion;
            this.Username = fileInfo.Username;
        }

        /// <summary>
        /// The filename of this BasicFileInfo
        /// </summary>
        public string Filename { get; private set; }
        /// <summary>
        /// Are all local changes saved to the central file? See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool AllLocalChangesSavedToCentral { get; private set; }
        /// <summary>
        /// Returns the central model path. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public string CentralPath { get; private set; }
        /// <summary>
        /// The file format indicator (currently, the major release version such as "2019") used for saving the file. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public string Format { get; private set; }
        /// <summary>
        /// Checks if the file is workshared and Central. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsCentral { get; private set; }
        /// <summary>
        /// Checks if the file is local and created by RevitServerTool.exe. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsCreatedLocal { get; private set; }
        /// <summary>
        /// Checks if the file is workshared and is in process of becoming Central. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsInProgress { get; private set; }
        /// <summary>
        /// Checks if the file is workshared and Local. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsLocal { get; private set; }
        /// <summary>
        /// Checks if the file is saved in the current version. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsSavedInCurrentVersion { get; private set; }
        /// <summary>
        /// Checks if the file is saved in a later version of Revit than the running Revit. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsSavedInLaterVersion { get; private set; }
        /// <summary>
        /// Specifies whether the .NET object represents a valid Revit entity. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsValidObject { get; private set; }
        /// <summary>
        /// Checks if the file is workshared. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public bool IsWorkshared { get; private set; }
        /// <summary>
        /// Return the language active for the last save. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public LanguageType LanguageWhenSaved { get; private set; }
        /// <summary>
        /// This is the central model's episode GUID corresponding to the last reload latest done for this model. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public Guid LatestCentralEpisodeGUID { get; private set; }
        /// <summary>
        /// This is the central model's version number corresponding to the last reload latest done for this model. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public int LatestCentralVersion { get; private set; }
        /// <summary>
        /// Returns the username. See `Autodesk.Revit.DB.BasicFileInfo` in Revit API documentation.
        /// </summary>
        public string Username { get; private set; }
    }
}
