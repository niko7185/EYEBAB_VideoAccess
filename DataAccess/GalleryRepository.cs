using Entities;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class GalleryRepository : BaseRepository<GalleryVideo>
    {

        public List<GalleryVideo> GetAllByLang(string lang)
        {

            string[] splitLang = lang.Split("-");
            string shortLang = splitLang[0];

            string sql = "SELECT * FROM GalleryCategoryEntries " +
                            $"LEFT JOIN {shortLang}_GalleryVideos ON GalleryCategoryEntries.VideoID = {shortLang}_GalleryVideos.VideoID " +
                            "LEFT JOIN GalleryCategories ON GalleryCategoryEntries.CategoryID = GalleryCategories.CategoryID " +
                            "ORDER BY GalleryCategoryEntries.VideoID";

            List<GalleryVideo> galleryVideos = new List<GalleryVideo>();

            if (connection != null)
            {

                connection.Open();

                try
                {

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            int vidId = -1;

                            while (reader.Read())
                            {

                                if (reader.GetInt32(3) != vidId)
                                {

                                    vidId = reader.GetInt32(3);

                                    GalleryVideo galleryVideo = new GalleryVideo(reader.GetInt32(3), reader.GetString(4), reader.GetString(5), 
                                        reader.GetString(6), reader.GetDateTime(7));

                                    galleryVideos.Add(galleryVideo);


                                }

                                galleryVideos[galleryVideos.Count - 1].AddCategory(reader.GetString(9));

                            }

                        }

                    }

                }
                catch (Exception)
                {

                    throw;
                }

                connection.Close();

            }

            return galleryVideos;

        }

        public List<string> GetCategories()
        {
            string sql = "SELECT Value FROM GalleryCategories";

            List<string> categories = new List<string>();

            if (connection != null)
            {

                connection.Open();

                try
                {

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                categories.Add(reader.GetString(0));

                            }

                        }

                    }

                }
                catch (Exception)
                {

                    throw;
                }

                connection.Close();

            }

            return categories;
        }

    }
}
