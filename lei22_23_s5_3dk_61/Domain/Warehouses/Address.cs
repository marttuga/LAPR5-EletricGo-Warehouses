using System;
using DDDSample1.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DDDSample1.Domain.Warehouses
{
    [Owned]
    public class Address : IValueObject
    {

        public string Street { get;  private set; }

        public int DoorNumber { get;  private set; }
        public string City { get;  private set; }
        public string ZipCode { get;  private set; }

        

        private Address()
        {         
        }

        public Address( string street, int doorNumber, string city, string zipCode)
        {
        this.Street = validateString(street);
        this.DoorNumber = validateDoorNumber(doorNumber);
        this.City = validateString(city);
        this.ZipCode = isValidPortugalZipCode(zipCode);
        }

        private int validateDoorNumber(int doorNumber){
            if(doorNumber<=0)
                throw new ArgumentOutOfRangeException("Door number can't be negative or 0!");
            return doorNumber;
        }

        private string isValidPortugalZipCode(string zipCode)
        {
            string pattern = @"^\d{4}-\d{3}$";
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(zipCode))
                return zipCode;
            else
                throw new FormatException("ZipCode format not valid!");
        }

        private string validateString(string word){
            if(string.IsNullOrEmpty(word))
                throw new ArgumentNullException("Attribute can't be null nor empty!");
            return word;
        }
    }
}