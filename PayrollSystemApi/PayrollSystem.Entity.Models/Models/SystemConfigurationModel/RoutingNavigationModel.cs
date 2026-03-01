using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Entity.Models.Models.SystemConfigurationModel
{
    public class RoutingNavigationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 MainRouteId { get; set; }
        public string RouteName { get; set; }
        public string IconString { get; set; }
        public string AuthorizedUsers { get; set; }

        #region Relation References
        public ICollection<RoutingNavigationChildModel> RoutingChildModels { get; set; }
        #endregion
    }
}
