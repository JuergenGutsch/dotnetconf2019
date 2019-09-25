using System;
using System.Collections.Generic;

namespace DncWeatherStats.Common
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string WeatherStationId { get; set; }
        public DateTime Date { get; set; }

        public float? AvgTemperature { get; set; }
        public float? MinTemperature { get; set; }
        public float? MaxTemperature { get; set; }

        public float? AvgWindSpeed { get; set; }

        public float? Precipitaion { get; set; }


        public WeatherStation WeatherStation { get; set; }
    }
}


/*
CREATE TABLE [dbo].[WeatherData](
	[WeatherStationId] [nvarchar](20) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[AvgTemperature] [decimal](10, 4) NULL,
	[MinTemperature] [decimal](10, 4) NULL,
	[MaxTemperature] [decimal](10, 4) NULL,
	[AvgWindSpeed] [decimal](10, 4) NULL,
	[Precipitaion] [decimal](10, 4) NULL,
 CONSTRAINT [PK_WeatherData] PRIMARY KEY CLUSTERED 
(
	[WeatherStationId] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 */
