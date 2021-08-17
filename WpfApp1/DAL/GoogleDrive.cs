using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class GoogleDriveAPI
    {

        DriveService service;

        [Obsolete]
        public GoogleDriveAPI()
        {
            service = GetService();
        }

        //create Drive API service.
        [Obsolete]
        public DriveService GetService()
        {
            string[] Scopes = { DriveService.Scope.Drive };
            //get Credentials from client_secret.json file 
            UserCredential credential;
            var CSPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
            var aa = Path.Combine(Directory.GetParent(CSPath).FullName, "DAL");
            var FolderPath = Path.Combine(aa, "Content");
            var clientSecretPath = Path.Combine(FolderPath, "client_secret.json");

            using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
            {
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }

            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveAPI",
            });
            return service;
        }

        //get all files from Google Drive.
        public List<GoogleDriveFile> GetDriveFiles()
        {
            // Define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();
            // for getting folders only.
            // FileListRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            FileListRequest.Fields = "nextPageToken, files(*)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFile> FileList = new List<GoogleDriveFile>();


            // For getting only folders
            // files = files.Where(x => x.MimeType == "application/vnd.google-apps.folder").ToList();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime,
                        Parents = file.Parents,
                        MimeType = file.MimeType
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }

        //Download file from Google Drive by fileId.
        public string DownloadGoogleFile(string fileId)
        {
            var CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            var FolderPath = Path.Combine(CSPath, @"DAL\DriveFiles");
            FilesResource.GetRequest request = service.Files.Get(fileId);

            string FileName = request.Execute().Name;
            string FilePath = Path.Combine(FolderPath, FileName) + @".jpg";

            MemoryStream stream = new MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            SaveStream(stream, FilePath);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            break;
                        }
                }
            };
            var a = request.DownloadWithStatus(stream);
            return FilePath;
        }

        // file save to server path
        private void SaveStream(MemoryStream stream, string FilePath)
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }

        public void DeleteGoogleFile(string fileId)
        {
            FilesResource.DeleteRequest DeleteRequest = service.Files.Delete(fileId);
            DeleteRequest.Execute();

        }

        [Obsolete]
        public GoogleDriveFile GetDriveFolder(string folderName)
        {
            DriveService service = GetService();
            List<GoogleDriveFile> FolderList = new List<GoogleDriveFile>();
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "mimeType='application/vnd.google-apps.folder'";
            request.Fields = "files(id, name)";
            Google.Apis.Drive.v3.Data.FileList result = request.Execute();
            foreach (var file in result.Files)
            {
                if (file.Name == folderName)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime
                    };
                    FolderList.Add(File);
                }
            }
            return FolderList.FirstOrDefault();
        }

    }
}
