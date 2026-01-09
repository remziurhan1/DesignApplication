using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Enums
{
    /// <summary>
    /// Tank yerleşim tipi
    /// </summary>
    public enum PlacementType
    {
        /// <summary>
        /// Yer üstü - A (Aboveground)
        /// </summary>
        Aboveground = 1,

        /// <summary>
        /// Yer altı - U (Underground)
        /// </summary>
        Underground = 2
    }
}
