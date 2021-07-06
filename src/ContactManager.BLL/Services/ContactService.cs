using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.BLL.Interfaces;
using ContactManager.DAL.Entities;
using ContactManager.DAL.Interfaces;
using Microsoft.Data.SqlClient;

namespace ContactManager.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public readonly string Connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContactManagerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetAllContactsAsync()
        {
            return _mapper.Map<IEnumerable<ContactDto>>(await _database.ContactRepository.ListItemsAsync());
        }

        public async Task<ContactDto> GetContactById(int contactId)
        {
            var contact = await _database.ContactRepository.GetItemAsync(contactId);

            return _mapper.Map<ContactDto>(contact);
        }

        public async Task AddNewContactAsync(ContactDto contactDto)
        {
            await _database.ContactRepository.CreateAsync(_mapper.Map<Contact>(contactDto));
            await _database.ContactRepository.SaveAsync();
        }

        public async Task EditContactAsync(ContactDto contactDto)
        {
            _database.ContactRepository.Update(_mapper.Map<Contact>(contactDto));
            await _database.ContactRepository.SaveAsync();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            await _database.ContactRepository.DeleteByIdAsync(contactId);
            await _database.ContactRepository.SaveAsync();
        }

        public void AddCsvFile(string dbPath)
        {
            DataTable tableCsv = new DataTable();
            tableCsv.Columns.Add("Name");
            tableCsv.Columns.Add("DateOfBirth");
            tableCsv.Columns.Add("Married");
            tableCsv.Columns.Add("Phone");
            tableCsv.Columns.Add("Salary");
            var readCsv = File.ReadAllText(dbPath);

            foreach (var csvRow in readCsv.Split('\n'))
            {
                if (string.IsNullOrEmpty(csvRow)) continue;
                tableCsv.Rows.Add();
                int count = 0;
                foreach (var fileRecord in csvRow.Split(','))
                {
                    tableCsv.Rows[^1][count] = fileRecord;
                    count++;
                }
            }
            InsertCsvRecords(tableCsv);
        }

        private void InsertCsvRecords(DataTable csvTable)
        {
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                SqlBulkCopy objectBulk = new SqlBulkCopy(connection) { DestinationTableName = "Contacts" };

                objectBulk.ColumnMappings.Add("Name", "Name");
                objectBulk.ColumnMappings.Add("DateOfBirth", "DateOfBirth");
                objectBulk.ColumnMappings.Add("Married", "Married");
                objectBulk.ColumnMappings.Add("Phone", "Phone");
                objectBulk.ColumnMappings.Add("Salary", "Salary");
                connection.Open();
                objectBulk.WriteToServer(csvTable);
                connection.Close();
            }
        }
    }
}
