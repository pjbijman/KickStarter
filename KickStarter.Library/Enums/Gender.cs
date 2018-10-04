// ***********************************************************************
// Assembly         : Bandmate.Library.Enums
// Author           : Peter Verver
// Created          : 07-04-2017
//
// Last Modified By : Peter Verver
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="Gender.cs" company="Scuba Service Software Development">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace KickStarter.Library.Enums
{

    namespace Bandmate.Library.Enums
    {
        /// <summary>
        /// Enum Gender
        /// </summary>
        [Serializable]
        [DataContract]
        public enum Gender
        {
            /// <summary>
            /// The male
            /// </summary>
            [Description("Male")]
            [EnumMember]
            Male = 0,
            /// <summary>
            /// The female
            /// </summary>
            [Description("Female")]
            [EnumMember]
            Female = 1
        }
    }
}
