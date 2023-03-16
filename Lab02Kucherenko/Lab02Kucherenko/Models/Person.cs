using KMA.Lab02.Kucherenko.Tools;
using System;

namespace KMA.Lab02.Kucherenko.Models
{
    internal class Person
    {
        #region Fields

        private String _firstName;
        private String _lastName;
        private String _email;
        private DateTime _dob;
        private bool _isAdult;
        private SunSign _sunSign;
        private ChineseSign _chineseSign;
        private bool _isBirthday;

        #endregion

        #region Constructors

        public Person()
        {
        }

        public Person(String firstName, String lastName, String email, DateTime dob)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _dob = dob;
        }

        public Person(String firstName, String lastName, String email) : this(firstName, lastName, email,
            default(DateTime))
        {
        }

        public Person(String firstName, String lastName, DateTime dob) : this(firstName, lastName, null, dob)
        {
        }

        #endregion

        #region Properties

        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            set { _isAdult = value; }
        }

        public SunSign SunSign
        {
            get => _sunSign;
            set { _sunSign = value; }
        }

        public ChineseSign ChineseSign
        {
            get => _chineseSign;
            set => _chineseSign = value;
        }

        public bool IsBirthday
        {
            get => _isBirthday;
            set => _isBirthday = value;
        }

        #endregion

    }
}