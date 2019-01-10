using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulanikMantik.Models
{
    public static class MyThema
    {
        public const string Vanilla2 = "<Chart Palette=\"SemiTransparent\" BorderColor=\"#000\" BorderWidth=\"2\" BorderlineDashStyle=\"Solid\">\r\n<ChartAreas>\r\n    <ChartArea _Template_=\"All\"  Name=\"Default\">\r\n            <AxisX>\r\n                <MinorGrid Enabled=\"False\" />\r\n                <MajorGrid Enabled=\"False\" />\r\n            </AxisX>\r\n            <AxisY>\r\n                <MajorGrid Enabled=\"False\" />\r\n                <MinorGrid Enabled=\"False\" />\r\n            </AxisY>\r\n    </ChartArea>\r\n</ChartAreas>\r\n</Chart>";

        public const string Yellow = "<Chart BackColor=\"#FADA5E\" BackGradientStyle=\"TopBottom\" BorderColor=\"#B8860B\" BorderWidth=\"2\" BorderlineDashStyle=\"Solid\" Palette=\"EarthTones\">\r\n  <ChartAreas>\r\n    <ChartArea Name=\"Default\" _Template_=\"All\" BackColor=\"Transparent\" BackSecondaryColor=\"White\" BorderColor=\"64, 64, 64, 64\" BorderDashStyle=\"Solid\" ShadowColor=\"Transparent\">\r\n      <AxisY>\r\n        <LabelStyle Font=\"Trebuchet MS, 8.25pt, style=Bold\" />\r\n      </AxisY>\r\n      <AxisX LineColor=\"64, 64, 64, 64\">\r\n        <LabelStyle Font=\"Trebuchet MS, 8.25pt, style=Bold\" />\r\n      </AxisX>\r\n    </ChartArea>\r\n  </ChartAreas>\r\n  <Legends>\r\n    <Legend _Template_=\"All\" BackColor=\"Transparent\" Docking=\"Bottom\" Font=\"Trebuchet MS, 8.25pt, style=Bold\" LegendStyle=\"Row\">\r\n    </Legend>\r\n  </Legends>\r\n  <BorderSkin SkinStyle=\"Emboss\" />\r\n</Chart>";
    }
}