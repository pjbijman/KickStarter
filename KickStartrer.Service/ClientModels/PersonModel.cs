using KickStarter.Library.Enums.Bandmate.Library.Enums;
using System;

namespace KickStartrer.Service.ClientModels
{
    /// <summary>
    /// Ckient person Model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the insertion.
        /// </summary>
        /// <value>The insertion.</value>
        public string Insertion { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The suffix.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the social segurity number.
        /// </summary>
        /// <value>The social segurity number.</value>
        public string SocialSegurityNumber { get; set; }

        ///// <summary>
        ///// Gets or sets the image.
        ///// </summary>
        ///// <value>The image.</value>
        public Byte[] Image { get; set; } = KickStarter.Library.Helpers.Helpers.GetDummyImage();


    }
}
