using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ProductManagement.Domain.Enums
{
    public enum TransportType
    {
        /// <summary>
        /// Semi-trailer (Yarı römork)
        /// </summary>
        SMT = 1,

        /// <summary>
        /// Bobtail (Kamyon üstü)
        /// </summary>
        BBT = 2,

        /// <summary>
        /// ISO Container
        /// </summary>
        ISO = 3
    }
}
