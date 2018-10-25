using Newtonsoft.Json;
using SDM_Movie_Rating_Core_Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDM_Movie_Rating_JsonReader
{
    public class JsonFileAccessObject
    {
        List<MovieRating> items;

        public JsonFileAccessObject()
        {
            using (StreamReader r = new StreamReader("../../../../ratings.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<MovieRating>>(json);
            }
        }
    }
}
