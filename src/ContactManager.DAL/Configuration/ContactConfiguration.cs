using System;
using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.DAL.Configuration
{
    /// <summary>
    /// Start configuration for contacts.
    /// </summary>
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData
            (
                new Contact
                {
                    Id = 1,
                    Name = "George",
                    DateOfBirth = new DateTime(2000, 2, 29),
                    Married = false,
                    Phone = "0730746521",
                    Salary = 500,
                },
                new Contact
                {
                    Id = 2,
                    Name = "Victoria",
                    DateOfBirth = new DateTime(2001, 4, 1),
                    Married = false,
                    Phone = "0730746322",
                    Salary = 2000,
                }
            );
        }
    }
}
