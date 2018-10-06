// ***********************************************************************
// Assembly         : KickStarter.Library.Entities
// Author           : Peter Verver
// Created          : 03-09-2018
//
// Last Modified By : Peter Verver
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="Scuba Service Software Development">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using KickStarter.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;


namespace KickStarter.Library.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseEntity()
        {

        }

        #region Fields

        private DateTime _insertDate = DateTime.Now;
        private DateTime _updateDate = DateTime.Now;
        private Boolean _state;

        #endregion

        #region public Methods

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
            OnValidate(propertyname);
        }

        #endregion

        [NotMapped]
        public Boolean State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        [Required]
        [DisplayName("Insert Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [XmlAttribute("InsertDate")]
        public DateTime InsertDate
        {
            get
            {
                return _insertDate;
            }
            set
            {
                if (_insertDate != value)
                {
                    _insertDate = value;
                    OnPropertyChanged("InsertDate");
                }
            }
        }

        [Required]
        [DisplayName("Update Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime)]
        [XmlAttribute("UpdateDate")]
        public DateTime UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                if (_updateDate != value)
                {
                    _updateDate = value;
                    OnPropertyChanged("UpdateDate");
                }
            }
        }

        public string Error
        {
            get { return null; }    //TODO: Check where this is comming from. Is triggered by a report call.
        }

        //string IDataErrorInfo.this[string propertyName]
        //{
        //    get { return OnValidate(propertyName); }
        //}

        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name.", propertyName);
            }

            string error = string.Empty;
            var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            var results = new List<ValidationResult>(1);

            var context = new ValidationContext(this, null, null) { MemberName = propertyName };
            var result = Validator.TryValidateProperty(value, context, results);

            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
            }
            SetState();

            return error;
        }

        private void SetState()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationResults, true);

            State = (validationResults.Count == 0);
        }
    }
}

