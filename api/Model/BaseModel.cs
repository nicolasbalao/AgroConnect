using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    /// <summary>
    /// Represents the base model for all entities in the application.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the nique identifier for the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
