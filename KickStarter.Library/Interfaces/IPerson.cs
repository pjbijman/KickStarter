// ***********************************************************************
// Assembly         : Bandmate.Library.Interfaces
// Author           : Peter Verver
// Created          : 07-04-2017
//
// Last Modified By : Peter Verver
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="IPerson.cs" company="Scuba Service Software Development">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using System;
using System.ServiceModel;

namespace KickStarter.Library.Interfaces
{
    /// <summary>
    /// Interface IPerson
    /// </summary>
    [ServiceContract]
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        //Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the insertion.
        /// </summary>
        /// <value>The insertion.</value>
        string Insertion { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the social segurity number.
        /// </summary>
        /// <value>The social segurity number.</value>
        string SocialSegurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        Byte[] Image { get; set; }


    }
}
