// ***********************************************************************
// Assembly         : KickStarter.Library.Interfaces
// Author           : Peter Verver
// Created          : 07-04-2017
//
// Last Modified By : Peter Verver
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="IBaseEntity.cs" company="Scuba Service Software Development">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace KickStarter.Library.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        Boolean IsValid { get; set; }

        DateTime InsertDate { get; set; }

        DateTime UpdateDate { get; set; }

    }
}
