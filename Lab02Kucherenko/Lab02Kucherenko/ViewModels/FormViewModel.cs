using KMA.Lab02.Kucherenko.Models;
using KMA.Lab02.Kucherenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace KMA.Lab02.Kucherenko.ViewModels
{
    internal class FormViewModel
    {
        #region Fields

        private Person _person = new Person();
        private RelayCommand<object> _proceedCommand;

        #endregion

        #region Properties

        public string FirstName
        {
            get => _person.FirstName;
            set
            {
                _person.FirstName = value;
                NotifyPropertyChanged();
            }
        }

        public string LastName
        {
            get => _person.LastName;
            set
            {
                _person.LastName = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get => _person.Email;
            set
            {
                _person.Email = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                _person.DateOfBirth = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsAdult
        {
            get => _person.IsAdult;
            private set
            {
                _person.IsAdult = value;
                NotifyPropertyChanged();
            }
        }

        public SunSign SunSign
        {
            get => _person.SunSign;
            private set
            {
                _person.SunSign = value;
                NotifyPropertyChanged();
            }
        }

        public ChineseSign ChineseSign
        {
            get => _person.ChineseSign;
            private set
            {
                _person.ChineseSign = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsBirthday
        {
            get => _person.IsBirthday;
            private set
            {
                _person.IsBirthday = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region CalculateAge

        private void CalculateIsAdult()
        {
            IsAdult = CalculateAge() >= 18;
        }

        private void CalculateIsBirthday()
        {
            IsBirthday = CalcIsBirthday();
        }

        private int CalculateAge()
        {
            var age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month ||
                (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                age--;
            return age;
        }

        private bool CalcIsBirthday()
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

        private void CalculateSunSign()
        {
            SunSign = GetZodiacSign();
        }

        private void CalculateChineseSign()
        {
            ChineseSign = GetChineseZodiacSigns();
        }

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

        #region PropChangedImplementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}