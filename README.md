# Design Automation Sample of extracting BasicFileInfo from RVT or RFA file

[![Design-Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://developer.autodesk.com/)

![Windows](https://img.shields.io/badge/Plugins-Windows-lightgrey.svg)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)
[![Revit-2024](https://img.shields.io/badge/Revit-2024-lightgrey.svg)](http://autodesk.com/revit)

## Description

This sample addin demonstrates how to extract basic file information (e.g. file version) from Revit files (RFA & RVT) using [BasicFileInfo](https://www.revitapidocs.com/2024/475edc09-cee7-6ff1-a0fa-4e427a56262a.htm) in Revit API.

## Example Result in JSON

```json
[
  {
    "filename": "Commercial_Sample_Project-2020.rvt",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2020",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": false,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "da4dd9b0-b1aa-4d09-9097-99fb28d0d153",
    "latestCentralVersion": 11,
    "username": ""
  },
  {
    "filename": "rac_basic_sample_project-2020.rvt",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2020",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": false,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "14da91f7-bb8f-46ac-a0d0-3d8917d007d1",
    "latestCentralVersion": 15,
    "username": ""
  },
  {
    "filename": "rst_basic_sample_project-2022.rvt",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2022",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": false,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "c3556c99-d20b-4f92-bdc0-67ffdf7be96e",
    "latestCentralVersion": 48,
    "username": ""
  },
  {
    "filename": "Snowdon Towers Sample Site.rvt",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2024",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": true,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "400b7cf2-816a-4d95-a62f-5f72cd0550e5",
    "latestCentralVersion": 97,
    "username": ""
  },
  {
    "filename": "サンプル意匠.rvt",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2024",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": true,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 8,
    "latestCentralEpisodeGUID": "2ab934ef-56c5-4a10-80c7-87ec865046d6",
    "latestCentralVersion": 92,
    "username": ""
  },
  {
    "filename": "rac_advanced_sample_family.rfa",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2024",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": true,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "4f383e17-15a9-4a66-b523-b7cfd554961f",
    "latestCentralVersion": 28,
    "username": ""
  },
  {
    "filename": "rst_basic_sample_family-2022.rfa",
    "allLocalChangesSavedToCentral": false,
    "centralPath": "",
    "format": "2022",
    "isCentral": false,
    "isCreatedLocal": false,
    "isInProgress": false,
    "isLocal": false,
    "isSavedInCurrentVersion": false,
    "isSavedInLaterVersion": false,
    "isValidObject": true,
    "isWorkshared": false,
    "languageWhenSaved": 0,
    "latestCentralEpisodeGUID": "8c42dcab-f657-41a4-a9ee-243c996cc358",
    "latestCentralVersion": 59,
    "username": ""
  }
]
```

## Forge DA Setup

### Activity via [POST activities](https://forge.autodesk.com/en/docs/design-automation/v3/reference/http/activities-POST/)

```json
{
    "commandLine": [
        "$(engine.path)\\\\revitcoreconsole.exe  /al \"$(appbundles[RevitBasicFileInfoExtract].path)\""
    ],
    "parameters": {
        "inputFile": {
            "verb": "get",
            "description": "Input Revit File",
            "required": true,
            "localName": "$(inputFile)"
        },
        "result": {
            "zip": false,
            "verb": "put",
            "description": "Result JSON File",
            "required": true,
            "localName": "result.json"
        }
    },
    "id": "youralais.RevitBasicFileInfoExtractActivity+dev",
    "engine": "Autodesk.Revit+2024",
    "appbundles": [
        "youralais.RevitBasicFileInfoExtract+dev"
    ],
    "settings": {},
    "description": "Activity of extract BasicFileInfo from RVT or RFA",
    "version": 1
}
```

### Workitem via [POST workitems](https://forge.autodesk.com/en/docs/design-automation/v3/reference/http/workitems-POST/)

```json
{
    "activityId": "youralais.RevitBasicFileInfoExtractActivity+dev",
    "arguments": {
      "inputFile": {
        "verb": "get",
        "url": "https://developer.api.autodesk.com/oss/v2/signedresources/...region=US"
      },
      "result": {
        "verb": "put",
        "url": "https://developer.api.autodesk.com/oss/v2/signedresources/...?region=US"
      }
    }
}
```

We can also provide the inputs in ZIP
```json
{
    "activityId": "youralais.RevitBasicFileInfoExtractActivity+dev",
    "arguments": {
      "inputFile": {
        "verb": "get",
        "url": "https://developer.api.autodesk.com/oss/v2/signedresources/...region=US", //!<<< Signed URL for the ZIP
        "pathInZip": "root.rvt", //!<<<< either filename of the RVT file in the ZIP. If so, Revit DA can know the input is a ZIP
        "adskZipMigration" : true
      },
      "result": {
        "verb": "put",
        "url": "https://developer.api.autodesk.com/oss/v2/signedresources/...?region=US"
      }
    }
}
```

## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by

Eason Kang [@yiskang](https://twitter.com/yiskang), [Autodesk Developer Advocacy and Support](http://aps.autodesk.com)
