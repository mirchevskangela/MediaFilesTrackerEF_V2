using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.ModelClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbServicesEFCore.DbServices
{
    public class ConfigurationModificationDetailDbService
    {
        #region Constructors
        public ConfigurationModificationDetailDbService()
        {
            _databaseConfig = new DatabaseConfig();
            _videoDetectContext = new VideoDetectContext(_databaseConfig.DatabaseConnectionString());


        }
        #endregion
        #region Members
        private VideoDetectContext _videoDetectContext;
        private DatabaseConfig _databaseConfig;


        #endregion
        #region Services
        /// <summary>
        ///  Adds modified configuration to the database
        /// </summary>
        /// <param name="cameraName"></param>
        /// <param name="folderPath"></param>
        /// <param name="videoExtension"></param>
        /// <param name="photoExtension"></param>
        public void WriteDb_Configuration_Modification(ConfigurationModificationDetail modifiedConfiguration, bool created = false, bool deleted = false, bool added = false, bool modified = false)
        {
            try
            {
                if (modified && !created && !deleted && !added)
                {

                    DateTime timeNow = DateTime.Now;
                    modifiedConfiguration.Timestamp = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Modified;

                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }

                if (created && !deleted && !modified && !added)
                {
                    DateTime timeNow = DateTime.Now;
                    modifiedConfiguration.Timestamp = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Created;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);

                    int a = _videoDetectContext.SaveChanges();

                }
                if (!created && deleted && !modified && !added)
                {

                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Deleted;
                    modifiedConfiguration.Timestamp = DateTime.Now;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }
                if (!modified && !created && !deleted && added)
                {
                    DateTime timeNow = DateTime.Now;
                    modifiedConfiguration.Timestamp = timeNow.Date.AddHours(timeNow.Hour).AddMinutes(timeNow.Minute).AddSeconds(timeNow.Second);
                    modifiedConfiguration.ActionsID = (int)ActionsEnum.Added;
                    _videoDetectContext.ConfigurationModificationDetails.Add(modifiedConfiguration);
                    _videoDetectContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Retrieves a list of configuration modifications that occurred between the specified start and end dates.
        /// </summary>
        /// <param name="fromTimestamp"></param>
        /// <param name="toTimestamp"></param>
        /// <returns></returns>
        public List<ConfigurationModificationDetail> ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime fromTimestamp, DateTime toTimestamp, string searchCameraConfiguration = "")
        {
            List<ConfigurationModificationDetail> objects = new List<ConfigurationModificationDetail>() { };
            try
            {
                if (searchCameraConfiguration != "")
                {
                    objects = _videoDetectContext.ConfigurationModificationDetails?.Include(f => f.Folders).ThenInclude(f => f.Folder).Include(v => v.VideoExtensions).ThenInclude(v => v.VideoExtension).Include(p => p.PhotoExtensions).ThenInclude(p => p.PhotoExtension).Include(c => c.Actions).Where(c => c.Timestamp >= fromTimestamp && c.Timestamp <= toTimestamp && c.CameraName == searchCameraConfiguration).ToList();
                    return objects;
                }
                else
                {
                    objects = _videoDetectContext.ConfigurationModificationDetails.Include(f => f.Folders).ThenInclude(f => f.Folder).Include(v => v.VideoExtensions).ThenInclude(v => v.VideoExtension).Include(p => p.PhotoExtensions).ThenInclude(p => p.PhotoExtension).Include(c => c.Actions).Where(c => c.Timestamp >= fromTimestamp && c.Timestamp <= toTimestamp).ToList();
                    return objects;
                }
                return objects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
