// ***********************************************************************
// Assembly         : KickStarter.Library.Entities
// Author           : Peter Verver
// Created          : 03-09-2018
//
// Last Modified By : Peter Verver
// Last Modified On : 09-10-2018
// ***********************************************************************
// <copyright file="Person.cs" company="Scuba Service Software Development">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using KickStarter.Library.Enums.Bandmate.Library.Enums;
using KickStarter.Library.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace KickStarter.Library.Entities
{
    public class Person : BaseEntity, IPerson, IIdentifiable
    {
        #region Fields

        /// <summary>
        /// The _first name
        /// </summary>
        private string _firstName;
        /// <summary>
        /// The _middle name
        /// </summary>
        private string _middleName;
        /// <summary>
        /// The _last name
        /// </summary>
        private string _lastName;
        /// <summary>
        /// The _insertion
        /// </summary>
        private string _insertion;
        /// <summary>
        /// The _suffix
        /// </summary>
        private string _suffix;
        /// <summary>
        /// The _gender
        /// </summary>
        private Gender _gender = Gender.Male;
        /// <summary>
        /// The _date of birth
        /// </summary>
        private DateTime? _dateOfBirth;
        /// <summary>
        /// The _social segurity number
        /// </summary>
        private string _socialSegurityNumber;
        /// <summary>
        /// The _image
        /// </summary>
        private Byte[] _image;  // = Helpers.GetDummyImage();
        /// <summary>
        /// The Description
        /// </summary>
        private string _description;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            UpdateDate = DateTime.Now;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required(ErrorMessage = "First Name Required!")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters are allowed.")]
        [XmlAttribute("FirstName")]
        [DataMember]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        [StringLength(50, ErrorMessage = "Maximum 50 characters are allowed.")]
        [XmlAttribute("MiddleName")]
        [DataMember]
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the insertion.
        /// </summary>
        /// <value>The insertion.</value>
        [StringLength(50, ErrorMessage = "Maximum 50 characters are allowed.")]
        [XmlAttribute("Insertion")]
        [DataMember]
        public string Insertion
        {
            get
            {
                return _insertion;
            }
            set
            {
                if (_insertion != value)
                {
                    _insertion = value;
                    OnPropertyChanged("Insertion");
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required(ErrorMessage = "Last Name Required!")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters are allowed.")]
        [XmlAttribute("LastName")]
        [DataMember]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        [StringLength(50, ErrorMessage = "Maximum 50 characters are allowed.")]
        [XmlAttribute("Suffix")]
        [DataMember]
        public string Suffix
        {
            get
            {
                return _suffix;
            }
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    OnPropertyChanged("Suffix");
                }
            }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [XmlAttribute("Gender")]
        [DataMember]
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Required(ErrorMessage = "Date Of Birth Required!")]
        [DisplayName("Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [XmlElement("DateOfBirth")]    //For nullable guid must be an XmlElement
        [DataMember]
        public DateTime? DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }

        /// <summary>
        /// Gets or sets the social segurity number.
        /// </summary>
        /// <value>The social segurity number.</value>
        [DisplayName("Social Segurity Number")]
        [XmlAttribute("SocialSegurityNumber")]
        [DataMember]
        public string SocialSegurityNumber
        {
            get
            {
                return _socialSegurityNumber;
            }
            set
            {
                if (_socialSegurityNumber != value)
                {
                    _socialSegurityNumber = value;
                    OnPropertyChanged("SocialSegurityNumber");
                }
            }
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [DisplayName("Full Name")]
        [NotMapped]
        public String FullName
        {
            get
            {
                string fullname = String.Format("{0} {1} {2}", (FirstName ?? null), (Insertion ?? null), (LastName ?? null));
                return fullname.Replace("  ", " ").Trim();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
       // [DisplayName("Image")]
        [DataMember]
        public Byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        //[DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [XmlAttribute("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        int IIdentifiable.Id { get => throw new NotImplementedException("IIdentifiable not set for KickStarter.Library.Entities.Person"); set => throw new NotImplementedException("IIdentifiable not set for KickStarter.Library.Entities.Person"); }

        #endregion

        public override string ToString()
        {
            return FullName;
        }
    }
}
