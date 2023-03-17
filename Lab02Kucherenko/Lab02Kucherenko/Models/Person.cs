using KMA.Lab02.Kucherenko.Tools;
using System;
using System.Windows;

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
            DateTime.Now)
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
            private set { _firstName = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }

        public String Email
        {
            get { return _email; }
            private set { _email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dob; }
            private set { _dob = value; }
        }

        public bool IsAdult => CalculateAge() >= 18;
        public SunSign SunSign => GetZodiacSign();
        public ChineseSign ChineseSign => GetChineseZodiacSigns();
        public bool IsBirthday => CalculateIsBirthday();

        #endregion

        #region CalculateAge/Birthday

        private int CalculateAge()
        {
            var age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month ||
                (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                age--;
            return age;
        }

        private bool CalculateIsBirthday()
        {
            if (!ValidAge(CalculateAge()))
                MessageBox.Show("Invalid date of birth");
            return (DateTime.Now.Day == DateOfBirth.Day) && (DateTime.Now.Month == DateOfBirth.Month);
        }

        private bool ValidAge(int age)
        {
            return age is >= 0 and < 135;
        }

        #endregion

        #region CalculateZodiacSign

        private SunSign GetZodiacSign()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            switch (month)
            {
                case 1:
                    return (day <= 19) ? SunSign.Capricorn : SunSign.Aquarius;
                case 2:
                    return (day <= 18) ? SunSign.Aquarius : SunSign.Pisces;
                case 3:
                    return (day <= 20) ? SunSign.Pisces : SunSign.Aries;
                case 4:
                    return (day <= 19) ? SunSign.Aries : SunSign.Taurus;
                case 5:
                    return (day <= 20) ? SunSign.Taurus : SunSign.Gemini;
                case 6:
                    return (day <= 20) ? SunSign.Gemini : SunSign.Cancer;
                case 7:
                    return (day <= 22) ? SunSign.Cancer : SunSign.Leo;
                case 8:
                    return (day <= 22) ? SunSign.Leo : SunSign.Virgo;
                case 9:
                    return (day <= 22) ? SunSign.Virgo : SunSign.Libra;
                case 10:
                    return (day <= 22) ? SunSign.Libra : SunSign.Scorpio;
                case 11:
                    return (day <= 21) ? SunSign.Scorpio : SunSign.Sagittarius;
                default:
                    return (day <= 21) ? SunSign.Sagittarius : SunSign.Capricorn;
            }
        }

        private ChineseSign GetChineseZodiacSigns()
        {
            return (ChineseSign)(DateOfBirth.Year % 12);
        }

        #endregion
    }
}