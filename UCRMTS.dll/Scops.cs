using System.Collections.Generic;

namespace UCRMTS.dll
{
    public class Scops
    {
      
        static Scops()
        {
            Scope = new Dictionary<AuthicationType, string>();
            Scope.Add(AuthicationType.UCRVerifiy, "consignment.verify");
            Scope.Add(AuthicationType.WaypointSubmit, "consignment.waypoint.submit");
            Scope.Add(AuthicationType.ManifestExport, "manifest.export.submit");
        }
        public enum AuthicationType
        {
            UCRVerifiy = 0,
            WaypointSubmit = 1,
            ManifestExport = 2
        }

        public static Dictionary<AuthicationType, string> Scope { get; set; }
    }
}
