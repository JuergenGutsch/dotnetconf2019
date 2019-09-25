using System.Collections.Generic;

namespace DncWeatherStats.Common
{
    public class WeatherStation
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }

        public IEnumerable<WeatherData> WeatherData { get; set; }
    }
}

/*
CREATE TABLE [dbo].[WeatherStation](
	[Id] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Latitude] [decimal](10, 4) NOT NULL,
	[Longitude] [decimal](10, 4) NOT NULL,
	[Elevation] [decimal](10, 4) NOT NULL,
 CONSTRAINT [PK_WeatherStation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

 */