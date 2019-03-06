using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {        /// <summary>
             /// Gets or sets the entity identifier
             /// </summary>
        public int Id { get; set; }
    }
}
