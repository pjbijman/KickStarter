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

using AutoMapper;
using KickStarter.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace KickStarter.Library.Entities
{
    [Serializable()]
    public class BaseEntity : IBaseEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseEntity()
        {

        }

        #region Fields

        private Guid _id = Guid.NewGuid();
        private DateTime _insertDate = DateTime.Now;
        private DateTime _updateDate = DateTime.Now;
        private Boolean _isValid;

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

        #region Properties

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        [Required(ErrorMessage = "Id Required!")]
        [XmlAttribute("Id")]
        [DataMember]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [NotMapped]
        [XmlIgnore]
        public Boolean IsValid
        {
            get
            {
                return _isValid;
            }
            private set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    OnPropertyChanged("IsValid");
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

        #endregion

        public string Error
        {
            get { return null; }    //TODO: Check where this is comming from. 
        }

        //string IDataErrorInfo.this[string propertyName]
        //{
        //    get { return OnValidate(propertyName); }
        //}

        [NotMapped]
        [IgnoreMap]
        [XmlIgnore]
        public IDictionary<string, HashSet<string>> ValidationResults { get; set; }

        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name.", propertyName);
            }

            string error = string.Empty;
            var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            var results = new List<ValidationResult>(1);

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(this, null, null) { MemberName = propertyName };
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
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(this, null, null);
            Validator.TryValidateObject(this, context, validationResults, true);

            ValidationResults = new Dictionary<string, HashSet<string>>();
            foreach (ValidationResult item in validationResults)
            {
                var em = new HashSet<string>();
                em.Add(item.ErrorMessage.ToString());

                ValidationResults.Add(item.MemberNames.First().ToString(), em);

            }
            _isValid = (ValidationResults.Count == 0);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!ValidationResults.ContainsKey(propertyName))
            {
                ValidationResults.Add(propertyName, new HashSet<string>(new[] { errorMessage }));
            }
            else
            {
                if (!ValidationResults[propertyName].Contains(errorMessage))
                    ValidationResults[propertyName].Add(errorMessage);
            }
        }

    }
}

