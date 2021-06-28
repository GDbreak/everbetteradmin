using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Users.
    /// </summary>
    public class UsersResource
    {
        /// <summary>
        /// The GUID for the user.
        /// </summary>
        public Guid UsersID { get; set; }

        /// <summary>
        /// The OAuth ID for the user.
        /// </summary>
        public string OAuthID { get; set; }

        /// <summary>
        /// The first name for the user.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The middle name for the user.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// The last name for the user.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The primary street address for the user.
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// The secondary street address for the user, when applicable.
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// The city the user lives in.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The state the user lives in.
        /// </summary>
        public string StateAbbreviation { get; set; }
        /// <summary>
        /// The zip code the user lives in.
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The country the user lives in.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The user's gender.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// The user's date of birth.
        /// </summary>
        public DateTime? DateofBirth { get; set; }
        /// <summary>
        /// The user's phone number.
        /// </summary>
        public string PrimaryPhone { get; set; }
        /// <summary>
        /// If available, a SAS url for a user's profile picture.
        /// </summary>
        public Uri ProfilePictureURL { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
    }
}
