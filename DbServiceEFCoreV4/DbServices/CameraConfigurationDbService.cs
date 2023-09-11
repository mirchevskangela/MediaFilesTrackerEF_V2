using ClassLibrary.ModelClass;
using DbServiceEFCoreV4;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.ModelClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DbServicesEFCore.DbServices
{
    public class CameraConfigurationDbService
    {
        #region Members
        private VideoDetectContext _videoDetectContext;
        private DatabaseConfig _databaseConfig;
        #endregion
        #region Constructors
        public CameraConfigurationDbService()
        {
            _databaseConfig = new DatabaseConfig();
            _videoDetectContext = new VideoDetectContext(_databaseConfig.DatabaseConnectionString());

        }
        #endregion

        #region Services
        /// <summary>
        /// Adds a new camera configuration to the cameraconfigurations table
        /// </summary>
        /// <param name="newConfiguration"></param>
        public void WriteDb_AddCameraConfiguration(CameraConfiguration newConfiguration)
        {
            try
            {
                _videoDetectContext.CameraConfigurations.Add(newConfiguration);
                _videoDetectContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Returns a camera name or id or folder path or video extension or photo extension value of a particular record from the configuration_details table based on given camera name
        /// </summary>
        /// <param name="insertedCameraName"></param>
        /// <returns></returns>
        public (List<VideoExtension> videoExtensions, List<PhotoExtension> photoExtensions, string folderPath, string name, int id) ReadFromDb_Configuration_InDetail(string insertedCameraName) // tuple return type
        {
            List<VideoExtension> videoExtensions = new List<VideoExtension> { };
            List<PhotoExtension> photoExtensions = new List<PhotoExtension> { };
            // List<Folder>

            string folderPaths = "";
            string name = "";
            int id = 0;
            var existingObject = _videoDetectContext.CameraConfigurations.Include(v => v.VideoExtensions).ThenInclude(v => v.VideoExtension).Include(p => p.PhotoExtensions).ThenInclude(p => p.PhotoExtension).Where(c => c.CameraName == insertedCameraName).SingleOrDefault();

            try
            {
                if (existingObject != null)
                {
                    videoExtensions = existingObject.VideoExtensions
                             .Select(cce => cce.VideoExtension)
                             .ToList();
                    photoExtensions = existingObject.PhotoExtensions
                             .Select(cce => cce.PhotoExtension)
                             .ToList();

                    //  folderPaths = existingObject.FolderPath;


                    name = existingObject.CameraName;
                    id = existingObject.Id;
                }



                return (videoExtensions: videoExtensions, photoExtensions: photoExtensions, folderPath: folderPaths, name: name, id: id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (videoExtensions: videoExtensions, photoExtensions: photoExtensions, folderPath: folderPaths, name: name, id: id);
        }
        /// <summary>
        /// Retrieves all camera names
        /// </summary>
        /// <returns></returns>
        public List<String> ReadDb_AllCameraNames()
        {
            List<String> allCameraNames = new List<String>();

            try
            {
                allCameraNames = _videoDetectContext.CameraConfigurations.Include(p => p.PhotoExtensions).ThenInclude(p => p.PhotoExtension).Include(v => v.VideoExtensions).ThenInclude(v => v.VideoExtension).Select(c => c.CameraName).ToList();
                return allCameraNames;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allCameraNames;
        }
        //  public List<CameraConfiguration> ReadDb_
        /// <summary>
        /// Retrieves all camera names
        /// </summary>
        /// <returns></returns>
        public List<CameraConfiguration> ReadDb_AllCameraConfigurations()
        {
            List<CameraConfiguration> configurationObjects = new List<CameraConfiguration>();

            try
            {

                configurationObjects = _videoDetectContext.CameraConfigurations.Include(f => f.Folders).ThenInclude(f => f.Folder).Include(p => p.PhotoExtensions).ThenInclude(p => p.PhotoExtension).Include(v => v.VideoExtensions).ThenInclude(v => v.VideoExtension).ToList();


                return configurationObjects;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configurationObjects;
        }
        /// <summary>
        /// Retrieves specific configuration based on the given camera name 
        /// </summary>
        /// <param name="cameraName"></param>
        /// <returns></returns>
        public CameraConfiguration ReadDb_CameraConfiguration(string cameraName)
        {
            CameraConfiguration configurationObject = new CameraConfiguration();
            try
            {
                configurationObject = _videoDetectContext.CameraConfigurations.Where(c => c.CameraName == cameraName).SingleOrDefault();
                return configurationObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return configurationObject;
        }
        /// <summary>
        /// Updates the configuration details for a specific camera configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="insertedFolderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        public bool UpdateDb_AddConfigurationDetail(CameraConfiguration configuration, string insertedFolderPath = "", string videoExtension = "", string photoExtension = "")
        {
            bool updated = false;
            try
            {
                if (insertedFolderPath != "")
                {
                    Folder folderObject = new Folder();

                    var checkIfFolderExistsInDB = ReadDb_CheckIfFolderObjectExistInDb(insertedFolderPath);
                    if (checkIfFolderExistsInDB)
                    {
                        folderObject = ReadDb_FolderObject(insertedFolderPath);
                        var ifFolderExistsInTheConfiguration = configuration.Folders.Any(f =>
                         f.Folder.FolderPath == folderObject.FolderPath);
                        if (!ifFolderExistsInTheConfiguration)
                        {
                            configuration.Folders.Add(new DbServiceEFCoreV4.Folder_CameraConfiguration { Folder = folderObject });
                            int numberOfchanges = _videoDetectContext.SaveChanges();
                            if (numberOfchanges > 0)
                            {
                                updated = true;

                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show(configuration.Folders.Count.ToString());

                        folderObject.FolderPath = insertedFolderPath;
                        configuration.Folders.Add(new DbServiceEFCoreV4.Folder_CameraConfiguration { Folder = folderObject });
                        MessageBox.Show(configuration.Folders.Count.ToString());
                        int numberOfchanges = _videoDetectContext.SaveChanges();
                        if (numberOfchanges > 0)
                        {
                            updated = true;

                        }
                    }
                }
                if (videoExtension != "")
                {
                    if (Enum.TryParse((videoExtension), out VideoExtensionsEnum extension))
                    {
                        configuration.VideoExtensions.Add(new VideoExtension_CameraConfiguration { VideoExtensionId = (int)extension });
                        _videoDetectContext.SaveChanges();
                        updated = true;

                    }
                }
                if (photoExtension != "")
                {
                    if (Enum.TryParse((photoExtension), out PhotoExtensionsEnum extension))
                    {
                        configuration.PhotoExtensions.Add(new PhotoExtension_CameraConfiguration { PhotoExtensionId = (int)extension });
                        _videoDetectContext.SaveChanges();
                        updated = true;
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return updated;

        }
        /// <summary>
        /// Sets the active default value from false to true to a record in the configuration_details table based on given camera name
        /// </summary>
        /// <param name="cameraName"></param>
        public bool UpdateDb_SetActiveCamera_Configuration(CameraConfiguration configuration)
        {

            bool activeCamera = false;
            try
            {
                if (configuration != null)
                {
                    configuration.Active = true;
                    _videoDetectContext.SaveChanges();
                    activeCamera = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return activeCamera;


        }

        /// <summary>
        /// Deletes a camera configuration from the database.
        /// </summary>
        /// <param name="cameraName">The configuration object to delete</param>
        /// <returns>True if the deletion was successful, false otherwise</returns>
        public bool UpdateDb_DeleteConfiguration(CameraConfiguration configurationObject)
        {

            if (configurationObject != null)
            {
                try
                {
                    _videoDetectContext.CameraConfigurations.Remove(configurationObject);
                    _videoDetectContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            return false;
        }
        /// <summary>
        /// Deletes specific detail from the given camera configuration object
        /// </summary>
        /// <param name="cameraName"></param>
        /// <param name="folderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        /// <returns></returns>
        public bool UpdateDb_DeleteConfigurationDetail(CameraConfiguration configurationObject, string folderPath = "", string videoExtension = "", string photoExtension = "")
        {
            bool deleted = false;

            try
            {
                if (folderPath != "" && configurationObject != null && configurationObject.Folders.Count > 0)
                {
                    Folder folder = new Folder();
                    folder = ReadDb_FolderObject(folderPath);
                    Folder_CameraConfiguration folder_CameraConfiguration = new Folder_CameraConfiguration();
                    folder_CameraConfiguration = configurationObject.Folders.FirstOrDefault(x => x.Folder.FolderPath == folder.FolderPath);
                    configurationObject.Folders.Remove(folder_CameraConfiguration);
                    _videoDetectContext.SaveChanges();
                    deleted = true;
                }
                if (videoExtension != "" && configurationObject != null && configurationObject.VideoExtensions.Count > 0 && configurationObject.PhotoExtensions.Count > 0)
                {
                    VideoExtension_CameraConfiguration videoExtensions = new VideoExtension_CameraConfiguration();
                    if (Enum.TryParse((videoExtension), out VideoExtensionsEnum extension))

                    {
                        videoExtensions = configurationObject.VideoExtensions.FirstOrDefault(ve => ve.VideoExtensionId == (int)extension);

                    }


                    if (videoExtensions != null)
                    {
                        configurationObject.VideoExtensions.Remove(videoExtensions);
                        _videoDetectContext.SaveChanges();
                        deleted = true;
                    }

                }
                if (photoExtension != "" && configurationObject != null && configurationObject.PhotoExtensions.Count > 0 && configurationObject.VideoExtensions.Count > 0)
                {
                    PhotoExtension_CameraConfiguration photoExtensions = new PhotoExtension_CameraConfiguration();
                    if (Enum.TryParse((photoExtension.ToLower()), out PhotoExtensionsEnum extension))

                    {
                        photoExtensions = configurationObject.PhotoExtensions.FirstOrDefault(ve => ve.PhotoExtensionId == (int)extension);

                    }


                    if (photoExtensions != null)
                    {
                        configurationObject.PhotoExtensions.Remove(photoExtensions);
                        _videoDetectContext.SaveChanges();
                        deleted = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return deleted;
        }
        /// <summary>
        /// Cheks if a folder object exist in the database based on the given folder path
        /// </summary>
        /// <param name="folerpath"></param>
        /// <returns></returns>
        public bool ReadDb_CheckIfFolderObjectExistInDb(string folerpath)
        {
            var exists = _videoDetectContext.Folders.Any(x => x.FolderPath == folerpath);
            return exists;
        }
        /// <summary>
        ///  Retrieves folder object based on the given folder path
        /// </summary>
        /// <param name="folderpath"></param>
        /// <returns></returns>
        public Folder ReadDb_FolderObject(string folderpath)
        {
            return _videoDetectContext.Folders.Where(x => x.FolderPath == folderpath).FirstOrDefault();
        }
    }
    #endregion

}
