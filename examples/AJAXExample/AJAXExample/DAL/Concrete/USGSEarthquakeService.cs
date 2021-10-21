using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using AJAXExample.Models;
using AJAXExample.DAL.Abstract;

namespace AJAXExample.DAL.Concrete
{
    public class USGSEarthquakeService : IEarthquakeService
    {
        public string BaseSource { get; }

        public USGSEarthquakeService()
        {
            BaseSource = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/1.0_{0}.geojson";
        }

        /*{"type":"FeatureCollection","metadata":{"generated":1604797642000,"url":"https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_hour.geojson","title":"USGS Magnitude 2.5+ Earthquakes, Past Hour","status":200,"api":"1.10.3","count":1},"features":[{"type":"Feature","properties":{"mag":5.3,"place":"133 km SW of Lata, Solomon Islands","time":1604795943808,"updated":1604797004040,"tz":null,"url":"https://earthquake.usgs.gov/earthquakes/eventpage/us7000cbyq","detail":"https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000cbyq.geojson","felt":null,"cdi":null,"mmi":null,"alert":null,"status":"reviewed","tsunami":0,"sig":432,"net":"us","code":"7000cbyq","ids":",us7000cbyq,","sources":",us,","types":",moment-tensor,origin,phase-data,","nst":null,"dmin":4.358,"rms":0.71,"gap":60,"magType":"mww","type":"earthquake","title":"M 5.3 - 133 km SW of Lata, Solomon Islands"},"geometry":{"type":"Point","coordinates":[164.9895,-11.6348,12.63]},"id":"us7000cbyq"}]} */

        public IEnumerable<Earthquake> GetRecentEarthquakes(EarthquakeTimeRange timeRange)
        {
            string source = string.Format(BaseSource,Earthquake.TimeRanges[timeRange]);
            string jsonResponse = SendRequest(source);
			Debug.WriteLine(jsonResponse);

            List<Earthquake> output = new List<Earthquake>();
			// Handle an exception here!!!
			JObject geo = JObject.Parse(jsonResponse);
			int count = (int)geo["metadata"]["count"];
			// validate count!!!
			for(int i = 0; i < count; i++)
            {
				string place = (string)geo["features"][i]["properties"]["place"];
				double mag = (double)geo["features"][i]["properties"]["mag"];
				output.Add(new Earthquake { Location = place, Magnitude = mag });
			}

			return output;
        }

        // Should put this in a utility or base class if we plan on reusing it
        private static string SendRequest(string uri)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.Accept = "application/json";

			string jsonString = null;
			using (WebResponse response = request.GetResponse())
			{
				Stream stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				jsonString = reader.ReadToEnd();
				reader.Close();
				stream.Close();
			}
			return jsonString;
		}
    }
}